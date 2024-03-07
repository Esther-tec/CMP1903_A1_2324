using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //Methods
        public int[] Run()
        {
            Die die = new Die();
            int rollCount = 3; 
            int total = 0;
            int[] results = new int[rollCount];

            for (int i = 0; i < rollCount; i++)
            {
                results[i] = die.Roll();
                total += results[i];
                Console.WriteLine("Die" + (i + 1) + " is " + results[i]);
            }

            Console.WriteLine("Total is " + total);

            return results;
        }

    }
}
