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
            props.ObtainUsersName();
            while (true)
            {
                props.CreateARandomNumber();
                if (props.NotFirstGame())
                {
                    props.NotFirstGameSetup();
                }
                props.DisplayGameObjective();
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
                            break;
                        }
                        else
                        {
                            props.DisplayUserGuessIsIncorrect();
                            if (props.CorrectNumberIsGreaterThanGuess())
                            {
                                props.DisplayGuessIs(ConsoleColor.Green, "Higher");
                            }
                            else
                            {
                                props.DisplayGuessIs(ConsoleColor.Red, "Lower");
                            }
                            props.DisplayPreviousGuesses();
                        }
                    }
                } while (props.UserHasNotGuessedCorrectNumber());
                if (props.UserHasGuessedCorrectNumber())
                {
                    props.DisplayUserGuessedCorrectNumber();
                    props.RefreshGuesses();
                }
                
                props.DisplayPlayAgainScreen();

                do
                {
                    props.TakeInputToPlayAgain();
                    if (props.UserWantsToPlayAgain())
                    {
                        props.TryAgainIsTrue();
                        continue;
                    }
                    else if (props.UserDoesNotWantToPlayAgain())
                    {
                        return;
                    }
                    else
                    {
                        props.DisplayNotYesOrNoErrorMessage();
                    }
                } while (props.DecidingToPlayAgain());
                props.GameStateReset();
            }
        }
    }
}
