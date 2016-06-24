//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: Score class                             //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System;

namespace TicTacToe {
    class Score {
        // Declare constants
        public const int X = (int)Constants.x ;
        public const int O = (int)Constants.o ;

        // Data members and properties
        public int xScore   { get ; set ; }
        public int yScore   { get ; set ; }
        public int catScore { get ; set ; }

        // Constructors
        public Score() { }
        public Score(int x, int y,int cat) {
            xScore   = x   ;
            yScore   = y   ;
            catScore = cat ;
        }

        // Method increments appropriate score
        public void increment(int who) {
            switch(who) {
                case X:
                    xScore++ ;
                    break ;
                case O:
                    yScore++ ;
                    break ;
                default:
                    catScore++ ;
                    break ;
            }
        }

        // Method resest all scores to 0
        public void reset() {
            xScore   = 0 ;
            yScore   = 0 ;
            catScore = 0 ;
        }

        // Method overrides ToString()
        public override string ToString() {
            return string.Format("\nX wins: {0}\nY wins: {1}\n  Cats: {2}", 
                                 xScore, yScore, catScore) ;
        }
    }
}