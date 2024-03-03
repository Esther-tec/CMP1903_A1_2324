using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Property


        //Method
        // Property
        public int currentValue { get; private set; }

        // Method to roll the die
        public int Roll()
        {
            // Create a new instance of Random to generate random numbers
            Random random = new Random();

            // Roll the die and assign the result to currentValue
            currentValue = random.Next(1, 7); // Generates a random number between 1 and 6 (inclusive)

            // Return the rolled value
            return currentValue;
        }


    }
}
