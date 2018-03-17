using System;
using Game.Models;

namespace Game.GameEngine
{
    public static class HelperEngine
    {
        private static Random rnd = new Random();

        // Returns a random int with a number of rolls and a number of dice
        public static int RollDice (int rolls, int dice)
        {
            if (rolls < 1)
            {
                return 0;
            }

            if (dice < 1)
            {
                return 0;
            }

            if (GameGlobals.ForceRollsToNotRandom)
            {
                return GameGlobals.ForcedRandomValue * rolls;
            }

            var myReturn = 0;

            for (var i = 0; i < rolls; i++)
            {
                // Add one to the dice, because random is between.  So 1-10 is rnd.Next(1,11)
                myReturn += rnd.Next(1, dice+1);
            }

            return myReturn;
        }
    }
}
