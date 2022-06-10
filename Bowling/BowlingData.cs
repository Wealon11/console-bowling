using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bowling
{
    public class BowlingData
    {
        private readonly List<int[]> _frames = new(10);
        private readonly IBowlingCalculator _bowlingCalculator;

        public BowlingData(IBowlingCalculator bowlingCalculator)
        {
            _bowlingCalculator = bowlingCalculator;
        }

        public void GetBowlingData(int bowlingId)
        {                                                      //Path:Bowling\Bowling\bin\Debug\net5.0\Data.txt
            foreach (Match item in Regex.Matches(File.ReadAllLines("Data.txt")[bowlingId - 1], @"\[(.*?)\]"))
                _frames.Add(item.Groups[1].Value.Split(',').Select(int.Parse).ToArray());

            Print();
        }

        private void Print()
        {
            Console.Write("\n\nFrame: ");
            for (var i = 1; i <= 10; i++) Console.Write("{0,7}", i);
            Console.Write("{0,7}", "Extra");
            Console.Write("\n\nBall 1:");
            foreach (var item in _frames) Console.Write("{0,7}", item[0]);
            if (_frames[9].Length == 3) Console.Write("{0,5}", _frames.Last()[2]);
            Console.Write("\nBall 2:");
            foreach (var item in _frames) Console.Write("{0,7}", item[1]);
            Console.Write("\n\nScore: ");
            foreach (var item in _frames) _bowlingCalculator.RecordFrame(item);
        }
    }
}