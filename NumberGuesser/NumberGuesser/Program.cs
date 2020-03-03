using System;
using System.Collections.Generic;


namespace NumberGuesser
{

    class Program
    {
        static void Main(string[] args)
        {
            Properties props = new Properties();
            props.DisplayAppInfo();
            props.DisplayNameEntryPrompt();
            props.ObtainUsersName();

            while (true)
            {

                props.CreateARandomNumber();
                if (props.NotFirstGame())
                {
                    props.NotFirstGameSetup();
                }

                while (true)
                { 
                    props.DisplayHUD();

                    props.TakeUsersBet();

                    if (props.UserBetIsNotAnInteger())
                    {
                        props.DisplayUserBetIsNotAnInteger();
                    }
                    else if (props.UserInputNotWithinBudget())
                    {
                        props.DisplayUserInputNotInBudget();
                    }
                    else
                    {
                        break;
                    }
                }

                props.DeterminePayout();
                props.SubtractWagerFromBankroll();
                props.DisplayPayout();
                props.DisplayGamePrompt();

                do
                {

                    props.TakeUsersGuess();
                    if (props.UserInputIsNotAnInteger())
                    {
                        props.DisplayUserNotEnterValidNumber();
                        continue;
                    }
                    props.ConvertUserGuessToInteger();
                    if (props.UserInputGreaterOrLessThanRange())
                    {
                        props.DisplayUserInputNotInRange();
                        continue;
                    }
                    if (props.UserGuessIsIncorrect())
                    {
                        props.SubtractFromGuessesLeft();
                        if (props.UserRanOutofGuesses())
                        {
                            props.DisplayUserRanOutOfGuesses();
                            props.RefreshGuesses();
                            break;
                        }
                        else
                        {
                            props.DisplayUserGuessIsIncorrect();
                            props.DisplayRemainingGuesses();
                            props.AddGuessToList();
                            props.DisplayPreviousGuesses();

                            props.DisplayGamePrompt();
                            props.DisplayRemainingGuesses();
                        }
                    }
                } while (props.UserHasNotGuessedCorrectNumber());
                
                if (props.UserHasGuessedCorrectNumber())
                {
                    props.DisplayUserGuessedCorrectNumber();
                    props.AddWinningsToBankroll();
                    props.RefreshGuesses();
                }

                if (props.UserIsOutOfMoney())
                {
                    props.DisplayGameOver();
                    break;
                }
                props.GameStateReset();
            }
        }
    }
}
