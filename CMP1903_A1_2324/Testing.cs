using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Method
        public void GameTest()
        {
            Die die = new Die();
            Debug.Assert(die.Roll() >= 1 && die.Roll() <= 6, "Die value is out of range"); // Correct the range check

            Game test = new Game();
            Console.WriteLine("");
            Console.WriteLine("test one");
            int[] firstTest = test.Run(); // First instance of game made
            Console.WriteLine("");
            Console.WriteLine("test two");
            int[] secondTest = test.Run(); // Second instance of game made

            bool areEqual = true;
            for (int i = 0; i < firstTest.Length; i++)
            {
                if (firstTest[i] != secondTest[i])
                {
                    areEqual = false;
                    break;
                }
            }

            Debug.Assert(!areEqual, "GameTest unsuccessful"); // Check if the results are not equal
        }
    }
}
