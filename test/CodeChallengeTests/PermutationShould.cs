using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CodeChallenge;

namespace CodeChallengeTests
{
    public class PermutationShould
    {
        [Fact]
        public void PermuteForEmptyInput()
        {
            var input = new List<int>();
            var output = Permutation.Permute(input);
            Assert.Collection(output, (x => Assert.Equal(0, x.Count())));
        }

        [Fact]
        public void PermuteForSingleElement()
        {
            var input = new List<int>() { 1 };
            var output = Permutation.Permute(input);
            Assert.Collection(output, x => Assert.Equal(1, x.Single()));
        }

        [Fact]
        public void PermuteTwoElements()
        {
            var input = new List<int> { 1, 2 };
            var output = Permutation.Permute(input);
            Assert.Equal(2, output.Count());
        }

        [Fact]
        public void PermuteThreeElements()
        {
            var input = new List<int> { 1, 2, 3 };
            var output = Permutation.Permute(input);
            Assert.Equal(6, output.Count());
        }

        [Fact]
        public void PlaceEachElementInEachPermutation()
        {
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var output = Permutation.Permute(input);
            foreach (var perm in output)
            {
                foreach (var element in input)
                {
                    Assert.Contains(element, perm);
                }
            }
        }

        [Fact]
        public void PlaceEachElementFirstAsManyTimesAsSizeOfInput()
        {
            var input = new List<int> { 1, 2, 3, 4, 5 };
            var expectedElementCount = input.Count;
            var output = Permutation.Permute(input);
            foreach (var element in input)
            {
               Assert.Equal(expectedElementCount, output.Count(perm => perm.First() == element));
            }

        }

    }
}
