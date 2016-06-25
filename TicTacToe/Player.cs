//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: Player class                            //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System;

namespace TicTacToe {
    class Player {
        // Data Member
        public int ID { get ; set ; }   // X or O

        // Virtual method to decide move
        public virtual void decideMove(Board brd) {
            
        }
    }
}