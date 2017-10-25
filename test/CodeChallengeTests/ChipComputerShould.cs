using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using CodeChallenge;
using Chip = System.ValueTuple<string, string>;

namespace CodeChallengeTests
{
    public class ChipComputerShould
    {
        private FakePermutationStrategy _permutationStrategy;
        private ChipComputer _computer;

        public ChipComputerShould()
        {
            _permutationStrategy = new FakePermutationStrategy();
            _computer = new ChipComputer(_permutationStrategy);
        }

        [Fact]
        public void ReportNoResultWhenNoResultFound()
        {
            _permutationStrategy.ShouldReturn(new List<IEnumerable<Chip>> { new Chip[] { } });

            var result = _computer.Check(
                "White",
                "Yellow",
                new[] { ("Red", "Green"), ("Blue", "Purple") });

            Assert.Collection(result, firstLine => Assert.Equal(ChipComputer.NO_RESULT, firstLine));
        }

        [Fact]
        public void ReportMatchForSingleAvailableChipThatMatches()
        {
            _permutationStrategy.ShouldReturn(new List<IEnumerable<Chip>> { new[] { ("Green", "Blue") } });

            var result = _computer.Check(
                "Green",
                "Blue",
                new[] { ("Green", "Blue") });

            Assert.Collection(result, firstLine => Assert.Equal("Green, Blue", firstLine));
        }

        [Fact]
        public void ReportMatchWhenSomeChipMatches()
        {
            _permutationStrategy.ShouldReturn(new List<IEnumerable<Chip>>
            {
                new [] {("Yellow", "Green"), ("Red", "Yellow")},
                new [] {("Red", "Yellow"), ("Yellow", "Green")},
            });

            var result = _computer.Check(
                "Red",
                "Green",
                new[] { ("Yellow", "Green"), ("Red", "Yellow") });

            Assert.Collection(result, 
                firstLine => Assert.Equal("Red, Yellow", firstLine),
                secondLine => Assert.Equal("Yellow, Green", secondLine));

        }

    }

    internal class FakePermutationStrategy : PermutationStrategy<Chip>
    {
        private IEnumerable<IEnumerable<(string, string)>> _shouldReturn;

        public void ShouldReturn(IEnumerable<IEnumerable<Chip>> shouldReturn)
        {
            _shouldReturn = shouldReturn;
        }

        public IEnumerable<IEnumerable<Chip>> Permute(IEnumerable<Chip> input)
        {
            if (_shouldReturn == null) { throw new NotImplementedException(); }
            return _shouldReturn;
        }
    }

}
