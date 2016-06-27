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
        private int[] sides   = new int[4] ;
        Random rand = new Random() ;

        // Constructor
        public Computer() {
            corners[0] = 0 ;
            corners[1] = 2 ;
            corners[2] = 6 ;
            corners[3] = 8 ;

            sides[0] = 1 ;
            sides[1] = 3 ;
            sides[2] = 5 ;
            sides[3] = 7 ;
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

        // Method tries center
        private bool center(Board brd, int who) {
            bool moved = false ;
            if(brd.isValid(4)) {
                brd.setMove(4, who) ;
                moved = true ;
            }
            return moved ;
        }

        // Method choose random side or corner
        private bool cornerSide(Board brd, int[] arr, int who) {
            bool moved = false ;
            int move = rand.Next(0, 4);
            while(!brd.isValid(arr[move])) {
                move = rand.Next(0, 5);
            }
            brd.setMove(arr[move], ID);
            moved = true;
            return moved ;
        }

        // Method decides easy move
        private void easyMove(Board brd, int[] avail, int size) {
            // Declare moved boolean
            bool moved = false ;

            // try to win
            moved = winBlock(brd, avail, size, ID) ;

            // Try to block win
            if(!moved) {
                moved = winBlock(brd, avail, size, X) ;
            }

            // Make random move
            if(!moved) {
                int spot = rand.Next(0, size) ;
                brd.setMove(avail[spot], ID) ;
                moved = true ;
            }
        }

        // Method decides hard move
        private void hardMove(Board brd, int[] avail, int size) {
            // Declare moved boolean
            bool moved = false;

            // try to win
            moved = winBlock(brd, avail, size, ID);

            // Try to block win
            if(! moved) {
                moved = winBlock(brd, avail, size, X);
            }

            // Try fork

            // Try block fork

            // Try center
            if (! moved) {
                moved = center(brd, ID) ;                
            }

            // Try corner
            if(! moved) {
                moved = cornerSide(brd, corners, ID) ;                
            }

            // Try Side
            if(! moved) {
                moved = cornerSide(brd, sides, ID);
            }
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