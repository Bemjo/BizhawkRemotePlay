using System;
using System.Collections.Generic;



namespace BizhawkRemotePlay
{
    public class RemotePlayConfig
    {
		public bool AutoLoginTwitch = false;
        public bool AutoLoginDiscord = false;
        public List<string> TwitchChannels = new List<string>();
        public List<string> DiscordChannels = new List<string>();

		public uint MaxActFrames = 4000;
		public uint HoldFrames = 60;
		public uint PressFrames = 10;
		public uint RepetitionDelay = 120;
		public uint MaxReps = 30;
		public uint SequenceDelay = 30;

		public bool ChaosMode = false;
		public bool QueueSequences = true;

		public string ClearCommand = "!rpclear";

        public string TwitchUsername = string.Empty;
        public string TwitchToken = string.Empty;
        public string DiscordToken = string.Empty;
    }



    public class State
	{
		public bool SupportsInput { get; set; }
		public uint MaxReps { get; set; }
		public uint MaxFrames { get; set; }
		public uint PressFrames { get; set; }
		public uint HoldFrames { get; set; }
		public uint DefaultRepetitionDelay { get; set; }
		public uint DefaultSequenceDelay { get; set; }
		public double SystemFPS { get; set; }

		private string _currentSystem;

		public string CurrentSystem
		{
			get { return _currentSystem; }
			set { _currentSystem = value; this.JoypadButtons = Utility.GetJoypadButtons(value); }
		}

		public HashSet<string> JoypadButtons { get; private set; }

		public State(
			bool supportsInput = false,
			uint maxReps = 10,
			uint maxFrames = 10,
			uint pressFrames = 4,
			uint holdFrames = 20,
			uint defaultRepetitionDelay = 30,
			uint defaultSequenceDelay = 30,
			uint systemFPS = 60,
			string system = ""
			)
		{
			this.SupportsInput = supportsInput;
			this.MaxReps = maxReps;
			this.MaxFrames = maxFrames;
			this.PressFrames = pressFrames;
			this.HoldFrames = holdFrames;
			this.DefaultRepetitionDelay = defaultRepetitionDelay;
			this.DefaultSequenceDelay = defaultSequenceDelay;
			this.SystemFPS = systemFPS;
			this._currentSystem = system;
			this.JoypadButtons = Utility.GetJoypadButtons(system);
		}
	}

	public readonly struct Repetitions
    {
		public uint Reps { get; }
		public uint Delay { get; }

		public Repetitions(uint reps, uint delay)
        {
			Reps = reps;
			Delay = delay;
        }
    }

	public readonly struct ButtonCommand : IComparable, IEquatable<ButtonCommand>
	{
		public Repetitions Reps { get; }
		public uint Duration { get; }
		public string Button { get; }

		public ButtonCommand(string button, uint duration, Repetitions reps)
		{
			Button = button;
			Duration = duration;
			Reps = reps;
		}

		public int CompareTo(object obj)
        {
			if (obj == null)
				return 1;

			ButtonCommand otherButton = (ButtonCommand)obj;
			return Button.CompareTo(otherButton.Button);
		}

		public override bool Equals(object obj)
        {
			return Equals((ButtonCommand)obj);
        }

		public override int GetHashCode()
        {
			return Button.GetHashCode();
        }

        public bool Equals(ButtonCommand other)
        {
			return Button.Equals(other.Button);
        }
    }

	public readonly struct ButtonSequence
	{
		public uint CommandDelay { get; }
		public HashSet<ButtonCommand> Buttons { get; }

		public ButtonSequence(uint delay, HashSet<ButtonCommand> btns)
		{
			CommandDelay = delay;
			Buttons = btns;
		}
	}
}
