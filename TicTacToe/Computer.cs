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
        public const int X          = (int)Constants.x          ;
        public const int O          = (int)Constants.o          ;
        public const int MAX        = (int)Constants.max        ;
        public const int EMPTY      = (int)Constants.empty      ;
        public const int EASY       = (int)Constants.easy       ;
        public const int HARD       = (int)Constants.hard       ;
        public const int IMPOSSIBLE = (int)Constants.impossible ;
        public const int CONTINUE   = (int)Constants.cont       ;

        // Data members
        public int difficulty { get ; set ; }
        private int[] corners = new int[4] ;
        Random rand = new Random() ;

        // Constructor
        public Computer() {
            corners[0] = 0 ;
            corners[1] = 2 ;
            corners[2] = 6 ;
            corners[3] = 8 ;
        }

        // Method decides easy move
        private void easyMove(Board brd, int[] avail, int size) {
            // Declare moved boolean
            bool moved = false ;

            // try to win
            moved = winBlock(brd, avail, size, ID);

            // Try to block win
            if(brd.status != ID && ! moved) {
                moved = winBlock(brd, avail, size, X);
            }

            // Make random move
            if(brd.status != ID && ! moved) {
                int spot = rand.Next(0, size);
                brd.setMove(avail[spot], ID);
                moved = true ;
            }
        }

        // Method to try to win or block win
        private bool winBlock(Board brd, int[] avail, int size, int who) {
            bool moved = false ;
            int element = 0 ;
            while(brd.status != who &&
                   element < size) {
                brd.setMove(avail[element], who) ;
                if(brd.status != who) {
                    brd.setMove(avail[element], EMPTY) ;
                }

                if(brd.status == who) {
                    brd.status = CONTINUE ;
                    brd.setMove(avail[element], ID) ;
                    moved = true ;
                    break ;
                }
                element++ ;
            } 
            return moved ;
        }

        // Method decides hard move
        private void hardMove(Board brd, int[] avail, int size) {
            // Declare moved boolean
            bool moved = false;

            // try to win
            moved = winBlock(brd, avail, size, ID);

            // Try to block win
            if(brd.status != ID && ! moved) {
                moved = winBlock(brd, avail, size, X);
            }

            // Try fork

            // Try block fork

            // Try center
            if (brd.status != ID &&
                brd.isValid(4) &&
                ! moved) {
                brd.setMove(4, ID) ;
            }

            // Try corner
            if(brd.status != ID) {
                int move = rand.Next(0, 5) ;
            }

            // Try Side
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