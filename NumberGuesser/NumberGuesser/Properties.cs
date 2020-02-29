using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Properties
    {
        public string appName = "Number Guesser";
        public string appVersion = "1.0.0";
        public string appAuthor = "Zonel Jivani";
        public string playAgain;
        public string input;
        public string guessInput;

        public int minNum = 1;
        public int maxNum = 100;
        public int guessesLeft = 10;
        public int spacing = 1;
        public int guess;
        public int guessRefresh = 0;
        public int correctNumber;

        public bool firstGame = true;
        public bool tryAgain = false;
        public bool endProgram = false;

        public List<int> previousGuesses = new List<int>();

        public void DisplayAppInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{appName}: Version {appVersion} by {appAuthor}");
            Console.ResetColor();
        }

        public void ObtainUsersName()
        {
            AddLineBreak(spacing);
            Console.Write("Please Enter Your Name: ");

            input = Console.ReadLine().ToUpper().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                input = "User";
            }

            Console.Clear();
            Console.WriteLine($"~~~~ Hello {input}, Lets Play A Game! ~~~~");
            AddLineBreak(spacing);
        }

        public void CreateARandomNumber()
        {
            Random random = new Random();
            correctNumber = random.Next(minNum, maxNum);
        }

        public bool NotFirstGame()
        {
            return firstGame == false;
        }

        public void NotFirstGameSetup()
        {
            Console.Clear();
            guessRefresh = 0;
        }

        public void DisplayGameObjective()
        {
            Console.WriteLine($"I Have Chosen a Number Between {minNum} and {maxNum} ... Can You Guess What It Is?");
            AddLineBreak(spacing);
            ObjectivePrompt();
        }

        public void TakeUsersGuess()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            guessInput = Console.ReadLine();
            AddLineBreak(spacing);
        }

        public bool UserInputIsNotAnInteger()
        {
            return !int.TryParse(guessInput, out guess);
        }

        public void DisplayUserNotEnterValidNumber()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Red, $"'{guessInput}' is not a valid input. Please enter an actual number!");
            ObjectivePrompt();
        }

        public void ConvertUserGuessToInteger()
        {
            guess = Convert.ToInt32(guessInput);
        }

        public bool UserInputGreaterOrLessThanRange()
        {
            return (guess > maxNum) || (guess < minNum);
        }
        public void DisplayUserInputNotInRange()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Red, $"'{guessInput}' is not within the range. Please enter a number between {minNum} and {maxNum}");
            ObjectivePrompt();
        }

        public bool UserGuessIsIncorrect()
        {
            return guess != correctNumber;
        }

        public void SubtractFromGuessesLeft()
        {
            guessesLeft--;
            guessRefresh++;
        }

        public bool UserRanOutofGuesses()
        {
            return guessesLeft == 0;
        }

        public void DisplayUserRanOutOfGuesses()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Red, $"BETTER LUCK NEXT TIME!");
            PrintColorMessage(ConsoleColor.Green, $"The Correct Answer Was {correctNumber}!");
            RefreshGuesses();
        }

        public void DisplayUserGuessIsIncorrect()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.White, $"{guess} Is Not Correct!");
        }

        public bool CorrectNumberIsGreaterThanGuess()
        {
            return correctNumber > guess;
        }

        public void DisplayGuessIs(ConsoleColor color, string a)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("The Correct Number is {0} than {1}!", a, guess);
            AddLineBreak(spacing);
            Console.ResetColor();
        }

        public void DisplayPreviousGuesses()
        {
            previousGuesses.Add(guess);
            PrintColorMessage(ConsoleColor.Gray, "Your Previous Guesses Are The Numbers:");
            foreach (int i in previousGuesses)
            {
                Console.Write($"|{i}| ");
            }
            AddLineBreak(spacing);
            PrintColorMessage(ConsoleColor.Gray, $"You Have {guessesLeft} Guesses Remaining!");
            ObjectivePrompt();
        }

        public bool UserHasNotGuessedCorrectNumber()
        {
            return guess != correctNumber;
        }

        public bool UserHasGuessedCorrectNumber()
        {
            return guess == correctNumber;
        }

        public void DisplayUserGuessedCorrectNumber()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Green, "WOW GREAT GUESS!");
            PrintColorMessage(ConsoleColor.Green, $"The Correct Answer Was {correctNumber}!");
            AddLineBreak(spacing);
        }

        public int RefreshGuesses()
        {
            guessesLeft += guessRefresh;
            return guessesLeft;
        }

        public void DisplayPlayAgainScreen()
        {
            PrintColorMessage(ConsoleColor.Green, $"Thanks For Playing {input}!");
            PrintColorMessage(ConsoleColor.White, "Would You Like To Try Again?");
            PrintColorMessage(ConsoleColor.Magenta, "Type 'Y' And Hit Enter To Play Again!");
            PrintColorMessage(ConsoleColor.Magenta, "Type 'N' And Hit Enter To End The Program!");
        }

        public void TakeInputToPlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            playAgain = Console.ReadLine().ToUpper();
            AddLineBreak(spacing);
        }

        public bool UserWantsToPlayAgain()
        {
            return playAgain == "Y";
        }

        public void TryAgainIsTrue()
        {
            tryAgain = true;
        }

        public bool UserDoesNotWantToPlayAgain()
        {
            return playAgain == "N";
        }

        public void DisplayNotYesOrNoErrorMessage()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Magenta, "I'm Sorry! Please Type 'Y' To Play Again, Or 'N' To End The Program And Hit Enter!");
        }

        public bool DecidingToPlayAgain()
        {
            return tryAgain == false;
        }

        public void GameStateReset()
        {
            Console.ResetColor();
            firstGame = false;
            tryAgain = false;
            previousGuesses.Clear();
        }
        public void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            AddLineBreak(spacing);
            Console.ResetColor();
        }

        public void AddLineBreak(int numTimes)
        {
            for (int i = 0; i < numTimes; i++)
            {
                Console.WriteLine("");
            }
        }

        public void ObjectivePrompt()
        {
            PrintColorMessage(ConsoleColor.White, $"Please Input a Digit Between {minNum} and {maxNum} and Hit Enter!");
            AddLineBreak(spacing);
        }
    }
}
