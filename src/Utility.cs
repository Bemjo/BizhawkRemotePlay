using System;
using System.Collections.Generic;

namespace BizhawkRemotePlay
{
    public static class Utility
    {
		public const int MILLIS_PER_SECOND = 1000;
        public const float FMILLIS_PER_SECOND = 1000;

        public static float FramesToMilliseconds(int frameCount, float fps)
        {
            return (float)Math.Round((frameCount / fps) * FMILLIS_PER_SECOND);
        }

        public static int MillisecondsToFrames(int milliseconds, float fps)
        {
            return (int)Math.Round((milliseconds / FMILLIS_PER_SECOND) * fps);
        }

        private static string FormatMsg(string msg)
        {
            return $"[RemotePlay] {DateTime.UtcNow}: {msg}";
        }

        private static string FormatMsg(Exception ex)
        {
            return $"[RemotePlay] {DateTime.UtcNow}: {ex}";
        }

        public static void WriteLine(string msg)
        {
            Console.WriteLine(FormatMsg(msg));
        }

        public static void WriteLine(Exception ex)
        {
            Console.WriteLine(FormatMsg(ex));
        }

        public static void Write(string msg)
        {
            Console.Write(FormatMsg(msg));
        }
    }
}
