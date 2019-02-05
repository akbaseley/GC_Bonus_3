using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_e
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Number Guessing Game!");

            int computerNumber = GetNumber(0, 100);
            int difference = SubtractNumbers(GetNumber("Please enter a number between 1 and 100.", 0, 100), computerNumber);
            
            int count = 1;
            string message = "";
            while (difference != 0)
            {
                //compare statements here 
                if(difference > 0)
                {
                    //userNumber is higher than computer number
                    if(difference > 10)
                    {
                        message = "Number's way too high, ya dummy!";
                    }
                    else
                    {
                        message = "Number's just a bit too high!";
                    }
                }
                else
                {
                    //computerNumber is higher than userNumber

                    if (difference < -10)
                    {
                        message = "Number's waaayyy too low, dumb-dumb!";
                    }
                    else
                    {
                        message = "Number's too low, bud!";
                    }
                }
                count++;
                difference = SubtractNumbers(GetNumber(message, 0, 100), computerNumber);
            }
            ReturnFinalPhrase(count);
        }

        public static int GetNumber(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
        public static int GetNumber(string message, int min, int max)
        { 
            int userNumber = -1;
            while (userNumber < min || userNumber > max)
            {
                Console.WriteLine(message);
                while (!int.TryParse(Console.ReadLine(), out userNumber)) ;
            }
            return userNumber;
        }
        public static int SubtractNumbers(int number1, int number2)
        {
            return number1 - number2;
        }
        public static void ReturnFinalPhrase(int number)
        {
            if(number > 1)
            {
                Console.WriteLine($"You guessed the number in {number} tries!");
            }
            else
            {
                Console.WriteLine($"Great job you guessed the number on your first try!");
            }
        }

    }
}
