using System;
using System.Collections.Generic;

namespace Bowling
{
    public class BowlingCalculator : IBowlingCalculator
    {
        private readonly List<int> _throws = new(21);
        private int _numberOfFrames;

        public int Score { get; private set; }

        public void RecordFrame(params int[] throws)
        {
            _throws.AddRange(throws);
            _numberOfFrames++;

            if (_numberOfFrames == 10) SetScore();
        }

        private void SetScore()
        {
            var frame = 1;
            var score = 0;
            var frameStart = 0;
            while (frame <= 10)
            {
                if (IsStrike(frameStart))
                    score += StrikeBonus(frameStart);

                else if (IsSpare(frameStart))
                    score += SpareBonus(frameStart);

                else
                    score += SumOfFrame(frameStart);

                frameStart += 2;
                frame++;
                Console.Write("{0,7}", score);
            }
            Score = score;
        }

        private bool IsStrike(int roll)
        {
            return _throws[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return _throws[roll] + _throws[roll + 1] == 10;
        }

        private int StrikeBonus(int roll)
        {
            if (roll == 18)
                return 10 + _throws[roll + 1] + _throws[roll + 2];

            if (_throws[roll + 2] == 10)
                return 10 + _throws[roll + 2] + _throws[roll + 4];

            return 10 + _throws[roll + 2] + _throws[roll + 3];
        }

        private int SpareBonus(int roll)
        {
            return 10 + _throws[roll + 2];
        }

        private int SumOfFrame(int roll)
        {
            return _throws[roll] + _throws[roll + 1];
        }
    }
}