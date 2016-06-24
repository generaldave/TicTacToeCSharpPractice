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
        public const int CONTINUE   = (int)Constants.cont       ;
        public const int IMPOSSIBLE = (int)Constants.impossible ;

        // Declare game objects
        Score  scores  = new Score()  ;
        Board  board   = new Board()  ;
        Person person1 = new Person() ;
        Person person2 = new Person() ;

        // Method starts game
        public void startGame() {
            // Initialize objects
            person1.ID   = X        ;
            person2.ID   = O        ;
            board.status = CONTINUE ;
            board.reset() ;

            // Play game
            while(board.status == CONTINUE) {
                Console.Clear() ;
                Console.WriteLine(board.ToString()) ;
                Console.WriteLine(scores.ToString()) ;

                person1.decideMove(board) ;
            }

            // Increment appropriate score
            scores.increment(board.status) ;

            // Display summary
            Console.Clear() ;
            Console.WriteLine(board.ToString()) ;
            Console.WriteLine("Game Over") ;
            Console.WriteLine(scores.ToString()) ;
            Console.WriteLine() ;
        }

        // Method clears scores
        public void resetScores() {
            scores.reset() ;
            Console.Clear() ;
            Console.WriteLine(scores.ToString()) ;
            Console.WriteLine() ;
        }
    }
}