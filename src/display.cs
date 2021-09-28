    using System;
    namespace HexBlock
    {
        partial class Board
        {
            public void drawBoard() 
            {

                // The drawing routine turned into spaghetti.
                // I promise the rest of the program is a lot more readable.

                // First print out a nice turn banner
        
                string hz = "-";
    
                int boardHeight = this.size;
                int boardWidth = this.size;
        
                int indent = 3;
                int bannersize = (int)((2 * indent) + 5 + boardWidth * 3 + Math.Log10(boardWidth));
        
                string vt = "";
                for (int i = 0; i < indent - 1; i++)
                {
                    vt = vt + " ";
                }  // This is really sloppy, I know.

                System.Console.WriteLine ('\n');

                int turndigits = (int)Math.Log10(turn) + 1;
                int bannerpadding = (bannersize - (11 + turndigits)) / 2;

            for (int i = 0; i < bannerpadding; i++) 
                System.Console.Write (hz);
        
            System.Console.Write ( " HEX Turn "  + turn + " ");

            for (int i = 0; i < bannerpadding; i++) 
                System.Console.Write( hz);
            if (turndigits % 2 == 0) System.Console.Write(  hz);
        
            System.Console.Write( '\n' + vt + '\n');

            int totalpadding = (int)Math.Log10(boardHeight);

            System.Console.Write (vt);
            for (int i = 0; i < totalpadding + 2; i++) 
            {
                System.Console.Write ( " ");
            }

            for (int j = 0; j < boardWidth; j++) 
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
 
            System.Console.Write( vt);
            for (int i = 0; i < totalpadding + 3; i++) 
            {
                System.Console.Write( " ");
            }

            for (int j = 0; j < boardWidth; j++) 
            {
                System.Console.Write ( j%10 + " ");
            }
            System.Console.Write ('\n');

            int intlength;
            for (int i = boardHeight - 1; i >= 0; i--) 
            {
                System.Console.Write( vt);


                for (int j = 0; j < boardHeight - i - 1; j++) 
                {
                    System.Console.Write(" ");
                }

                intlength = (i == 0) ? 0 : (int)Math.Log10(i);
                for (int j = 0; j < totalpadding - intlength; j++) 
                {
                    System.Console.Write(" ");
                }

                System.Console.Write( " " + i + "  ");

                for(int j = 0; j < boardWidth; j++) 
                {
                    System.Console.Write( (this.grid[j, i].isEmpty() ? "_" : this.grid[j, i].isRed() ? "R" : "B" )+ " ");
                }

                System.Console.Write(" " + i + '\n');
            }

            System.Console.Write( vt);
            for (int i = 0; i < boardWidth + totalpadding + 4; i++) 
            {
                System.Console.Write(" ");
            }

            for (int j = 0; j < boardWidth; j++) 
            {
                if (j >= 10)  System.Console.Write( j/10 + " ");
                else System.Console.Write( j + " ");
            }
            System.Console.Write('\n');

            System.Console.Write (vt);
            for (int i = 0; i < boardWidth + totalpadding + 5; i++) 
            {
                System.Console.Write(" ");
            }

            for (int j = 0; j < boardWidth; j++) 
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
                System.Console.Write (hz);

        }
        
        
    }
}