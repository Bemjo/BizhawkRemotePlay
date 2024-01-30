using System;
using System.Collections.Generic;
using System.Linq;
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

        private const string DEFAULT_SYSTEM_KEY = "default";

        private readonly Regex syntaxFixRegex = new Regex($@"\s|\{REP_SPLIT_CHAR}{{2,}}|\{REP_TIME_SPLIT_CHAR}{{2,}}|\{BTN_HOLD_SPLIT_CHAR}{{2,}}|\{BTN_SEQUENCE_SPLIT_CHAR}{{2,}}");
        private State state;

        private IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> systemButtonAliases = new Dictionary<string, IReadOnlyDictionary<string, string>> {

            { "N64", new Dictionary<string, string>{
                {"up", "A Up" },
                {"down", "A Down" },
                {"left", "A Left" },
                {"right", "A Right" },
                {"u", "A Up" },
                {"d", "A Down" },
                {"l", "A Left" },
                {"r", "A Right" },
                {"do", "A Down" },
                {"le", "A Left" },
                {"ri", "A Right" },
                {"dup", "DPad Up" },
                {"ddown", "DPad Down" },
                {"dleft", "DPad Left" },
                {"dright", "DPad Right" },
                {"du", "DPad Up" },
                {"dd", "DPad Down" },
                {"dl", "DPad Left" },
                {"dr", "DPad Right" },
                {"cup", "C Up" },
                {"cdown", "C Down" },
                {"cleft", "C Left" },
                {"cright", "C Right" },
                {"cu", "C Up" },
                {"cd", "C Down" },
                {"cl", "C Left" },
                {"cr", "C Right" },
                {"start", "Start" },
                {"st", "Start" },
                {"sta", "Start" },
                {"a", "A" },
                {"b", "B" },
                {"z", "Z" },
                {"lb", "L" },
                {"rb", "R" },
                {"l1", "L" },
                {"r1", "R" },
            }},
            { "PSX", new Dictionary<string, string>{
                {"up", "Up" },
                {"down", "Down" },
                {"left", "Left" },
                {"right", "Right" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
                {"dup", "D-Pad Up" },
                {"ddown", "D-Pad Down" },
                {"dleft", "D-Pad Left" },
                {"dright", "D-Pad Right" },
                {"du", "D-Pad Up" },
                {"dd", "D-Pad Down" },
                {"dl", "D-Pad Left" },
                {"dr", "D-Pad Right" },
                {"x", "X" },
                {"ex", "X" },
                {"△", "△" },
                {"□", "□" },
                {"○", "○" },
                {"o", "○" },
                {"t", "△" },
                {"s", "□" },
                {"c", "○" },
                {"tr", "△" },
                {"sq", "□" },
                {"ci", "○" },
                {"tri", "△" },
                {"squ", "□" },
                {"cir", "○" },
                {"lb", "L1" },
                {"rb", "R1" },
                {"l1", "L1" },
                {"r1", "R1" },
                {"l2", "L2" },
                {"r2", "R2" },
                {"lt", "L2" },
                {"rt", "R2" },
                {"l3", "Left Stick" },
                {"r3", "Right Stick" },
                {"start", "Start" },
                {"select", "Select" },
                {"st", "Start" },
                {"se", "Select" },
                {"sta", "Start" },
                {"sel", "Select" },
            }},
            { "SNES", new Dictionary<string, string>{
                {"up", "Up" },
                {"down", "Down" },
                {"left", "Left" },
                {"right", "Right" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
                {"start", "Start" },
                {"select", "Select" },
                {"st", "Start" },
                {"se", "Select" },
                {"sta", "Start" },
                {"sel", "Select" },
                {"a", "A" },
                {"b", "B" },
                {"x", "X" },
                {"y", "Y" },
                {"lb", "L" },
                {"rb", "R" },
                {"l1", "L" },
                {"r1", "R" },
            }},
            { "GBA", new Dictionary<string, string>{
                {"up", "Up" },
                {"down", "Down" },
                {"left", "Left" },
                {"right", "Right" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
                {"start", "Start" },
                {"select", "Select" },
                {"st", "Start" },
                {"se", "Select" },
                {"sta", "Start" },
                {"sel", "Select" },
                {"a", "A" },
                {"b", "B" },
                {"lb", "L" },
                {"rb", "R" },
                {"l1", "L" },
                {"r1", "R" },
            }},
            { "GBC", new Dictionary<string, string>{
                {"up", "Up" },
                {"down", "Down" },
                {"left", "Left" },
                {"right", "Right" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
                {"start", "Start" },
                {"select", "Select" },
                {"st", "Start" },
                {"se", "Select" },
                {"sta", "Start" },
                {"sel", "Select" },
                {"a", "A" },
                {"b", "B" },
            }},
            { "GB",new Dictionary<string, string>{
                {"up", "Up" },
                {"down", "Down" },
                {"left", "Left" },
                {"right", "Right" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
                {"start", "Start" },
                {"select", "Select" },
                {"st", "Start" },
                {"se", "Select" },
                {"sta", "Start" },
                {"sel", "Select" },
                {"a", "A" },
                {"b", "B" },
            }},
            { "NES",new Dictionary<string, string>{
                {"up", "Up" },
                {"down", "Down" },
                {"left", "Left" },
                {"right", "Right" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
                {"start", "Start" },
                {"select", "Select" },
                {"st", "Start" },
                {"se", "Select" },
                {"sta", "Start" },
                {"sel", "Select" },
                {"a", "A" },
                {"b", "B" },
            }},
            { DEFAULT_SYSTEM_KEY, new Dictionary<string, string>{
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
                {"l1", "L" },
                {"r1", "R" },
                {"start", "Start" },
                {"select", "Select" },
			    // aliases
                {"star", "Start" },
                {"st", "Start" },
                {"sta", "Start" },
                {"str", "Start" },
                {"sel", "Select" },
                {"sl", "Select" },
                {"u", "Up" },
                {"d", "Down" },
                {"do", "Down" },
                {"dw", "Down" },
                {"l", "Left" },
                {"r", "right" },
                {"le", "Left" },
                {"lf", "Left" },
                {"lef", "Left" },
                {"ri", "Right" },
                {"rig", "Right" },
            }},
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
        private bool ParseTimings(string timingString, out int frameDelay)
        {
            timingString = timingString.ToLower();

            if (timingString.EndsWith("ms"))
            {
                if (!int.TryParse(timingString.Substring(0, timingString.Length - 2), out frameDelay))
                {
                    return false;
                }

                frameDelay = Utility.MillisecondsToFrames(frameDelay, state.SystemFPS);
            }
            else if (timingString.EndsWith("s"))
            {
                if (!int.TryParse(timingString.Substring(0, timingString.Length - 1), out frameDelay))
                {
                    return false;
                }

                frameDelay = Utility.MillisecondsToFrames(frameDelay * Utility.MILLIS_PER_SECOND, state.SystemFPS);
            }
            else
            {
                if (!int.TryParse(timingString, out frameDelay))
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
            int reps;
            int repDelay = state.DefaultRepetitionDelay;
            var repsAndTimes = repStr.Split(REP_TIME_SPLIT_CHAR);

            // Parse the whole thing only if we can actually parse a number of reps from the string
            if (success = int.TryParse(repsAndTimes[0], out reps))
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


        /// <summary>
        /// Parses a button press, and it's command data. Ensures the button is a valid button on the console.
        /// </summary>
        /// <param name="btnStr"></param>
        /// <param name="btnCmd"></param>
        /// <returns>True if the button command string is valid. False otherwise.</returns>
        private bool ParseButton(string btnStr, out ButtonCommand btnCmd)
        {
            Repetitions rep;
            int duration = state.PressFrames;
            var btnAndReps = btnStr.Split(REP_SPLIT_CHAR);
            var btnAndTiming = btnAndReps[0].Split(BTN_HOLD_SPLIT_CHAR);
            string btnName = btnAndTiming[0];
            string revBtnName = btnName.ToLower();

            // Get our list of system specific aliases if defined
            if (!systemButtonAliases.TryGetValue(state.System, out IReadOnlyDictionary<string, string> aliases))
            {
                aliases = systemButtonAliases[DEFAULT_SYSTEM_KEY];
            }

            string realBtnName = revBtnName;

            // map the user input to a valid key if possible
            if (aliases.ContainsKey(revBtnName))
            {
                realBtnName = aliases[revBtnName];
            }

            // Find our button in the list of the valid joypad buttons, ignoring case incase we couldn't find an alias entry
            IList<string> joyBtn = state.JoypadButtons.Where(
                o => {
                    return o.Equals(realBtnName, StringComparison.InvariantCultureIgnoreCase);
                }
            ).ToList();

            if (joyBtn.Count() <= 0 )
            {
                btnCmd = new ButtonCommand();
                return false;
            }

            // Get the joypad entry for this button name, to correct for our ignoring case for missing aliases
            realBtnName = joyBtn.ElementAt(0);

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

                ParseTimings(timingStr, out int frameDelay);

                sequences.Add(new ButtonSequence(frameDelay, ParseButtons(btnStr)));
            }

            return true;
        }
    }
}
