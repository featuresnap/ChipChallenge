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

        [Fact]
        public void ReportNoResultWhenNoResultFound()
        {
            var permutation = new FakePermutationStrategy(_ => new List<IEnumerable<Chip>> { new Chip[] { } });

            var computer = new ChipComputer(permutation);
            var result = computer.Check(
                "White",
                "Yellow",
                new[] { ("Red", "Green"), ("Blue", "Purple") });

            Assert.Collection(result, firstLine => Assert.Equal(ChipComputer.NO_RESULT, firstLine));
        }

        [Fact]
        public void ReportMatch()
        {
            var permutation = new FakePermutationStrategy(_ => new List<IEnumerable<Chip>> { new[] { ("Green", "Blue") } });

            var computer = new ChipComputer(permutation);
            var result = computer.Check(
                "Green",
                "Blue",
                new[] { ("Green", "Blue")});

            Assert.Collection(result, firstLine => Assert.Equal("Green, Blue", firstLine));
        }



    }

    internal class FakePermutationStrategy : PermutationStrategy<Chip>
    {
        private Func<IEnumerable<(string, string)>, IEnumerable<IEnumerable<(string, string)>>> _fakeBehavior;

        public FakePermutationStrategy(Func<IEnumerable<Chip>, IEnumerable<IEnumerable<Chip>>> fakeBehavior)
        {
            _fakeBehavior = fakeBehavior;
        }

        public IEnumerable<IEnumerable<Chip>> Permute(IEnumerable<Chip> input)
        {
            return _fakeBehavior(input);
        }
    }

}
