using System;
using System.Collections.Generic;

namespace BizhawkRemotePlay
{
    public static class Utility
    {
		public static HashSet<string> GetJoypadButtons(string system)
		{
			switch (system)
			{
				case "NES":
					return new HashSet<string>()
					{
						{"A"},
						{"B"},
						{"Up"},
						{"Down"},
						{"Left"},
						{"Right"},
						{"Start"},
						{"Select"},
					};

				case "SNES":
					return new HashSet<string>()
					{
						{"A"},
						{"B"},
						{"X"},
						{"Y"},
						{"L"},
						{"R"},
						{"Up"},
						{"Down"},
						{"Left"},
						{"Right"},
						{"Start"},
						{"Select"},
					};

                case "PSX":
                    return new HashSet<string>()
                    {
                        {"△"},
                        {"X"},
                        {"□"},
                        {"○"},
                        {"L1"},
                        {"R1"},
                        {"L2"},
                        {"R2"},
                        {"Up"},
                        {"Down"},
                        {"Left"},
                        {"Right"},
                        {"D-Pad Up"},
                        {"D-Pad Down"},
                        {"D-Pad Left"},
                        {"D-Pad Right"},
                        {"Start"},
                        {"Select"},
                        {"Leftstick Up"},
                        {"Leftstick Down"},
                        {"Leftstick Left"},
                        {"Leftstick Right"},
                        {"Rightstick Up"},
                        {"Rightstick Down"},
                        {"Rightstick Left"},
                        {"Rightstick Right"},
                    };

                case "GB":
				case "GBC":
					return new HashSet<string>()
					{
						{"A"},
						{"B"},
						{"Up"},
						{"Down"},
						{"Left"},
						{"Right"},
						{"Start"},
						{"Select"},
					};
			}

			return new HashSet<string>();
		}



		public static Dictionary<string, bool> CreateSystemJoypad(string system)
		{
			switch (system)
			{
				case "NES":
					return new Dictionary<string, bool>()
					{
						{"A", false},
						{"B", false},
						{"Up", false},
						{"Down", false},
						{"Left", false},
						{"Right", false},
						{"Start", false},
						{"Select", false},
					};

				case "SNES":
					return new Dictionary<string, bool>()
					{
						{"A", false},
						{"B", false},
						{"X", false},
						{"Y", false},
						{"L", false},
						{"R", false},
						{"Up", false},
						{"Down", false},
						{"Left", false},
						{"Right", false},
						{"Start", false},
						{"Select", false},
					};

				case "PSX":
                    return new Dictionary<string, bool>()
                    {
                        {"△", false},
                        {"X", false},
                        {"□", false},
                        {"○", false},
                        {"L1", false},
                        {"R1", false},
                        {"L2", false},
                        {"R2", false},
                        {"Up", false},
                        {"Down", false},
                        {"Left", false},
                        {"Right", false},
                        {"D-Pad Up", false},
                        {"D-Pad Down", false},
                        {"D-Pad Left", false},
                        {"D-Pad Right", false},
                        {"Start", false},
                        {"Select", false},
                        {"Leftstick Up", false},
                        {"Leftstick Down", false},
                        {"Leftstick Left", false},
                        {"Leftstick Right", false},
                        {"Rightstick Up", false},
                        {"Rightstick Down", false},
                        {"Rightstick Left", false},
                        {"Rightstick Right", false},
                    };


                case "GB":
				case "GBC":
					return new Dictionary<string, bool>()
					{
						{"A", false},
						{"B", false},
						{"Up", false},
						{"Down", false},
						{"Left", false},
						{"Right", false},
						{"Start", false},
						{"Select", false},
					};
			}

			return new Dictionary<string, bool>();
		}



		public const uint MILLIS_PER_SECOND = 1000;
        public const double FMILLIS_PER_SECOND = 1000;



        public static double FramesToMilliseconds(uint frameCount, double fps)
        {
            return Math.Round((frameCount / fps) * FMILLIS_PER_SECOND);
        }

        public static uint MillisecondsToFrames(uint milliseconds, double fps)
        {
            return (uint)Math.Round((milliseconds / FMILLIS_PER_SECOND) * fps);
        }

        private static string FormatMsg(string msg)
        {
            return $"[RemotePlay] {DateTime.UtcNow}: {msg}";
        }


        public static void WriteLine(string msg)
        {
            Console.WriteLine(FormatMsg(msg));
        }

        public static void Write(string msg)
        {
            Console.Write(FormatMsg(msg));
        }
    }
}