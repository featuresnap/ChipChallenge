using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodeChallenge
{
    public static class TextUtility
    {
        public static InputData ParseInput(IEnumerable<string> input)
        {
            var firstLine = ProcessLine(input.First());
            var otherLines =
                input
                    .Skip(1)
                    .Select(ProcessLine);

            return new InputData(firstLine.Item1, firstLine.Item2, otherLines);
        }

        private static (string, string) ProcessLine(string line)
        {
            var colors = line
                .Split(',')
                .Select(c=> c.Trim())
                .ToArray();

            return (colors.First(), colors.Last());

        }
    }
}
