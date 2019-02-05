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
            bool userContinue = true;

            Console.WriteLine("Welcome to the Grand Circus Number Guessing Game!");
            while (userContinue)
            {
                int computerNumber = GetNumber(0, 100);
                int difference = SubtractNumbers(GetNumber("Please enter a number between 1 and 100.", 0, 100), computerNumber);

                int count = 1;
                string message = "";
                while (difference != 0)
                {
                    message = EvaluateNumber(difference);
                    count++;
                    difference = SubtractNumbers(GetNumber(message, 0, 100), computerNumber);
                }
                ReturnFinalPhrase(count);
                userContinue = ContinueProgram("Would you like to play again? y/n");
            }
            Console.WriteLine("Thank you for playing! Bye!");
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
            if (number > 1)
            {
                Console.WriteLine($"You guessed the number in {number} tries!");
            }
            else
            {
                Console.WriteLine($"Great job you guessed the number on your first try!");
            }
        }
        public static string EvaluateNumber(int number)
        {
            string message;
            //compare statements here 
            if (number > 0)
            {
                //userNumber is higher than computer number
                if (number > 10)
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

                if (number < -10)
                {
                    message = "Number's waaayyy too low, dumb-dumb!";
                }
                else
                {
                    message = "Number's too low, bud!";
                }
            }
            return message;
        }
        public static bool ContinueProgram(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();

            if(userInput == "y")
            {
                return true;
            }
            else if(userInput == "n")
            {
                return false;
            }
            else
            {
               return ContinueProgram("Not a valid response! " + message);
            }
        }
    }
}
