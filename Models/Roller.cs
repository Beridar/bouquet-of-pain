using System;
using System.Collections.Generic;
using System.Linq;

namespace BouquetOfPain.Models
{
    public interface IRoller
    {
        Roller.Result Roll(int dice, int sides);
    }

    public class Roller : IRoller
    {
        private static readonly Random rng;

        static Roller()
        {
            rng = new Random();
        }

        public Result Roll(int dice, int sides)
        {
            if (dice <= 0) throw new ArgumentException($"{nameof(dice)} must be greater than zero.");
            if (sides <= 0) throw new ArgumentException($"{nameof(sides)} must be greater than zero.");
            if (sides == int.MaxValue) throw new ArgumentException($"{nameof(sides)} must be less than int.MaxValue");

            var rolls = Enumerable.Range(1, dice)
                .Select(x => rng.Next(1, sides + 1))
                .ToArray();

            return new Result(rolls);
        }

        public class Result
        {
            public int Total { get; }
            public int[] Rolls { get; }

            public Result(IEnumerable<int> rolls)
            {
                Rolls = rolls.ToArray();

                Total = Rolls.Sum();
            }
        }
    }
}