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
        public string appVersion = "2.0.0";
        public string appAuthor = "Zonel Jivani";
        public string playAgain;
        public string input;
        public string guessInput;
        public string betInput;

        public int minNum = 1;
        public int maxNum = 50;
        public int guessesLeft = 4;
        public int spacing = 1;
        public int guess;
        public int bet;
        public int guessRefresh = 0;
        public int correctNumber;
        public int amountOfMoney = 500;
        public int splitForGambling = 2;
        public int amountToBePaid;
        


        public bool firstGame = true;
        public bool tryAgain = false;
        public bool endProgram = false;


        public List<int> previousGuesses = new List<int>();

        public void DisplayAppInfo()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Green, $"{appName}: Version {appVersion} by {appAuthor}");
            PrintColorMessage(ConsoleColor.White, "WELCOME TO NUMBER GUESSER, AN APPLICATION TO GAMBLE FAKE MONEY!");
            PressEnterToContinue();
            
        }

        public void DisplayNameEntryPrompt()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.White, "BEFORE WE GET STARTED, PLEASE ENTER A USERNAME");
        }

        public void ObtainUsersName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine().ToUpper().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                input = "John or Jane Doe";
            }
            Console.ResetColor();
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

        public void DisplayHUD()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.White, $"{input}");
            PrintColorMessage(ConsoleColor.White, $"Current Bankroll: ${amountOfMoney}");
            AddLineBreak(spacing);
            PrintColorMessage(ConsoleColor.White, "How Much Would You Like To Bet?");
            PrintColorMessage(ConsoleColor.White, "If It's Your First Time Playing, I Recommend Entering 0 ...");

        }

        public void TakeUsersBet()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            betInput = Console.ReadLine();
            Console.ResetColor();
        }

        public bool UserBetIsNotAnInteger()
        {
            return !int.TryParse(betInput, out bet);
        }

        public void DisplayUserBetIsNotAnInteger()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Red, $"{betInput} IS NOT A NUMBER!");
            PressEnterToContinue();
        }

        public bool UserInputNotWithinBudget()
        {
            return bet > amountOfMoney || bet < 0;
        }

        public void DisplayUserInputNotInBudget()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Red, $"Please Input A Number Between 0 And {amountOfMoney}!");
            PressEnterToContinue();
            
        }

        public void DeterminePayout()
        {
            amountToBePaid = bet * splitForGambling;
        }

        public void DisplayPayout()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.White, $"You Bet ${bet} ...");
            PrintColorMessage(ConsoleColor.White, $"Current Bankroll: ${amountOfMoney}");
            PrintColorMessage(ConsoleColor.Green, $"If You Win, You Will Gain ${amountToBePaid}!");
            PressEnterToContinue();
        }

        public void SubtractWagerFromBankroll()
        {
            amountOfMoney -= bet;
        }

        public void DisplayGamePrompt()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.White, $"Input a Digit Between {minNum} and {maxNum} and Hit Enter!");
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
            PrintColorMessage(ConsoleColor.White, $"Input a Digit Between {minNum} and {maxNum} and Hit Enter!");

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
            PrintColorMessage(ConsoleColor.White, $"Input a Digit Between {minNum} and {maxNum} and Hit Enter!");
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
            PrintColorMessage(ConsoleColor.Red, $"HOUSE WINS!");
            PrintColorMessage(ConsoleColor.White, $"The Correct Answer Was {correctNumber}!");
            PressEnterToContinue();
            
        }

        public void DisplayUserGuessIsIncorrect()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.White, $"Incorrect Answer: {guess}");
            
        }      
        
        public void DisplayRemainingGuesses()
        {
            PrintColorMessage(ConsoleColor.White, $"Remaining Guesses: {guessesLeft}");
        }

        public void AddGuessToList()
        {
            previousGuesses.Add(guess);
        }

        public void DisplayPreviousGuesses()
        {
            PrintColorMessage(ConsoleColor.White, "Previous Guesses:");
            foreach (int i in previousGuesses)
            {
                if (correctNumber > i)
                {
                    PrintColorMessage(ConsoleColor.Green, $"{i} - Too Low");
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Red, $"{i} - Too High");
                }
            }
            PressEnterToContinue();
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
            PrintColorMessage(ConsoleColor.Green, "WINNER!");
            PrintColorMessage(ConsoleColor.White, $"+${amountToBePaid} Added To Bankroll!");
            PressEnterToContinue();
        }

        public void AddWinningsToBankroll()
        {
            amountOfMoney += amountToBePaid;
        }

        public int RefreshGuesses()
        {
            guessesLeft += guessRefresh;
            return guessesLeft;
        }

        public bool UserIsOutOfMoney()
        {
            return amountOfMoney == 0;
        }

        public void DisplayGameOver()
        {
            Console.Clear();
            PrintColorMessage(ConsoleColor.Red, "GAME OVER");
            PrintColorMessage(ConsoleColor.White, "You Have Ran Out Of Money!");
            PrintColorMessage(ConsoleColor.White, $"Thanks For Playing {input}!");
            PressEnterToContinue();
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

        public void PressEnterToContinue()
        {
            PrintColorMessage(ConsoleColor.Yellow, "Press Enter To Continue ...");
            Console.ReadLine();
        }
    }
}
