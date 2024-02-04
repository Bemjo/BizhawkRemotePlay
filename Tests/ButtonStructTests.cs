using BizhawkRemotePlay;
using Xunit.Abstractions;



namespace Tests
{
    public class ButtonStructTests
    {
        [Fact]
        public void RepetitionsCompare()
        {
            (Repetitions, Repetitions, int)[] testData =
{
                (new Repetitions(0, 1), new Repetitions(1, 0), -1),
                (new Repetitions(1, 0), new Repetitions(0, 1), 1),
                (new Repetitions(1, 1), new Repetitions(1, 1), 0),
            };

            foreach ((Repetitions lhs, Repetitions rhs, int expectedCompare) in testData)
            {
                Assert.Equal(expectedCompare, lhs.CompareTo(rhs));
            }
        }



        [Fact]
        public void RepetitionsEquals()
        {
            (Repetitions, Repetitions, bool)[] testData =
            {
                (new Repetitions(0, 1), new Repetitions(1, 0), false),
                (new Repetitions(1, 0), new Repetitions(0, 1), false),
                (new Repetitions(1, 1), new Repetitions(1, 1), true),
            };

            foreach ((Repetitions lhs, Repetitions rhs, bool expectedEquals) in testData)
            {
                Assert.True(expectedEquals == lhs.Equals(rhs), $"Repetitions should {(expectedEquals ? "" : "not ")}be equal");
            }
        }



        [Fact]
        public void ButtonCommandEquals()
        {
            (ButtonCommand, ButtonCommand, bool)[] testData =
            {
                (new ButtonCommand("a", 0, new Repetitions()), new ButtonCommand("b", 0, new Repetitions()), false),
                (new ButtonCommand("a", 1, new Repetitions()), new ButtonCommand("a", 0, new Repetitions()), false),
                (new ButtonCommand("a", 0, new Repetitions(1, 0)), new ButtonCommand("a", 0, new Repetitions(0, 1)), false),
                (new ButtonCommand("a", 0, new Repetitions()), new ButtonCommand("a", 0, new Repetitions()), true),
            };

            foreach ((ButtonCommand lhs, ButtonCommand rhs, bool expectedEquals) in testData)
            {
                Assert.True(expectedEquals == lhs.Equals(rhs), $"ButtonCommand should {(expectedEquals ? "" : "not ")}be equal");
            }
        }



        [Fact]
        public void ButtonCommandCompare()
        {
            (ButtonCommand, ButtonCommand, int)[] testData =
            {
                (new ButtonCommand("a", 0, new Repetitions()), new ButtonCommand("b", 0, new Repetitions()), -1),
                (new ButtonCommand("b", 0, new Repetitions()), new ButtonCommand("a", 0, new Repetitions()), 1),
                (new ButtonCommand("a", 1, new Repetitions()), new ButtonCommand("a", 0, new Repetitions()), 1),
                (new ButtonCommand("a", 0, new Repetitions()), new ButtonCommand("a", 1, new Repetitions()), -1),
                (new ButtonCommand("a", 0, new Repetitions(1, 0)), new ButtonCommand("a", 0, new Repetitions(0, 1)), 1),
                (new ButtonCommand("a", 0, new Repetitions(0, 0)), new ButtonCommand("a", 0, new Repetitions(1, 1)), -1),
                (new ButtonCommand("a", 0, new Repetitions()), new ButtonCommand("a", 0, new Repetitions()), 0),
            };

            foreach ((ButtonCommand lhs, ButtonCommand rhs, int expectedCompare) in testData)
            {
                Assert.Equal(expectedCompare, lhs.CompareTo(rhs));
            }
        }



        [Fact]
        public void ButtonSequenceEquals()
        {
            (string, ButtonSequence, ButtonSequence, bool)[] testData =
            {
                ("Test 1 - Delay Unequal",
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                    })),
                    new ButtonSequence(1, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                    })),
                    false
                ),
                ("Test 2 - Button Commands Unequal Button",
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                    })),
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("b", 0, new Repetitions()),
                    })),
                    false
                ),
                ("Test 3 - Button Commands Unequal Count",
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                    })),
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                        new ButtonCommand("b", 0, new Repetitions()),
                    })),
                    false
                ),
                ("Test 4 - Button Commands Unequal Multi Buttons",
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                        new ButtonCommand("c", 0, new Repetitions()),
                    })),
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                        new ButtonCommand("b", 0, new Repetitions()),
                    })),
                    false
                ),
                ("Test 5 - Simple Equality",
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                    })),
                    new ButtonSequence(0, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                    })),
                    true
                ),
                ("Test 6 - Multi Button Equality",
                    new ButtonSequence(1, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                        new ButtonCommand("b", 0, new Repetitions()),
                        new ButtonCommand("c", 0, new Repetitions()),
                    })),
                    new ButtonSequence(1, new  HashSet<ButtonCommand>(new ButtonCommand[]{
                        new ButtonCommand("a", 0, new Repetitions()),
                        new ButtonCommand("b", 0, new Repetitions()),
                        new ButtonCommand("c", 0, new Repetitions()),
                    })),
                    true
                ),
            };

            foreach ((string testName, ButtonSequence lhs, ButtonSequence rhs, bool expectedEquals) in testData)
            {
                Assert.True(expectedEquals == lhs.Equals(rhs), $"{testName} : ButtonCommand should {(expectedEquals ? "" : "not ")}be equal");
            }
        }
    }
}
