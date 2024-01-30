using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using BizHawk.Common.StringExtensions;
using Newtonsoft.Json;

// Syntax https://pastebin.com/Uxn6zREQ


/*
!p syntax guide

!p BUTTON11[:TIMING1][|REPETITIONS1[.REP_DELAY1]]][;BUTTON12[:TIMING2][|REPETITIONS2[.REP_DELAY2]]][-SEQUENCE_TIMING-BUTTON21[:TIMING3][;...]][-...]

BUTTONXY Means Button Y of sequence group X

NOTE: Total command string lengths, and maximum timing lengths are restricted and configurable. So your inputs may not always be accepted.

Buttons are pressed with or without timings attached to them, pressed simultaneously or in sequence, with buttons and sequence groups able to have repetitions

BUTTON above can be any of the following, with aliases, and follow these rules:

If the first letter is lowercase, it is a 1 frame quick press.
If the first letter is Uppercase, it is a 1 second HOLD.
The 2 above rules are ignored if a timing is attached



Left = LE LF LT LFT
Right = RI RT
Up = U
Down = D DO DW DN
Start = S ST STR STAR
Select = SE SEL SCT SLCT SLT
A
B
C
X
Y
Z
L
R
L1
L2
R1
R2



Timings are attached to a button name from above with a   :   -> BUTTON:TIMING
Timings without a time suffix are frames to hold the button for
Timing suffixes are 'ms' for milliseconds, and 's' for seconds

Ex/
  Left:10  will hold the left button for 10 frames
  STR:100ms will hold the start button for 100 milliseconds
  L  will press the L button for 1 frame
  r  will hold the R button for 1 second


Simultaneous presses are separated by a semilcolon ;
Ex / Left:10;L;r  will press the Left button for 10 frames, the L button for 1 frame, and the R button for 1 second, all pressed starting on the same frame.


Repetitions are attached to a button or timing pair
Repetitions cause the button to be released to a configurable number of frames before being pressed again for the optional specified length and required number of repetitions
You can also optionally attach your own timing delay between repetitions if the default configured one on the server is not optimal

Repetitions are attached to a button with   |   -> BUTTON|REPETITIONS or BUTTON:TIMING|REPETITIONS
Optional Delays are then attached to repetitions with   .   -> BUTTON|REPETITIONS.TIMING or BUTTON:TIMING|REPETITIONS.TIMING
Where TIMING is the same format as above


ex/ Down|10							Presses the down button for the default HOLD time 10 times, with the default frame delay time between each repetition. So if the default hold time in frames is X, and the default frame delay is Y then the total time this command would take is 10(X+Y) frames to actually complete this button press
	le:6|100.3;A|10-5s-a|10.5s		Start at time T. Press the Left button for 6 frames, repeat 100 times with a 3 frame delay between each press. At the same time, Press the A button for the default HOLD time and repeat 10 times. Wait until T+5s, then press the A button for the default press time. Repeat that press 10 times with a 5 second delay between each press.


Sequenced presses are separated by -TIMING-
Ex/ -1000- means wait 1000 frames before sending the next grouping of buttons and timings. SEQUENCE TIMINGS ARE ADDITIVE, this means that each timing delay further down are ADDED to the total of all previous timer delays before it. Use simultaneous presses for the other use case.

ex/ dw:2-2-ri:2-2-up:2-2-a;b:1s  On Frame T press down for 2 frames. On Frame T+2, press right for 2 frames. On Frame T+4 press up for 2 frames. Finally on Frame T+6 press a for 1 frame, and b for 1 second

 
REPETITION GROUPS
In addition to button repetitions, you can create groupings of the above syntaxes by enclosing them in ()
You can also attach repetitions in the same format as above to these groups. And you can also sequence these groups!

ex/ (dw:2-2-ri:2-2-up:2-2-a;b:1s)|10-10s-(le:6|100.3;A|10-5s-a|10.5s)|5.3s-5-Left:10;L;r

You can nest them too

ex / (dw:2-2-(le:6|100.3-2-a|10.5s)|5.3s)|10	Press Down for 2 frames, wait 2 frames, then do the whole sequence of (left 6 frames, repeat 100 times, wait 3 frames between each. Then wait 2 frames, press the A button and repeat 10 times, with a 5 second delay between each. Repeat that sequence 5 times with a 3 second delay between each repeat. FINALLY repeat that whole thing 10 times


That's a hell of a lot!
So, it does the example from sequenced presses from above in full, before repeating. Repeats 10 times. THEN waits 10 seconds with the default delay between each repeat. Then do the example from Repetitions in full and repeat that 5 times with a 3 second delay between each repeat Then wait 5 frames, and finally o the example from Simultaneous presses just once.

 */


namespace BizhawkRemotePlay
{
    public interface IRemotePlayer
	{
		void HandleMessage(string message);
		string CommandPrefix(string message);

        T LoadConfigFile<T>(string path) where T : new();
        void SaveConfigFile<T>(string path, T config) where T : class;
    }



	[ExternalTool("Remote Play")]
	public partial class BizhawkRemotePlay : ToolFormBase, IExternalToolForm, IRemotePlayer
	{
		public const int MILLIS_PER_SEC = 1000;
		public const int BUFFER_SIZE = 128;

		// BizHawk stuff
		protected override string WindowTitleStatic => "Remote Play";
		public const string ConfigFilePath = "ExternalTools/remoteplay.json";

		public ApiContainer? _maybeAPIContainer { get; set; }
		private ApiContainer APIs => _maybeAPIContainer!;

		private Dictionary<string, bool> pressedButtons = new Dictionary<string, bool>();
		private Dictionary<int, Dictionary<string, bool>> frameButtonStates = new Dictionary<int, Dictionary<string, bool>>();
		private Queue<List<ButtonSequence>> queuedSequences = new Queue<List<ButtonSequence>>();

		private State systemState;

		private StringDecoder decoder;

		private InputProvidersForm servicesForm;
		public RemotePlayConfig configFile;

		public int? PadID { get; private set; } = null;

		public bool IsSystemValid { get; private set; } = false;

        // Actual system FPS to calculate times from and from frame counts accurately 
        public static readonly IReadOnlyDictionary<string, float> SystemFrameRates = new Dictionary<string, float>()
		{
			{"NES", 60.0988f},
			{"SNES", 60.0988f},
			{"GBC", 59.7275f},
            {"GB", 59.7275f},
            {"GBA", 59.7275f},
            {"GEN", 59.9275f},
            {"PSX", 60f},
            {"N64", 60f},
            {"MSX", 59.9275f},
            {"AppleII", 59.9275f},
            {"Coleco", 59.9275f},
			{"A26", 59.9275f},
			{"C64", 59.9275f},
			{"NDS", 59.8261f}
        };

		public static readonly string[] BannedButtons =
		{
			"power",
			"reset",
			"tilt x",
			"tilt y",
			"tilt z",
			"close tray",
			"open tray",
			"light sensor",
            "mode",
            "analog",
            "lidopen",
			"lidclose",
			"touch"
        };



		public BizhawkRemotePlay()
        {
			InitializeComponent();
            configFile = LoadConfigFile<RemotePlayConfig>(ConfigFilePath);

            systemState = new State(
                configFile.MaxReps,
                configFile.MaxActFrames,
                configFile.PressFrames,
                configFile.HoldFrames,
                configFile.RepetitionDelay,
                configFile.SequenceDelay
			);

			ReloadUI();

            decoder = new StringDecoder(systemState);

			TwitchService ts = new TwitchService(this);
            DiscordService ds = new DiscordService(this);

			servicesForm = new InputProvidersForm(this, new IService[]{ ts, ds });

			servicesForm.InitializeConnections();
        }



		private void ReloadUI()
		{
			nud_maximumActionTime.Value = configFile.MaxActFrames;
			nud_holdFramesDefault.Value = configFile.HoldFrames;
			nud_pressFramesDefault.Value = configFile.PressFrames;
			nud_maximumRepititions.Value = configFile.MaxReps;
			nud_RepDelay .Value = configFile.RepetitionDelay;
			nud_sequenceDelay.Value = configFile.SequenceDelay;
			nud_QueueSize.Value = configFile.QueueSize;

			radio_Chaos.Checked = configFile.ChaosMode;
			radio_Queue.Checked = configFile.QueueSequences;

			UIRecalculateTimeLabels();
        }


		
		public string CommandPrefix(string command)
		{
			string prefix = "bt";

			if (command.CompareTo(configFile.ClearCommand) == 0)
			{
				prefix = "cl";
			}

			return prefix;
		}



		public bool ExecutingSequence()
        {
			return frameButtonStates.Count > 0;
        }



		public void HandleMessage(string msg)
        {
			if (!IsSystemValid)
			{
				return;
			}

			var i = msg.IndexOf(':');
			// We expect this to be in position 3
			if (i != 2)
            {
#if DEBUG
				Utility.WriteLine($"Invalid format for command. Expected i=2, but i={i}");
#endif
				return;
            }

			var cmd = msg.Substring(0, i);
			msg = msg.Substring(i+1);
#if DEBUG
			Utility.WriteLine($"Command: [{cmd}], Msg: [{msg}]");
#endif
			switch (cmd.ToLower())
            {               // Clear Stored Inputs
                case "cl":
                    pressedButtons = pressedButtons.ToDictionary(o => o.Key, o => false);
                    frameButtonStates.Clear();
                    break;

                // Buttons
                default:
					if (!decoder.ValidateButtonString(msg, out List<ButtonSequence> sequence))
					{
						return;
					}
					if (!ExecutingSequence() || radio_Chaos.Checked)
					{
						PressButtons(sequence, APIs.Emulation.FrameCount() + 1);
					}
					else if (queuedSequences.Count < nud_QueueSize.Value)
					{
						queuedSequences.Enqueue(sequence);
                    }

                    Invoke((MethodInvoker)delegate {
                        inputList.Items.Insert(0, msg);
                        if (inputList.Items.Count >= 100)
                        {
                            inputList.Items.RemoveAt(inputList.Items.Count - 1);
                        }
                    });
                    break;
            }
		}



        /// <summary>
        /// Processes each ButtonSequence, modifying frameButtonStates to match the sequence
		/// Calculates button 
        /// </summary>
        /// <param name="sequence"></param>
        private void PressButtons(List<ButtonSequence> sequence, int sequenceStart)
        {
#if DEBUG
			Utility.WriteLine($"Pressing buttons on frame: {APIs.Emulation.FrameCount()}");
#endif
			
			foreach (var seq in sequence)
            {
				int sequenceDuration = 0;

				sequenceStart += seq.CommandDelay;

				foreach (ButtonCommand btns in seq.Buttons)
                {
					int delta = btns.Duration + btns.Reps.Delay;
					int startFrame = sequenceStart - delta;
                    int endFrame = btns.Duration + sequenceStart - delta;

					for (int i = 1; i <= btns.Reps.Reps; ++i)
					{
						startFrame += delta;
						endFrame += delta;

						if (frameButtonStates.ContainsKey(startFrame))
						{
							var d = frameButtonStates[startFrame];

							if (d.ContainsKey(btns.Button))
                            {
								d[btns.Button] = true;
							}
							else
                            {
								d.Add(btns.Button, true);
							}
						}
						else
						{
							frameButtonStates.Add(startFrame, new Dictionary<string, bool>() { { btns.Button, true } });
						}

						if (frameButtonStates.ContainsKey(endFrame))
						{
							var d = frameButtonStates[endFrame];

							if (d.ContainsKey(btns.Button))
							{
								d[btns.Button] = false;
							}
							else
							{
								d.Add(btns.Button, false);
							}
						}
						else
						{
							frameButtonStates.Add(endFrame, new Dictionary<string, bool>() { { btns.Button, false } });
						}
					}

					sequenceDuration = Math.Max(sequenceDuration, endFrame - sequenceStart);
				}

				sequenceStart += sequenceDuration;
			}
		}



		/// <summary>
		/// Override Bizhawk ToolFormBase method, this is called when the plugin is loaded, and whenever a new core/rom is loaded
		/// We find the system controls here
		/// </summary>
		public override void Restart()
        {
			var gameInfo = APIs.Emulation.GetGameInfo();

			IsSystemValid = gameInfo != null && gameInfo.System.Length > 0 && gameInfo.System.CompareTo("NULL") != 0;

            if (IsSystemValid)
			{
				PadID = 1;
				Dictionary<string, bool> buttons = ((Dictionary<string, object>)APIs.Joypad.Get(PadID)).Where(o=>!BannedButtons.Contains(o.Key.ToLower())).ToDictionary
					(
						o => {
							return o.Key.RemovePrefix("p1 ").RemovePrefix("P1 ");
						},
						_ => false
					);

				if (buttons.Count <= 0)
				{
					PadID = null;
                    buttons = ((Dictionary<string, object>)APIs.Joypad.Get(PadID)).Where(o => !BannedButtons.Contains(o.Key.ToLower())).ToDictionary
                    (
                        o => {
                            return o.Key.RemovePrefix("p1 ").RemovePrefix("P1 ");
                        },
                        _ => false
                    );
                }

				systemState.JoypadButtons = new HashSet<string>(buttons.Select(o => o.Key));
				systemState.System = gameInfo!.System;

				pressedButtons = buttons;

				if (!SystemFrameRates.TryGetValue(gameInfo.System, out float systemFPS))
				{
					systemState.SystemFPS = ((gameInfo.Region?.ToLower().CompareTo("PAL") ?? 1) == 0) ? 50 : 60;
				}
				else
                {
					systemState.SystemFPS = systemFPS;
                }
				
				UIRecalculateTimeLabels();
			}
		}



        protected override void FastUpdateBefore()
        {
			UpdateBefore();
		}



        protected override void UpdateBefore()
		{
			// Just don't bother if the joypad functions aren't going to work
			if (!IsSystemValid)
			{
				return;
			}

            // Change button states that are queued to be changed this frame
            if (frameButtonStates.TryGetValue(APIs.Emulation.FrameCount(), out Dictionary<string, bool> frameStateChange))
			{
				foreach (var state in frameStateChange)
                {
					pressedButtons[state.Key] = state.Value;
                }
			}

			APIs.Joypad.Set(pressedButtons, PadID);
		}



        protected override void FastUpdateAfter()
        {
			UpdateAfter();
		}



        protected override void UpdateAfter()
        {
			if (!IsSystemValid)
			{
				return;
			}

			int f = APIs.Emulation.FrameCount();
            frameButtonStates.Remove(f - 1);

			if (!ExecutingSequence() && queuedSequences.Count > 0)
            {
				PressButtons(queuedSequences.Dequeue(), f);
            }
		}



		private void UIRecalculateTimeLabels()
        {
			maximumActionTime_ValueChanged(null!, null!);
			holdFramesDefault_ValueChanged(null!, null!);
			pressFramesDefault_ValueChanged(null!, null!);
		}



        private void maximumActionTime_ValueChanged(object sender, EventArgs e)
        {
			systemState.MaxFrames = decimal.ToInt32(nud_maximumActionTime.Value);
			var ms = Utility.FramesToMilliseconds(systemState.MaxFrames, systemState.SystemFPS);
			timeLabelMaxActFrames.Text = $"= {ms}ms | {ms / MILLIS_PER_SEC}s";

			nud_holdFramesDefault.Maximum = nud_maximumActionTime.Value;
			nud_pressFramesDefault.Maximum = nud_maximumActionTime.Value;

			configFile.MaxActFrames = systemState.MaxFrames;
		}



        private void holdFramesDefault_ValueChanged(object sender, EventArgs e)
        {
			systemState.HoldFrames = decimal.ToInt32(nud_holdFramesDefault.Value);
			var ms = Utility.FramesToMilliseconds(systemState.HoldFrames, systemState.SystemFPS);
			timeLabelHoldFrames.Text = $"= {ms}ms | {ms / MILLIS_PER_SEC}s";

			configFile.HoldFrames = systemState.HoldFrames;
		}



        private void pressFramesDefault_ValueChanged(object sender, EventArgs e)
        {
			systemState.PressFrames = decimal.ToInt32(nud_pressFramesDefault.Value);
			var ms = Utility.FramesToMilliseconds(systemState.PressFrames, systemState.SystemFPS);
			timeLabelPressFrames.Text = $"= {ms}ms | {ms / MILLIS_PER_SEC}s";

			configFile.PressFrames = systemState.PressFrames;
		}



        private void nud_RepDelay_ValueChanged(object sender, EventArgs e)
        {
			systemState.DefaultRepetitionDelay = decimal.ToInt32(nud_RepDelay.Value);
			var ms = Utility.FramesToMilliseconds(systemState.DefaultRepetitionDelay, systemState.SystemFPS);
			timeLabelRepeitionDelay.Text = $"= {ms}ms | {ms / MILLIS_PER_SEC}s";

			configFile.RepetitionDelay = systemState.DefaultRepetitionDelay;
		}



        private void maximumRepititions_ValueChanged(object sender, EventArgs e)
        {
			systemState.MaxReps = decimal.ToInt32(nud_maximumRepititions.Value);
			configFile.MaxReps = systemState.MaxReps;
		}



        private void sequenceDelay_ValueChanged(object sender, EventArgs e)
        {
			systemState.DefaultSequenceDelay = decimal.ToInt32(nud_sequenceDelay.Value);
			configFile.SequenceDelay = systemState.DefaultSequenceDelay;
			var ms = Utility.FramesToMilliseconds(systemState.DefaultSequenceDelay, systemState.SystemFPS);
			timeLabelSequenceDelay.Text = $"= {ms}ms | {ms / MILLIS_PER_SEC}s";
		}



        private void button_Services_Click(object sender, EventArgs e)
        {
            servicesForm.Show();
        }



		/// <summary>
		/// Loads a json file and converts it into the given object
		/// </summary>
		/// <typeparam name="T">Type to convert to, must be creatable</typeparam>
		/// <param name="path">The path to the json file</param>
		/// <returns>The deserialized json as the object T</returns>
        public T LoadConfigFile<T>(string path) where T : new()
        {
			string text = string.Empty;

			Utility.WriteLine($"Loading Config File {path}");

            try
			{
                text = File.ReadAllText(path);
            }
            catch { }

            return JsonConvert.DeserializeObject<T>(text) ?? new T();
        }



        public void SaveConfigFile<T>(string path, T config) where T : class
        {
			var serializer = new JsonSerializer() { Formatting = Formatting.Indented };

            Utility.WriteLine($"Saving Config File {path}");

            try
			{
				using (TextWriter writer = new StreamWriter(path))
				{
					serializer.Serialize(writer, config);
				}
			}
			catch { }
        }



		/// <summary>
		/// Form Closing event, do any cleanup and saving here
		/// </summary>
        private void BizhawkRemotePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
			SaveConfigFile(ConfigFilePath, configFile);
        }
    }
}
