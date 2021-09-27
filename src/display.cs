void Game::drawBoard() {

    // The drawing routine turned into spaghetti.
    // I promise the rest of the program is a lot more readable.

    // First print out a nice turn banner
    
    string hz = "-";
 
    int boardHeight = board->sideLength;
    int boardWidth = boardHeight;
    
    int indent = 3;
    int bannersize = (2 * indent) + 5 + boardWidth * 3 + log10(boardWidth);
    
    string vt = "";
    for (int i = 0; i < indent - 1; i++) vt = vt + " "; // This is really sloppy, I know.

    Console.WriteLine ('\n');

    int turndigits = log10(turn) + 1;
    int bannerpadding = (bannersize - (11 + turndigits)) / 2;

    for (int i = 0; i < bannerpadding; i++) Console.WriteLine (<< hz);
    
    Console.WriteLine ( " HEX Turn " << turn << " ");

    for (int i = 0; i < bannerpadding; i++) Console.WriteLine( hz);
    if (turndigits % 2 == 0) Console.WriteLine(  hz);
    
    Console.WriteLine ( '\n' + vt + '\n');

    // Now the heavy work of printing the board itself

    const int totalpadding = log10(boardHeight);

    // Print first row of column numbers
    
    Console.WriteLine (vt);
    for (int i = 0; i < totalpadding + 2; i++) {
        Console.WriteLine ( " ");
    }

    for (int j = 0; j < boardWidth; j++) {
        if (j < 10) {
            Console.WriteLine(<< "  ");
    }
    else {
        console.WriteLine( j/10 + " ");
    }
    }
    console.WriteLine('\n');
    
    // Print second row of column numbers
    
    console.WriteLine( vt);
    for (int i = 0; i < totalpadding + 3; i++) {
        console.WriteLine( " ");
    }

    for (int j = 0; j < boardWidth; j++) {
            Console.WriteLine ( j%10 + " ");
    }
    Console.WriteLine ('\n');

    // Print the rows, one by one

    int intlength;
    for (int i = boardHeight - 1; i >= 0; i--) {
        Console.WriteLine( vt);

        // Pad the board on the left to make it a parallelogram
    
        for (int j = 0; j < boardHeight - i - 1; j++) {
            Console.WriteLine (" ");
        }

        // Pad the number on the left, so that the board doesn't shift around.

        intlength = (i == 0) ? 0 : log10(i);
        for (int j = 0; j < totalpadding - intlength; j++) {
            Console.WriteLine(" ");
        }

        // Print the row nunber

        Console.WriteLine( " " + i + "  ");
 
        // Print all of the spaces in the row
        
        for(int j = 0; j < boardWidth; j++) {
            Console.WriteLine( board->getSpace(j, i) + " ");
        }

        // Print the row number one more time on the right

        Console.WriteLine(" " << i << '\n');
    }

    // Print first row of column numbers

    Console.WriteLine( vt);
    for (int i = 0; i < boardWidth + totalpadding + 4; i++) {
        Console.WriteLine(" ");
    }

    for (int j = 0; j < boardWidth; j++) {
            if (j >= 10) >Console.WriteLine( j/10 + " ");
        else Console.WriteLine( j + " ");
    }
    Console.WriteLine('\n');

    // Print second row of column numbers
    
    Console.WriteLine (vt);
    for (int i = 0; i < boardWidth + totalpadding + 5; i++) {
        Console.WriteLine(" ");
    }

    for (int j = 0; j < boardWidth; j++) {
        if (j < 10) {
            Console.WriteLine("  ");
    }
    else {
        Console.WriteLine( j%10 + " ");
    }
    }
    Console.WriteLine('\n' + '\n');
    
    for (int i = 0; i < bannersize; i++) Console.WriteLine (hz);

    Console.WriteLine('\n' + '\n');
    
}