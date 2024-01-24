using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace BizhawkRemotePlay
{
    // Parses a string for control syntax, returning a dictionary of frame presses
    class StringDecoder
    {
        public const char REP_SPLIT_CHAR = '|';
        public const char REP_TIME_SPLIT_CHAR = '.';
        public const char BTN_HOLD_SPLIT_CHAR = ':';
        public const char BTN_SEQUENCE_SPLIT_CHAR = '-';

        private readonly Regex syntaxFixRegex = new Regex($@"\s|\{REP_SPLIT_CHAR}{{2,}}|\{REP_TIME_SPLIT_CHAR}{{2,}}|\{BTN_HOLD_SPLIT_CHAR}{{2,}}|\{BTN_SEQUENCE_SPLIT_CHAR}{{2,}}");
        private State state;

        private IReadOnlyDictionary<string, string> ButtonAliases = new Dictionary<string, string>()
        {
			// Main bindings
			{"up", "Up" },
            {"down", "Down" },
            {"left", "Left" },
            {"right", "Right" },
            {"a", "A" },
            {"b", "B" },
            {"c", "C" },
            {"x", "X" },
            {"y", "Y" },
            {"z", "Z" },
            {"lb", "L" },
            {"rb", "R" },
            {"start", "Start" },
            {"select", "Select" },
			// aliases
			{"u", "Up" },
            {"d", "Down" },
            {"do", "Down" },
            {"dw", "Down" },
            {"star", "Start" },
            {"st", "Start" },
            {"str", "Start" },
            {"sel", "Select" },
            {"sl", "Select" },
            {"l", "Left" },
            {"r", "right" },
            {"le", "Left" },
            {"lf", "Left" },
            {"lef", "Left" },
            {"ri", "Right" },
            {"rig", "Right" },
        };



        public StringDecoder(State systemState)
        {
            state = systemState;
        }



        /// <summary>
        /// Cleans up a string, removing whitespace
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private string SyntaxFixer(Match match)
        {
            char matchChar = match.Value[0];

            // delete whitespace
            if (matchChar == ' ' || matchChar == '\t' || matchChar == '\r' || matchChar == '\n')
            {
                return "";
            }

            return matchChar.ToString();
        }



        /// <summary>
        /// Parses a string formatted as a timespan = #...#[ms|s] into a number of frames for the current system
        /// </summary>
        /// <param name="timingString">formatted as a timespan = #...#[ms|s], defaults to seconds if not postfixed</param>
        /// <param name="frameDelay">output number of frames that the timing string is equal to</param>
        /// <returns></returns>
        private bool ParseTimings(string timingString, out uint frameDelay)
        {
            timingString = timingString.ToLower();

            if (timingString.EndsWith("ms"))
            {
                if (!uint.TryParse(timingString.Substring(0, timingString.Length - 2), out frameDelay))
                {
                    return false;
                }

                frameDelay = Utility.MillisecondsToFrames(frameDelay, state.SystemFPS);
            }
            else if (timingString.EndsWith("s"))
            {
                if (!uint.TryParse(timingString.Substring(0, timingString.Length - 1), out frameDelay))
                {
                    return false;
                }

                frameDelay = Utility.MillisecondsToFrames(frameDelay * Utility.MILLIS_PER_SECOND, state.SystemFPS);
            }
            else
            {
                if (!uint.TryParse(timingString, out frameDelay))
                {
                    return false;
                }
            }

            frameDelay = Math.Min(frameDelay, state.MaxFrames);

            return true;
        }



        /// <summary>
        /// Parses a string into 
        /// </summary>
        /// <param name="btnStr"></param>
        /// <returns></returns>
        private HashSet<ButtonCommand> ParseButtons(string btnStr)
        {
            // btnStr should have 0 or more ; separating each simultaneous press in this group
            var set = new HashSet<ButtonCommand>();
            var press = btnStr.Split(';');

            foreach (var btnInfo in press)
            {
                if (ParseButton(btnInfo, out ButtonCommand btnCmd))
                {
                    set.Add(btnCmd);
                }
            }
            return set;
        }



        private bool ParseRepetitions(string repStr, out Repetitions rep)
        {
            bool success;
            uint reps;
            uint repDelay = state.DefaultRepetitionDelay;
            var repsAndTimes = repStr.Split(REP_TIME_SPLIT_CHAR);

            // Parse the whole thing only if we can actually parse a number of reps from the string
            if (success = uint.TryParse(repsAndTimes[0], out reps))
            {
                // try and parse out some timings from the rest of the string, taking the first one found
                if (repsAndTimes.Length >= 2)
                {
                    if (!ParseTimings(repsAndTimes[1], out repDelay))
                        repDelay = state.DefaultRepetitionDelay;
                }
            }

            rep = new Repetitions(
                Math.Max(1, Math.Min(reps, state.MaxReps)),
                Math.Max(1, Math.Min(repDelay, state.MaxFrames))
            );

            return success;
        }



        private bool ParseButton(string btnStr, out ButtonCommand btnCmd)
        {
            Repetitions rep;

            uint duration = state.PressFrames;
            var btnAndReps = btnStr.Split(REP_SPLIT_CHAR);
            var btnAndTiming = btnAndReps[0].Split(BTN_HOLD_SPLIT_CHAR);
            string btnName = btnAndTiming[0];

            string revBtnName = btnName.ToLower();

            // Ensure that a valid key was pressed
            if (!ButtonAliases.ContainsKey(revBtnName))
            {
                btnCmd = new ButtonCommand();
                return false;
            }

            var realBtnName = ButtonAliases[revBtnName];

            // Ensure it also corresponds to the current system joypad
            if (!state.JoypadButtons.Contains(realBtnName))
            {
                btnCmd = new ButtonCommand();
                return false;
            }

            // Parse out the first repetition found, this accounts for extra repetitions in improperly formatted strings
            if (btnAndReps.Length >= 2)
            {
                ParseRepetitions(btnAndReps[1], out rep);
            }
            else
            {
                rep = new Repetitions(1, state.DefaultRepetitionDelay);
            }

            // We got hold timings as well
            if (btnAndTiming.Length >= 2)
            {
                ParseTimings(btnAndTiming[1], out duration);
            }
            // There were no timings attached, let's take account of captilization of the button name to set duration
            else
            {
                if (char.ToUpper(btnName[0]) == btnName[0])
                {
                    duration = state.HoldFrames;
                }
            }

            btnCmd = new ButtonCommand(realBtnName, duration, rep);
            return true;
        }



        public bool ValidateButtonString(string btns, out List<ButtonSequence> sequences)
        {
            btns = syntaxFixRegex.Replace(btns, SyntaxFixer);
            var sequenceGroups = btns.Split('-');
            sequences = new List<ButtonSequence>();

            var btnStr = sequenceGroups[0];

            sequences.Add(new ButtonSequence(0, ParseButtons(btnStr)));

            for (int i = 1; i < sequenceGroups.Length - 1; i += 2)
            {
                var timingStr = sequenceGroups[i];
                btnStr = sequenceGroups[i + 1];

                ParseTimings(timingStr, out uint frameDelay);

                sequences.Add(new ButtonSequence(frameDelay, ParseButtons(btnStr)));
            }

            return true;
        }
    }
}
