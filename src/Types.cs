﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;



namespace BizhawkRemotePlay
{
    public class RemotePlayConfig
    {
        public char RepetitionSplitChar = '|';
        public char RepetitionDelayChar = '.';
        public char ButtonDurationChar = ':';
        public char ButtonSequenceChar = '-';

        public bool AutoLoginTwitch = false;
        public bool AutoLoginDiscord = false;
        public IList<string> TwitchChannels = new List<string>();
        public IList<string> DiscordChannels = new List<string>();
		public IDictionary<string, IDictionary<string, string>> Aliases = new Dictionary<string, IDictionary<string, string>>();

		public int MaxActFrames = 4000;
		public int HoldFrames = 120;
		public int PressFrames = 10;
		public int RepetitionDelay = 6;
		public int MaxReps = 60;
		public int SequenceDelay = 6;
		public int QueueSize = 10;

		public bool ChaosMode = true;
		public bool QueueSequences = false;

		public string ClearCommand = "!rpclear";

        public string TwitchUsername = string.Empty;
        public string TwitchToken = string.Empty;
        public string DiscordToken = string.Empty;
    }



    public class State
	{
		public int MaxReps { get; set; }
		public int MaxFrames { get; set; }
		public int PressFrames { get; set; }
		public int HoldFrames { get; set; }
		public int DefaultRepetitionDelay { get; set; }
		public int DefaultSequenceDelay { get; set; }
		public float SystemFPS { get; set; }
		public string System { get; set; }

		public IDictionary<string, string> ButtonAliases { get; set; } = new Dictionary<string, string>();

		public HashSet<string> JoypadButtons { get; set; } = new HashSet<string>();



		public State(
            int maxReps = 10,
			int maxFrames = 9001,
			int pressFrames = 4,
			int holdFrames = 20,
			int defaultRepetitionDelay = 30,
			int defaultSequenceDelay = 30,
			int systemFPS = 60,
			string system = ""
            )
		{
            MaxReps = maxReps;
			MaxFrames = maxFrames;
			PressFrames = pressFrames;
			HoldFrames = holdFrames;
			DefaultRepetitionDelay = defaultRepetitionDelay;
			DefaultSequenceDelay = defaultSequenceDelay;
			SystemFPS = systemFPS;
			System = system;
        }



		private Dictionary<string, string> BuildAliases(IDictionary<string, string> input, IDictionary<string, string>? userAliases, IDictionary<string, string[]> aliasRemap, IDictionary<string, int> minSubstrLengths)
		{
            Dictionary<string, string> output = new Dictionary<string, string>();

            foreach (var aliasKvp in input)
            {
                string strAlias = aliasKvp.Key;
                string[] foundAliases = new[] { strAlias };

                // Get our alias remap if we have one
                if (!(aliasRemap?.TryGetValue(strAlias, out foundAliases) ?? false))
                {
                    foundAliases = new[] { strAlias };
                }

                foreach (string fa in foundAliases)
                {
                    int i = 1;

                    if (!(minSubstrLengths?.TryGetValue(fa, out i) ?? false))
                    {
                        i = 1;
                    }

                    for (; i <= fa.Length; ++i)
                    {
                        string substr = fa.Substring(0, i);

                        if (!output.ContainsKey(substr))
                        {
                            try
                            {
                                output.Add(substr, aliasKvp.Value);
                            }
                            catch (ArgumentException ex)
                            {
                                Utility.WriteLine(ex);
                            }
                        }
                    }
                }
            }

            if (userAliases != null)
            {
                foreach (var alias in userAliases)
                {
                    if (!output.ContainsKey(alias.Key))
                    {
                        output.Add(alias.Key, alias.Value);
                    }
                }
            }

            return output;
        }



        public void RebuildAliases(IDictionary<string, string>? userAliases = null)
		{
            Regex allowList = new Regex(@"[△X□○]");
            Regex sanitizer = new Regex(@"\W");
            Dictionary<string, string> aliases = new Dictionary<string, string>();

            try
            {
                aliases = JoypadButtons.ToDictionary(
                    o =>
                    {
                        if (!allowList.Match(o).Success)
                        {
                            return sanitizer.Replace(o, "").ToLower(); ;
                        }
                        return o.ToLower();
                    },
                    o => o
                );
            }
            catch (ArgumentException)
            {
                Utility.WriteLine("Failed to auto-parse aliases from system controls. At least 2 of the controls are unique symbols that I cannot parse correctly. Please file an issue on the github repo with the name of the System you are trying to run");
                return;
            }

            ButtonAliases = BuildAliases(aliases, userAliases,
                new Dictionary<string, string[]>
                {
                    { "aup", new [] {"up"} },
                    { "adown", new [] {"down" } },
                    { "aleft", new [] {"left"} },
                    { "aright", new [] {"right"} },
                    { "dpadup", new[] { "dup" } },
                    { "dpaddown", new[] { "ddown" } },
                    { "dpadleft", new[] { "dleft" } },
                    { "dpadright", new[] { "dright" } },
                    { "dpadu", new[] { "dup" } },
                    { "dpadd", new[] { "ddown" } },
                    { "dpadl", new[] { "dleft" } },
                    { "dpadr", new[] { "dright" } },
                    { "l", new[] { "l1", "lb" } },
                    { "r", new[] { "r1", "rb" } },
                    { "△", new[] { "triangle" } },
                    { "□", new[] { "square" } },
                    { "○", new[] { "o", "circle" } },
                    //{ "X", new[] { "x" } },
                },
                new Dictionary<string, int>
                {
                    {"cup", 2},
                    {"cdown", 2},
                    {"cleft", 2},
                    {"cright", 2},
                    {"select", 2},
                    { "dpadup", 2},
                    { "dpaddown", 2},
                    { "dpadleft", 2},
                    { "dpadright", 2},
                    { "dpadu", 2},
                    { "dpadd", 2},
                    { "dpadl", 2},
                    { "dpadr", 2},
                }
            );
        }



        public override string ToString()
        {
			return	$"MaxReps: {MaxReps}\n" +
					$"MaxFrames {MaxFrames}\n" +
					$"PressFrames {PressFrames}\n" +
					$"HoldFrames {HoldFrames}\n" +
					$"DefaultRepetitionDelay {DefaultRepetitionDelay}\n" +
					$"DefaultSequenceDelay {DefaultSequenceDelay}\n" +
					$"SystemFPS {SystemFPS}\n" +
					$"System {System}";
        }
    }



    public readonly struct Repetitions : IEquatable<Repetitions>, IComparable
    {
		public readonly int Reps = 1;
		public readonly int Delay = 0;



        public Repetitions(int reps, int delay = 0)
        {
			Reps = reps;
			Delay = delay;
        }



		public int CompareTo(object obj)
		{
			int cmp = -1;
			if (obj is Repetitions rhs)
			{
				cmp = Reps.CompareTo(rhs.Reps);

				if (cmp == 0)
				{
					cmp = Delay.CompareTo(rhs.Delay);
                }
			}

			return cmp;
		}



        public bool Equals(Repetitions other)
        {
            return	Reps == other.Reps &&
					Delay == other.Delay;
        }
    }



	public readonly struct ButtonCommand : IComparable, IEquatable<ButtonCommand>
	{
		public readonly Repetitions Reps = new Repetitions();
		public readonly int Duration;
		public readonly string Button;



		public ButtonCommand(string button, int duration, Repetitions reps)
		{
			Button = button;
			Duration = duration;
			Reps = reps;
		}



        public int CompareTo(object obj)
        {
			int btnCmp = -1;

            if (obj is ButtonCommand otherButton)
			{
				btnCmp = Button.CompareTo(otherButton.Button);

                if (Button.CompareTo(otherButton.Button) == 0)
				{
                    btnCmp = Duration.CompareTo(otherButton.Duration);
					if (btnCmp == 0)
					{
                        btnCmp = Reps.CompareTo(otherButton.Reps);
                    }
                }

            }

			return btnCmp;
        }



        public bool Equals(ButtonCommand other)
        {
			return	Button.Equals(other.Button) &&
					Duration == other.Duration &&
					Reps.Equals(other.Reps);
        }
    }



	public readonly struct ButtonSequence : IEquatable<ButtonSequence>
    {
		public readonly int CommandDelay;
		public readonly HashSet<ButtonCommand> Buttons;



		public ButtonSequence(int delay, HashSet<ButtonCommand> btns)
		{
			CommandDelay = delay;
			Buttons = btns;
		}



        public bool Equals(ButtonSequence other)
        {
			return	CommandDelay == other.CommandDelay &&
					Buttons.Count == other.Buttons.Count &&
					Buttons.SetEquals(other.Buttons);
        }
    }
}
