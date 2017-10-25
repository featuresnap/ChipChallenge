using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge
{
    public interface PermutationStrategy<T>
    {
        IEnumerable<IEnumerable<T>> Permute(IEnumerable<T> input);
    }

    public class DefaultPermutationStrategy<T> : PermutationStrategy<T>
    {
        public IEnumerable<IEnumerable<T>> Permute(IEnumerable<T> input)
        {
            if(input.Count() == 0) return new List<T[]> { new T[]{}};
            if(input.Count() == 1) return new List<T[]> {new[]{input.First()}};
            return from v in input
                let rest = input.ExceptOne(v)
                from otherPermutation in Permute(rest)
                select otherPermutation.Prepend(v);
        }

    }

    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> ExceptOne<T>(this IEnumerable<T> values, T value)
        {
            return values.Except(new[] {value});
        }
    }
}
