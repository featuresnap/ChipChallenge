using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge
{
    public class InputData
    {
        public readonly string StartColor;
        public readonly string EndColor;
        public readonly IEnumerable<(string, string)> Chips;

        public InputData(string startColor,string endColor, IEnumerable<(string,string)> chips)
        {
            StartColor = startColor;
            EndColor = endColor;
            Chips = chips;
        }
    }
}
