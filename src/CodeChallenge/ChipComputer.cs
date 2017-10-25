using Chip=System.ValueTuple<string,string>;

namespace CodeChallenge
{
    public class ChipComputer
    {
        private PermutationStrategy<Chip> _permutationStrategy;

        public ChipComputer(PermutationStrategy<Chip> permutationStrategy)
        {
            _permutationStrategy = permutationStrategy;
        }
    }
}