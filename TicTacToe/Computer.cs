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
using System.Collections.Generic ;

namespace TicTacToe {
    class Computer : Player {
        // Declare constants
        public const int MAX        = (int)Constants.max        ;
        public const int EASY       = (int)Constants.easy       ;
        public const int HARD       = (int)Constants.hard       ;
        public const int IMPOSSIBLE = (int)Constants.impossible ;

        // Data member
        public int difficulty { get ; set ; }
        Random rand = new Random() ;

        // Method decides easy move
        private void easyMove(Board brd, int[] avail, int size) {
            int spot = rand.Next(0, size) ;
            brd.setMove(avail[spot], ID) ;
        }

        // Method decides hard move
        private void hardMove(Board brd, int[] avail, int size) {
        
        }

        // Method to decide move
        public override void decideMove(Board brd) {
            // Find available spaces
            List<int> avail = new List<int>() ;
            int size = 0 ;
            for(int i = 0 ; i < MAX ; i++) {
                if(brd.isValid(i)) {
                    avail.Add(i) ;
                    size++ ;
                }
            }

            // Easy move
            if (difficulty == EASY) {
                easyMove(brd, avail.ToArray(), size) ;
            }

            // Hard or impossible move
            if (difficulty == HARD ||
                difficulty == IMPOSSIBLE) {
                hardMove(brd, avail.ToArray(), size) ;
            }
        }

        // Explicitly convert Person to Computer
        public static explicit operator Computer(Person prsn) {
            Computer cptr = new Computer() ;
            return cptr ;
        }
    }
}