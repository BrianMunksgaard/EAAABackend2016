using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceRoll.Models
{
    public class Dice
    {
        private Random r = new Random();

        private int eyes;
        private int numRolls;
        private int outcome;
        private int totalSum;
        private int[] distribution;

        public Dice()
        {
            eyes = 6;
            numRolls = 0;
            totalSum = 0;
            distribution = new int[eyes];
        }

        public void Roll()
        {
            //The numRolls is the total number of rolls of the dice.
            //The outcome is what the dice landed at, and totalSum is
            //the total sum of eyes in all dice rolls.
            //The distribution field is used to keep track of how many
            //times the dice landed on each of the possible outcomes (1, 2, 3, 4, 5, and 6):
            numRolls++;
            outcome = r.Next(1, 6);
            totalSum += outcome;

            int index = outcome - 1;
            distribution[index]++;
        }
    }
}