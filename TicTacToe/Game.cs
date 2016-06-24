//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: Player vs. Player, Player vs. Computer, //
//              Easy, Hard, Impossible.                 //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System ;

namespace TicTacToe {
    class Game {
        // Declare constants
        public const int X          = (int)Constants.x          ;
        public const int O          = (int)Constants.o          ;
        public const int EASY       = (int)Constants.easy       ;
        public const int HARD       = (int)Constants.hard       ;
        public const int IMPOSSIBLE = (int)Constants.impossible ;

        // Declare game objects
        Score scores = new Score() ;
        Board board = new Board() ;

        // Method starts game
        public void startGame() {
            Console.WriteLine(board.ToString()) ;
            Console.WriteLine(scores.ToString()) ;
            Console.ReadLine() ;
        }
    }
}