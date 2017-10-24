using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge
{
    public class Permutation
    {
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> input)
        {
            if(input.Count() == 0) return new List<T[]> { new T[]{}};
            if(input.Count() == 1) return new List<T[]> {new[]{input.First()}};
            return from v in input
                let others = input.ExceptThis(v)
                from otherPermutation in Permute<T>(others)
                select otherPermutation.Prepend(v);
        }

    }

    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> ExceptThis<T>(this IEnumerable<T> values, T value)
        {
            return values.Except(new[] {value});
        }
    }
}
