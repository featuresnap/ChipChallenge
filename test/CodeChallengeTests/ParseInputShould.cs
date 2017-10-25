using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static CodeChallenge.TextUtility;

namespace CodeChallengeTests
{
    public class ParseInputShould
    {

        [Theory,
         InlineData("Red,Green"),
         InlineData("Red, Green"),
         InlineData(" Red ,Green ")]
        public void ParseStartAndEndChipsFromFirstLine(string firstLine)
        {
            var lines = new[]
            {
                firstLine,
                "Misc, Junk"
            };

            var inputData = ParseInput(lines);
            Assert.Equal("Red", inputData.StartColor);
            Assert.Equal("Green", inputData.EndColor);
        }

        [Theory,
         InlineData("Red,Green", "Yellow, Blue"),
         InlineData("Red, Green", " Yellow, Blue")]
        public void ParseOtherChipsFromRemainingLines(string secondLine, string thirdLine)
        {
            var lines = new[]
            {
                "Misc, Junk",
                secondLine,
                thirdLine,
            };

            var inputData = ParseInput(lines);
            Assert.Equal(("Red", "Green"), inputData.Chips.First());
            Assert.Equal(("Yellow", "Blue"), inputData.Chips.Last());
        }


    }
}
