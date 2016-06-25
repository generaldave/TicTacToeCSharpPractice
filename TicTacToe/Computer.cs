//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: Computer class - Derived from Player    //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System ;

namespace TicTacToe {
    class Computer : Player {
        // Declare constants
        public const int EASY       = (int)Constants.easy       ;
        public const int HARD       = (int)Constants.hard       ;
        public const int IMPOSSIBLE = (int)Constants.impossible ;

        // Data member
        public int difficulty { get ; set ; }

        // Method decides easy move
        private void easyMove(Board brd) {
        
        }

        // Method decides hard move
        private void hardMove(Board brd) {
        
        }

        // Method to decide move
        public override void decideMove(Board brd) {
            if (difficulty == EASY) {
                easyMove(brd) ;
            }

            if (difficulty == HARD ||
                difficulty == IMPOSSIBLE) {
                hardMove(brd) ;
            }
            brd.setMove(0, ID) ;
        }

        // Explicitly convert Person to Computer
        public static explicit operator Computer(Person prsn) {
            Computer cptr = new Computer() ;
            return cptr ;
        }
    }
}