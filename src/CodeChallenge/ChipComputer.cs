using System;
using System.Collections.Generic;
using System.Linq;
using Chip = System.ValueTuple<string, string>;

namespace CodeChallenge
{
    public class ChipComputer
    {
        public const string NO_RESULT = "No result found";

        private PermutationStrategy<Chip> _permutationStrategy;
        private string DUMMY = "DUMMY";

        public ChipComputer(PermutationStrategy<Chip> permutationStrategy)
        {
            _permutationStrategy = permutationStrategy;
        }

        public IEnumerable<string> Check(string startColor, string endColor, IEnumerable<Chip> chips)
        {
            bool isMatch(IEnumerable<Chip> trialSequence) => Match(startColor, endColor, trialSequence);

            var trialSequences = _permutationStrategy.Permute(chips);
            var firstSolution = trialSequences.FirstOrDefault(isMatch);

            if (firstSolution != null)
            {
                return firstSolution.Select(x=> x.Item1 + ", " + x.Item2);
            }

            return new[] {NO_RESULT};

        }

        private bool Match(string startColor, string endColor, IEnumerable<Chip> chips)
        {
            bool localMatch(Chip first, Chip next) => first.Item2 == next.Item1;

            var startChip = (DUMMY, startColor);
            var endChip = (endColor, DUMMY);
            var pairMatchResults = chips.Prepend(startChip).Zip(chips.Append(endChip), localMatch);
            return pairMatchResults.All(x => x == true);
        }
    }
}