//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: Board class                             //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System ;

namespace TicTacToe {
    class Board {
        // Declare constants
        private const int MAX      = (int)Constants.max   ;
        private const int X        = (int)Constants.x     ;
        private const int O        = (int)Constants.o     ;
        private const int FULL     = (int)Constants.full  ;
        private const int CONTINUE = (int)Constants.cont  ;
        private const int EMPTY    = (int)Constants.empty ;
    
        // Data members
        private int[] gameBoard = new int[MAX] ;
        public int status { get ; set ; }

        // Constructor
        public Board() {
            reset() ;
        }

        // Method resest board
        public void reset() {
            for(int i = 0 ; i < MAX ; i++) {
                gameBoard[i] = 0 ;
            }
        }

        // Method decides if move is valid
        public bool isValid(int index) {
            return (index >= 0 && index < MAX && gameBoard[index] == EMPTY) ? true : false ;
        }

        // Method comits move to gameBoard
        public void setMove(int index, int who) {
            gameBoard[index] = who ;
            this.getStatus() ;
        }

        // Method decides whether gameBoard is full or not
        private bool isFull() {
            bool full = true ;
            for(int i= 0 ; i < MAX ; i++) {
                if(gameBoard[i] == EMPTY) {
                    full = false ;
                }
            }
            return full ;
        }

        // Method sets status of gameBoard
        private void getStatus() {
            // Did someone win
            if(((gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2]) ||
                (gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6])) &&
                gameBoard[0] !=EMPTY) {
                status = gameBoard[0] ;
            }

            if(((gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[5]) ||
                (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6]) ||
                (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7]) ||
                (gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5])) &&
                gameBoard[4] != EMPTY) {
                status = gameBoard[4];
            }

            if(((gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8]) ||
                (gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8])) &&
                gameBoard[8] != EMPTY) {
                status = gameBoard[8];
            }

            // Is board full = cat
            if(isFull() && status == CONTINUE) {
                status = FULL ;
            }

            // Else continue
            if(status != X &&
               status != O &&
               status != FULL) {
                status = CONTINUE ;
            }
        }

        // Method decides X, O, or space
        public string decideWho(int who) {
            switch(who) {
                case X:
                    return "X" ;
                case O:
                    return "O" ;
                default:
                    return " " ;
            }
        }

        // Method overrides ToString()
        public override string ToString() {
            // Convert board to string array
            string[] strBoard = new string[MAX] ;
            for(int i = 0 ; i < MAX ; i++) {
                strBoard[i] = decideWho(gameBoard[i]) ;
            }


            return string.Format(" {0} | {1} | {2}\n-----------\n {3} | {4} | {5}\n-----------\n {6} | {7} | {8}", 
                                 strBoard[0], strBoard[1], strBoard[2],
                                 strBoard[3], strBoard[4], strBoard[5],
                                 strBoard[6], strBoard[7], strBoard[8]) ;
        }
    }
}