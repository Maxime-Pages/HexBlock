using System;
using System.Security.Cryptography.X509Certificates;

namespace HexBlock
{
    partial class Board
    {
        public void Board_display(int x = -1,int y = -1)
        {
            Console.Clear();
            draw_banner_and_turn();
            display_row_column_numbers();
            display_second_row_column_numbers();
            display_row_one_by_one_and_blue_number(x, y);
            display_row_red_number();
        }
        

        public void draw_banner_and_turn()
        {

            string spaces = "";
            string barre = "-";
            int boardSize = this.size;
            int indent = 0;
            int bannerSize = (int)((2 * indent) + 7 + boardSize * 3 + Math.Log10(boardSize)); // The size of banner depend of the size of the Board
            int numberTurn = (int)Math.Log10(turn) + 1;
            int bannerPadding = (bannerSize - (11 + numberTurn)) / 2;

            Console.Clear(); // clear the console for the visual

            // we print the banner for the turn

            for (int i = 0; i < indent - 1; i++)
            {
                spaces += " ";
            }

            System.Console.WriteLine('\n');
            for (int i = 0 ; i < bannerPadding; i++)
            {
                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.Write(barre);
            }

                System.Console.ForegroundColor = ConsoleColor.Green; // make the turn in the color green
                System.Console.Write("Turn " + turn + " ");
                System.Console.ForegroundColor = ConsoleColor.Black; // stay the -- in the color black
            

            for (int i = 0; i < bannerPadding; i++)
            {
                System.Console.Write(barre);
            }

            if (numberTurn % 2 == 0)
                System.Console.Write(barre);

            System.Console.Write('\n' + spaces + '\n');
        }



        // Firstly we print the first row of column numbers

        public void display_row_column_numbers()
        {
            int boardSize = this.size;
            string spaces = "";
            int padding = (int)Math.Log10(boardSize);


            System.Console.Write(spaces);
            for (int i = 0; i < padding + 2; i++) // we have +2 for print the number and have a good padding
            {
                System.Console.Write(" ");
            }

            for (int j = 0; j < boardSize; j++)
            {
                if (j < 10)
                {
                    System.Console.Write("  ");
                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write(j / 10 + " ");
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
            }

            System.Console.Write('\n');
        }

        //Secondly we print the second row of column numbers
        public void display_second_row_column_numbers()
        {
            int boardSize = this.size;
            string spaces = "";
            int padding = (int)Math.Log10(boardSize);


            System.Console.Write(spaces);
            for (int i = 0; i < padding + 3; i++)
            {

                System.Console.Write(" ");

            }

            for (float j = 0; j < boardSize; j++)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write(j % 10 + " ");
                System.Console.ForegroundColor = ConsoleColor.Black;

            }

            System.Console.Write('\n');
        }

        //Eventually we print the rows one by one
        public void display_row_one_by_one_and_blue_number(int x ,int y)
        {
            int boardSize = this.size;
            string spaces = "";
            int padding = (int)Math.Log10(boardSize);
            int intlength;

            for (int i = boardSize - 1; i >= 0; i--)
            {
                System.Console.Write(spaces);

                // we put the board on the left to make it a parallelogram

                for (int j = 0;
                    j < boardSize - i - 1;
                    j++) // we have -1 to make a difference between the row underneath and the row previously
                {
                    System.Console.Write(" ");
                }

                intlength = (i == 0) ? 0 : (int)Math.Log10(i);
                for (int j = 0; j < padding - intlength; j++)
                {
                    System.Console.Write(" ");
                }


                // Print the row number 
                System.Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.Write(" " + i + "  ");
                System.Console.ForegroundColor = ConsoleColor.Black;

                // Print the color, it depend of the coordinate say before

                for (int j = 0; j < boardSize; j++)
                {
                    /*if ((i, j) == (x, y))
                    {
                        System.Console.Write("■ ");
                        continue;
                    }*/
                    System.Console.ForegroundColor = this.grid[j, i].IsEmpty() ? ConsoleColor.Black :
                        this.grid[j, i].GetColor() ? ConsoleColor.Red : ConsoleColor.Blue;
                    System.Console.Write((this.grid[j, i].IsEmpty() ? "_" : this.grid[j, i].GetColor() ? "■" : "■") + " ");
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }

                // We print the row number same before but for the right
                System.Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.Write(" " + i + '\n');
                System.Console.ForegroundColor = ConsoleColor.Black;

                intlength = (i == 0) ? 0 : (int)Math.Log10(i);
                for (int j = 0; j < padding - intlength; j++)
                {
                    System.Console.Write(" ");


                }
            }
        }

        public void display_row_red_number()
        {
            int boardSize = this.size;
            string spaces = "";
            int padding = (int)Math.Log10(boardSize);
            int indent = 0;
            int bannersize =
                (int)((2 * indent) + 7 + boardSize * 3 +
                       Math.Log10(boardSize)); // The size of banner depend of the size of the Board
            string barre = "-";

            //Firstly we print first row of column numbers

            System.Console.Write(spaces);
            for (int i = 0; i < boardSize + padding + 4; i++)
            {

                System.Console.Write(" ");

            }

            for (int j = 0; j < boardSize; j++)
            {
                if (j >= 10)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write(j / 10 + " ");
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }

                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write(j + " ");
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }

            }

            System.Console.Write('\n');

            // Print second row of column numbers

            System.Console.Write(spaces);
            for (int i = 0; i < boardSize + padding + 5; i++)
            {

                System.Console.Write(" ");

            }

            for (int j = 0; j < boardSize; j++)
            {
                if (j < 10)
                {

                    System.Console.Write("  ");

                }

                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write(j % 10 + " ");
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
            }

            System.Console.WriteLine();

            for (int i = 0; i < bannersize; i++)
                System.Console.Write(barre);

        }



        public (int, int,bool) Cursor((int,int) current)
        {
            int x = current.Item1;
            int y = current.Item2;
            bool enter = false;
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Z:
                    if (x!=size-1)
                        x++;
                    else
                    {
                        x = 0;
                    }
                    break;
                case ConsoleKey.S:
                   if (x == 0)
                        x--;
                   else
                   {
                       x = size - 1;
                   }
                   break;
                case ConsoleKey.Q:
                    if (y == 0)
                        y--;
                    else
                    {
                        y = size - 1;
                    }
                    
                    break;
                case ConsoleKey.D:
                    if(y!=size-1)
                        y++;
                    else
                    {
                        y = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    enter = true;
                    break;
                  
            }

            return (x, y, enter);

        }

    }
}