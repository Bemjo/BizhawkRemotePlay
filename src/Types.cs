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

		public int MaxActFrames = 4000;
		public int HoldFrames = 60;
		public int PressFrames = 10;
		public int RepetitionDelay = 120;
		public int MaxReps = 30;
		public int SequenceDelay = 30;
		public int QueueSize = 10;

		public bool ChaosMode = false;
		public bool QueueSequences = true;

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

		public HashSet<string> JoypadButtons { get; set; } = new HashSet<string>();

		public State(
			int maxReps = 10,
			int maxFrames = 10,
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
	}

	public readonly struct Repetitions
    {
		public int Reps { get; }
		public int Delay { get; }

		public Repetitions(int reps, int delay)
        {
			Reps = reps;
			Delay = delay;
        }
    }

	public readonly struct ButtonCommand : IComparable, IEquatable<ButtonCommand>
	{
		public Repetitions Reps { get; }
		public int Duration { get; }
		public string Button { get; }

		public ButtonCommand(string button, int duration, Repetitions reps)
		{
			Button = button;
			Duration = duration;
			Reps = reps;
		}

		public int CompareTo(object obj)
        {
			if (obj == null)
			{
				return -1;
			}

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
		public int CommandDelay { get; }
		public HashSet<ButtonCommand> Buttons { get; }

		public ButtonSequence(int delay, HashSet<ButtonCommand> btns)
		{
			CommandDelay = delay;
			Buttons = btns;
		}
	}
}
