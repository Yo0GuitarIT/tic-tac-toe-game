using System;

namespace MyApp
{
    internal class Program
    {
        static char[,] playField =
        {
            { '1', '2', '3' }, // row1
            { '4', '5', '6' }, // row2
            { '7', '8', '9' } // row3
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // Player 1 starts
            int input = 0;
            bool inputCorrect = true;

            // run code as long as the program runs
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterOorX('O', input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterOorX('X', input);
                }

                #region
                // check win condition
                char[] playerChars = { 'X', 'O' };
                foreach (char playerChar in playerChars)
                {
                    for (int i = 0; i < playField.GetLength(0); i++)
                    {
                        if (
                            (
                                (playField[i, 0] == playerChar)
                                && (playField[i, 1] == playerChar)
                                && (playField[i, 2] == playerChar)
                            )
                            || (
                                (playField[0, i] == playerChar)
                                && (playField[1, i] == playerChar)
                                && (playField[2, i] == playerChar)
                            )
                        )
                        {
                            WinnerDeclare(playerChar);
                        }
                    }
                    if (
                        (
                            (playField[0, 0] == playerChar)
                            && (playField[1, 1] == playerChar)
                            && (playField[2, 2] == playerChar)
                        )
                        || (
                            (playField[0, 2] == playerChar)
                            && (playField[1, 1] == playerChar)
                            && (playField[2, 0] == playerChar)
                        )
                    )
                    {
                        WinnerDeclare(playerChar);
                    }
                    if (turns == 10)
                    {
                        Console.WriteLine("DRAW!");
                        Console.WriteLine("Press any key to reset the game.");
                        Console.ReadKey();
                        ResetField();
                    }
                }
                #endregion

                Setfield();

                #region
                // Test the field is already taken

                do
                {
                    Console.Write("\nPlayer {0}, Choose your field : ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please Enter a number.");
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Incorrect  Input! Please use anthor field!");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion
            } while (true);
        }

        public static void Setfield()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine(
                "  {0}  |  {1}  |  {2} ",
                playField[0, 0],
                playField[0, 1],
                playField[0, 2]
            );
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine(
                "  {0}  |  {1}  |  {2} ",
                playField[1, 0],
                playField[1, 1],
                playField[1, 2]
            );
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine(
                "  {0}  |  {1}  |  {2} ",
                playField[2, 0],
                playField[2, 1],
                playField[2, 2]
            );
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void EnterOorX(char playerSign, int input)
        {
            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSign;
                    break;
                case 2:
                    playField[0, 1] = playerSign;
                    break;
                case 3:
                    playField[0, 2] = playerSign;
                    break;
                case 4:
                    playField[1, 0] = playerSign;
                    break;
                case 5:
                    playField[1, 1] = playerSign;
                    break;
                case 6:
                    playField[1, 2] = playerSign;
                    break;
                case 7:
                    playField[2, 0] = playerSign;
                    break;
                case 8:
                    playField[2, 1] = playerSign;
                    break;
                case 9:
                    playField[2, 2] = playerSign;
                    break;
            }
        }

        public static void WinnerDeclare(char playerChar)
        {
            if (playerChar == 'X')
            {
                Console.WriteLine("/n Player 1 has  won!");
            }
            else if (playerChar == 'O')
            {
                Console.WriteLine("\nPlayer 2 has  won!");
            }
            Console.WriteLine("Press any key to reset the game.");
            Console.ReadKey();
            ResetField();
        }

        public static void ResetField()
        {
            char[,] playFieldInitial =
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
            playField = playFieldInitial;
            turns = 0;
            Setfield();
        }
    }
}
