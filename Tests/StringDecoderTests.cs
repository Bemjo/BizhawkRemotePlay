using BizhawkRemotePlay;
using Xunit.Abstractions;



namespace Tests
{
    public class StringDecoderTests
    {
        protected State state;
        protected StringDecoder decoder;
        private readonly ITestOutputHelper output;

        private const int systemFPS = 60;
        private const int pressFrames = 5;
        private const int holdFrames = 10;
        private const int repDelay = 5;
        private const int maxReps = 60;

        public StringDecoderTests(ITestOutputHelper output)
        {
            this.output = output;
            state = new State
            {
                System = "test",
                SystemFPS = systemFPS,
                PressFrames = pressFrames,
                HoldFrames = holdFrames,
                MaxReps = maxReps,
                DefaultRepetitionDelay = repDelay,
                JoypadButtons = new HashSet<string> { "A", "L1", "Start" },
                ButtonAliases = new Dictionary<string, string>
                {
                    { "a", "A" },
                    { "l", "L1" },
                    { "s", "Start" },
                    { "start", "Start" }
                }
            };

            decoder = new StringDecoder(state);

            this.output.WriteLine("*** Test System Settings ***");
            this.output.WriteLine(state.ToString());
        }



        /// <summary>
        /// Decodes the button string, assserting that is is valid
        /// Asserts the parsed sequences match the expected parameters provided
        /// </summary>
        /// <param name="buttons">The raw button string</param>
        /// <param name="seqCount">The expected number of sequences</param>
        /// <param name="seqDelays">The array of expected delays for each sequence in expected order</param>
        /// <param name="expButtons">The concatenated expected array of sequence buttons in order.</param>
        /// <param name="expDurs">The concatenated expected array of sequence button durations in order.</param>
        /// <param name="expReps">The concatenated expected array of sequence button repetition counts in order.</param>
        /// <param name="expRepDelays">The concatenated expected array of sequence repetition delays in order.</param>
        private void TestSequenceCommand(string buttons, int[] seqDelays, string[][] expButtons, int[][] expDurs, int[][] expReps, int[][] expRepDelays)
        {
            bool isValid = decoder.ValidateButtonString(buttons, out List<ButtonSequence> sequences);

            Assert.True(isValid, $"Button string [{buttons}] should be valid");

            // Assert we have the expected number of sequences
            Assert.NotNull(sequences);
            Assert.Equal(seqDelays.Length, sequences.Count);

            int seqI = 0;

            // Go through our parsed sequences and validate them
            foreach (var sequence in sequences)
            {
                // Assert it parsed the correct number of button commands
                Assert.NotNull(sequence.Buttons);
                Assert.Equal(seqDelays[seqI], sequence.CommandDelay);

                string[] expBtns = expButtons[seqI];

                Assert.Equal(expBtns.Length, sequence.Buttons.Count);

                // Go through each of our expected buttons, we'll search the parsed command set for this every button 
                // and assert that this command set has the expected button with it's expected properties
                for (int i = 0; i < expBtns.Length; ++i)
                {
                    string btn = expBtns[i];
                    int dur = expDurs[seqI][i];
                    int reps = expReps[seqI][i];
                    int repDelay = expRepDelays[seqI][i];

                    ButtonCommand? found = null;

                    // We have an expected button, search the commands for this button
                    // and assert it's properties match what we expect
                    foreach (ButtonCommand cmd in sequence.Buttons)
                    {
                        Assert.Contains(cmd.Button, state.JoypadButtons);

                        if (cmd.Button.Equals(btn))
                        {
                            found = cmd;
                            Assert.Equal(dur, cmd.Duration);
                            Assert.Equal(reps, cmd.Reps.Reps);
                            Assert.Equal(repDelay, cmd.Reps.Delay);
                            break;
                        }
                    }

                    // We expected a button, and we found it
                    Assert.NotNull(found);
                }

                seqI += 1;
            }
        }



        [Theory]
        [InlineData("", false)]
        [InlineData("-", false)]
        [InlineData("-2-", false)]
        [InlineData(".", false)]
        [InlineData(",", false)]
        [InlineData("|", false)]
        [InlineData(";", false)]
        [InlineData("😀", false)]
        [InlineData("♣56☻2♣5♣5§12§12♠65", false)]
        [InlineData(";asd':123|0hasd", false)]
        [InlineData("b", false)]
        [InlineData("star", false)]
        [InlineData("\n", false)]
        [InlineData("\0", false)]
        [InlineData("!a", false)]
        [InlineData("-a", false)]
        [InlineData("-5-", false)]
        [InlineData(" a ", true, new [] { 0 }, new [] {"A"}, new [] {pressFrames}, new [] { 1 }, new [] { repDelay })]
        [InlineData("a", true, new [] { 0 }, new [] {"A"}, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("A", true, new [] { 0 }, new [] {"A"}, new [] { holdFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("l", true, new [] { 0 }, new [] {"L1"}, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("s", true, new [] { 0 }, new [] {"Start"}, new []{ pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("start", true, new [] { 0 }, new [] {"Start"}, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("Start", true, new [] { 0 }, new [] {"Start"}, new [] { holdFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a;b", true, new [] { 0 }, new[] { "A" }, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a;a;a;a", true, new [] { 0 }, new[] { "A" }, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a;b;l;s", true, new [] { 0 }, new[] { "A", "L1", "Start" }, new [] { pressFrames, pressFrames, pressFrames }, new [] { 1, 1, 1 }, new [] { repDelay, repDelay, repDelay })]
        [InlineData("a:7", true, new [] { 0 }, new [] { "A" }, new [] { 7 }, new [] { 1 }, new [] { repDelay })]
        [InlineData("A:6", true, new [] { 0 }, new [] { "A" }, new [] { 6 }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a:500ms", true, new [] { 0 }, new [] { "A" }, new [] { systemFPS / 2 }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a:3s", true, new [] { 0 }, new [] { "A" }, new [] { systemFPS * 3 }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a:-5", true, new [] { 0 }, new [] { "A" }, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a:b", true, new [] { 0 }, new [] { "A" }, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a:", true, new [] { 0 }, new [] { "A" }, new [] { pressFrames }, new [] { 1 }, new [] { repDelay })]
        [InlineData("a|2", true, new [] { 0 }, new [] { "A" }, new [] { pressFrames }, new [] { 2 }, new [] { repDelay })]
        [InlineData("a|3.2", true, new [] { 0 }, new [] { "A" }, new [] { pressFrames }, new [] { 3 }, new [] { 2 })]
        [InlineData("a|3.2;b:10s|5.4", true, new [] { 0 }, new[] { "A" }, new [] { pressFrames }, new [] { 3 }, new [] { 2 })]
        [InlineData("a|3.2;l:10s|5.4", true, new [] { 0 }, new[] { "A", "L1" }, new [] { pressFrames, 10 * systemFPS }, new [] { 3, 5 }, new [] { 2, 4 })]
        public void CommandStrings(string buttons, bool expectValid, int[]? seqDelays = null, string[]? expButtons = null, int[]? expDurs = null, int[]? expReps = null, int[]? expRepDelays = null)
        {
            if (expectValid)
            {
                if (seqDelays == null || seqDelays.Length < 1)
                {
                    throw new ArgumentNullException(nameof(seqDelays), "You must provide an array of expected sequence delays for this test!");
                }

                if (expButtons == null || expButtons.Length < 1)
                {
                    throw new ArgumentNullException(nameof(expButtons), "You must provide an array of expected buttons for this test!");
                }

                if (expDurs == null || expDurs.Length < 1)
                {
                    throw new ArgumentNullException(nameof(expDurs), "You must provide an array of expected button durations for this test!");
                }

                if (expReps == null || expReps.Length < 1)
                {
                    throw new ArgumentNullException(nameof(expReps), "You must provide an array of expected repetitions for this test!");
                }

                if (expRepDelays == null || expRepDelays.Length < 1)
                {
                    throw new ArgumentNullException(nameof(expRepDelays), "You must provide an array of expected repetition delays for this test!");
                }

                TestSequenceCommand(buttons, seqDelays, [expButtons], [expDurs], [expReps], [expRepDelays]);
            }
            else
            {
                Assert.False(decoder.ValidateButtonString(buttons, out _), $"Button string [{buttons}] should be invalid");
            }
        }



        [Fact]
        public void SequenceStrings()
        {
            (string, bool, int[], string[][], int[][], int[][], int[][])[] testData =
            {
                ("a|3.2-42-l:10s|5.4", true, [0, 42], [["A"], ["L1"]], [[pressFrames], [10 * systemFPS]], [[3], [5]], [[2], [4]]),
                ("a|3.2-42-", false, [], [[]], [[]], [[]], [[]]),
                ("-42-a|3.2", false, [], [[]], [[]], [[]], [[]]),
            };

            foreach ((string buttons, bool valid, int[] seqDelays, string[][] expButtons, int[][] expDurs, int[][] expReps, int[][] expRepDelays) in testData)
            {
                if (valid)
                {
                    TestSequenceCommand(buttons, seqDelays, expButtons, expDurs, expReps, expRepDelays);
                }
                else
                {
                    Assert.False(decoder.ValidateButtonString(buttons, out var _), $"Button string [{buttons}] should be invalid");
                }
            }
        }
    }
}