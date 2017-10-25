using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CodeChallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            MainLoop();
        }

        private static void MainLoop()
        {
            while (true)
            {
                Console.WriteLine("Enter input. After all input data is complete, press <ENTER> to solve.");
                Console.WriteLine();

                try
                {
                    var rawLines = GatherInput();
                    var input = TextUtility.ParseInput(rawLines);
                    var chipComputer = new ChipComputer(new DefaultPermutationStrategy<(string, string)>());
                    var output = chipComputer.Check(input.StartColor, input.EndColor, input.Chips);
                    RenderOutput(output);

                }
                catch (Exception)
                {

                    Console.WriteLine("Error received. Please try again.");
                    Console.WriteLine();
                }
            }
        }

        private static IEnumerable<string> GatherInput()
        {
            var lines = new List<string>();
            bool done = false;
            while (!done)
            {
                var line = Console.ReadLine().Trim();
                done = line.Length == 0;
                if (!done) { lines.Add(line); }
            }

            return lines;
        }

        private static void RenderOutput(IEnumerable<string> lines)
        {
            lines.ToList().ForEach(Console.WriteLine);
        }
    }
}
