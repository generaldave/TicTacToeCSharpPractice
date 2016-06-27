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
        public const int MAX        = (int)Constants.max        ;
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
        public void startGame(bool computerAI, int difficulty) {
            // Initialize objects            
            player1.ID     = X        ;
            board.status   = CONTINUE ;
            board.reset() ;

            // Set turn to X
            turn = X ;

            // Play game
            while(board.status == CONTINUE) {
                // Clear screen and show board and scores
                Console.Clear() ;
                Console.WriteLine(board.ToString()) ;
                Console.WriteLine(scores.ToString()) ;

                // Show who's turn it is
                Console.WriteLine("\n{0}'s turn.", board.decideWho(turn)) ;

                // Player 1's turn
                if(player1.ID == turn) {
                    player1.decideMove(board);
                    turn = O ;
                }

                // Player 2's turn
                else {
                    if(computerAI) {
                        Computer player2 = (Computer)player3 ;
                        player2.ID = O ;
                        player2.difficulty = difficulty ;
                        player2.decideMove(board) ;
                        board.getStatus() ;
                    }
                    else {
                        Person player2 = player3 ;
                        player2.ID = O ;
                        player2.decideMove(board) ;
                    }
                    turn = X ;
                }                
            }

            // If difficulty = impossible and board.status = O
            // Fill board with O's and change winner
            if (computerAI == true &&
                difficulty == IMPOSSIBLE &&
                board.status == X) {
                    for(int i = 0 ; i < MAX ; i++) {
                        board.setMove(i, O) ;
                        board.getStatus() ;
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