using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Game
{
    static void Main(String[] args)
    {
        string userResponse;
        
        Console.WriteLine("Welcome to the Game. Are you up for the challenge? y/n");
        do
        {
            userResponse = Console.ReadLine().ToLower();
            switch (userResponse)
            {
                case "y":
                    startGame();
                    break;

                case "n":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid input. Try again");
                    break;
            }
        } while (userResponse != "y");
    }

    public static void startGame()
    {
        var Random = new Random();
        int mysteryNumber = Random.Next(1, 21);
        int guessAttempts = 0;
        int maxAttempts = 4;
        string choice;
        int numGuess;

        do
        {
            Console.WriteLine("Guess the mystery number from 1-20");
            bool userGuessed = false;

            for (int i = guessAttempts; i <= maxAttempts; i++)
            {
                int remainingAttempts = maxAttempts - i;
                Console.Write("What is your guess?: ");
                numGuess = errorInput();
              

                if (numGuess == mysteryNumber)
                {
                    Console.WriteLine("Congratulations, you have guessed the correct number!");
                    userGuessed = true;
                    break;
                }
                else if (numGuess > mysteryNumber)
                {
                    Console.WriteLine($"The mystery number is less than to the number you have guessed. You have {remainingAttempts:D} remaining");
                }
                else if (numGuess < mysteryNumber)
                {
                    Console.WriteLine($"The mytery number is greater than to the number you have guessed. You have {remainingAttempts:D} remaining");
                }
            }
            if (!userGuessed)
            {
                Console.WriteLine("Game Over. The mystery number is: " + mysteryNumber);
            }

           
            Console.WriteLine("Do you want to play again? y/n");
            choice = Console.ReadLine().ToLower();
            mysteryNumber = Random.Next(1, 21);

        } while (choice == "y");
    }
    public static int errorInput()
    {
        bool isValid = false;
        int userGuess = 0;
        do
        {
            if (int.TryParse(Console.ReadLine(), out userGuess))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Input is not a number");
            }
        } while (!isValid);
        return userGuess;
    }
}

