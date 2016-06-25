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
        Person player1 = new Person() ;
        Person player3 = new Person() ;

        // Declare turn variable
        private int turn ;

        // Method starts game
        public void startGame(bool computerAI) {
            // Initialize objects            
            player1.ID     = X        ;
            board.status   = CONTINUE ;
            board.reset() ;

            // Set turn to X
            turn = X ;

            // Play game
            while(board.status == CONTINUE) {
                Console.Clear() ;
                Console.WriteLine(board.ToString()) ;
                Console.WriteLine(scores.ToString()) ;

                if(player1.ID == turn) {
                    player1.decideMove(board);
                    turn = O ;
                }

                else {
                    if(computerAI) {
                        Computer player2 = (Computer)player3 ;
                        player2.ID = O ;
                        player2.decideMove(board) ;
                    }
                    else {
                        Person player2 = player3 ;
                        player2.ID = O ;
                        player2.decideMove(board) ;
                    }
                    turn = X ;
                }
                
            }

            // Increment appropriate score
            scores.increment(board.status) ;

            // Display summary
            Console.Clear() ;
            Console.WriteLine(board.ToString()) ;
            Console.WriteLine("\nGame Over") ;
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