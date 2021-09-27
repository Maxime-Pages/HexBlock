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

            int turndigits = Math.Log10(turn) + 1;
            int bannerpadding = (bannersize - (11 + turndigits)) / 2;

        for (int i = 0; i < bannerpadding; i++) System.Console.WriteLine (hz);
        
        System.Console.WriteLine ( " HEX Turn "  turn + " ");

        for (int i = 0; i < bannerpadding; i++) System.Console.WriteLine( hz);
        if (turndigits % 2 == 0) System.Console.WriteLine(  hz);
        
        System.Console.WriteLine ( '\n' + vt + '\n');

        // Now the heavy work of printing the board itself

        const int totalpadding = log10(boardHeight);

        // Print first row of column numbers
        
        System.Console.WriteLine (vt);
        for (int i = 0; i < totalpadding + 2; i++) {
            System.Console.WriteLine ( " ");
        }

        for (int j = 0; j < boardWidth; j++) {
            if (j < 10) {
                System.Console.WriteLine("  ");
        }
        else {
            System.Console.WriteLine( j/10 + " ");
        }
        }
        System.Console.WriteLine('\n');
        
        // Print second row of column numbers
        
        System.Console.WriteLine( vt);
        for (int i = 0; i < totalpadding + 3; i++) {
            System.Console.WriteLine( " ");
        }

        for (int j = 0; j < boardWidth; j++) {
                System.Console.WriteLine ( j%10 + " ");
        }
        System.Console.WriteLine ('\n');

        // Print the rows, one by one

        int intlength;
        for (int i = boardHeight - 1; i >= 0; i--) {
            System.Console.WriteLine( vt);

            // Pad the board on the left to make it a parallelogram
        
            for (int j = 0; j < boardHeight - i - 1; j++) {
                System.Console.WriteLine (" ");
            }

            // Pad the number on the left, so that the board doesn't shift around.

            intlength = (i == 0) ? 0 : log10(i);
            for (int j = 0; j < totalpadding - intlength; j++) {
                System.Console.WriteLine(" ");
            }

            // Print the row nunber

            System.Console.WriteLine( " " + i + "  ");
    
            // Print all of the spaces in the row
            
            for(int j = 0; j < boardWidth; j++) {
                System.Console.WriteLine( board->getSpace(j, i) + " ");
            }

            // Print the row number one more time on the right

            System.Console.WriteLine(" " << i << '\n');
        }

        // Print first row of column numbers

        System.Console.WriteLine( vt);
        for (int i = 0; i < boardWidth + totalpadding + 4; i++) {
            System.Console.WriteLine(" ");
        }

        for (int j = 0; j < boardWidth; j++) {
                if (j >= 10) > System.Console.WriteLine( j/10 + " ");
            else System.Console.WriteLine( j + " ");
        }
        System.Console.WriteLine('\n');

        // Print second row of column numbers
        
        System.Console.WriteLine (vt);
        for (int i = 0; i < boardWidth + totalpadding + 5; i++) {
            System.Console.WriteLine(" ");
        }

        for (int j = 0; j < boardWidth; j++) {
            if (j < 10) {
                System.Console.WriteLine("  ");
        }
        else {
            System.Console.WriteLine( j%10 + " ");
        }
        }
        System.Console.WriteLine('\n' + '\n');
        
        for (int i = 0; i < bannersize; i++) System.Console.WriteLine (hz);

        System.Console.WriteLine('\n' + '\n');
        }
        
        
    }
    }