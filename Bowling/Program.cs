using System;

namespace Bowling
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter a bowling ID to display game info for the given ID");





            while (true)
            {
                var bowlingData = new BowlingData(new BowlingCalculator());

                Console.SetCursorPosition(0, 1);
                var input = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter another bowling ID to display game info for the given ID");
                bowlingData.GetBowlingData(Convert.ToInt32(input));
            }
        }
    }
}