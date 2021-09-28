    using System;
    namespace HexBlock
    {
        partial class Board
        {
            public void drawBoard() 
            {

               Console.Clear();// clear the console for the visual

               // we print the banner for the turn
    
                string barre = "-";
    
                int boardSize = this.size; // variable for the height of the board
                
        
                int indent = 2;
                int bannersize = (int)((2 * indent) + 7 + boardSize * 3 + Math.Log10(boardSize)); // The size of banner depend of the size of the Board
        
                string spaces = "";
                for (int i = 0; i < indent - 1; i++)
                {
                    spaces = spaces + " ";
                }  

                System.Console.WriteLine ('\n');

                int numberTurn = (int)Math.Log10(turn) + 1;
                int bannerpadding = (bannersize - (11 + numberTurn)) / 2;

            for (int i = 0; i < bannerpadding; i++) 
                System.Console.Write (barre);
        
            System.Console.Write ( "                 Turn "  + turn + " ");

            for (int i = 0; i < bannerpadding; i++) 
                System.Console.Write( barre);
            if (numberTurn % 2 == 0) System.Console.Write(barre);
        
            System.Console.Write( '\n' + spaces + '\n');

            // We make the print of the board

            int padding = (int)Math.Log10(boardSize);

            // Firstly we print the first row of column numbers
        
            System.Console.Write (spaces);
            for (int i = 0; i < padding + 2; i++) // we have +2 for print the number and have a good padding
            {
                System.Console.Write ( " ");
            }

            for (int j = 0; j < boardSize; j++) 
            {
                if (j < 10) 
                {
                    System.Console.Write("  ");
                }
                else 
                {
                    System.Console.Write( j/10 + " ");
                }
            }
            System.Console.Write('\n');
            //Secondly we print the second row of column numbers
        
            System.Console.Write( spaces);
            for (int i = 0; i < padding + 3; i++) 
            {
                System.Console.Write( " ");
            }

            for (float j = 0; j < boardSize; j++) 
            {
                System.Console.Write ( j%10 + " ");
            }
            System.Console.Write ('\n');
            //Eventually we print the rows one by one
            int intlength;
            for (int i = boardSize - 1; i >= 0; i--) 
            {
                System.Console.Write( spaces);

                // we put the board on the left to make it a parallelogram
        
                for (int j =0; j < boardSize - i - 1; j++) // we have -1 to make a difference between the row underneath and the row previously
                {
                    System.Console.Write(" ");
                }
                // we put the number on the left, so that the board doesn't shift around.
                intlength = (i == 0) ? 0 : (int)Math.Log10(i);
                for (int j = 0; j < padding - intlength; j++) 
                {
                    System.Console.Write(" ");
                }

                System.Console.Write( " " + i + "  ");
                for(int j = 0; j < boardWidth; j++) 
    
                // Print the color, it depend of the coordinate say before
            
                for(int j = 0; j < boardSize; j++) 
                {
                    System.Console.ForegroundColor=this.grid[j, i].isEmpty() ? ConsoleColor.Black : this.grid[j, i].isRed() ? ConsoleColor.Red : ConsoleColor.Blue;
                    System.Console.Write( (this.grid[j, i].isEmpty() ? "_" : this.grid[j, i].isRed() ? "■" : "■" )+ " ");
                    System.Console.ForegroundColor= ConsoleColor.Black;
                }
                // We print the row number same before but for the right

                System.Console.Write(" " + i + '\n');
            }

            //Firstly we print first row of column numbers

            System.Console.Write( spaces);
            for (int i = 0; i < boardSize + padding + 4; i++) 
            {
                System.Console.Write(" ");
            }

            for (int j = 0; j < boardSize; j++) 
            {
                if (j >= 10)  System.Console.Write( j/10 + " ");
                else System.Console.Write( j + " ");
            }
            System.Console.Write('\n');
            // Print second row of column numbers
        
            System.Console.Write (spaces);
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
                    System.Console.Write( j%10 + " ");
                }
            }
            System.Console.WriteLine();
        
            for (int i = 0; i < bannersize; i++) 
                System.Console.Write (barre);

        }
        
        
    }
}