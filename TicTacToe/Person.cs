//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: Person class - Derived from Player      //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System;

namespace TicTacToe {
    class Person : Player {
        // Method to decide move
        public override void decideMove(Board brd) {
            string choice ;
            Console.WriteLine("\nChoose move 0-8:") ;
            choice = Console.ReadLine() ;
            while(String.IsNullOrEmpty(choice) ||
                  Int32.Parse(choice) < 0 || 
                  Int32.Parse(choice) > 8 ||
                  ! brd.isValid(Int32.Parse(choice))) {
                Console.WriteLine("Invalid choice. Tray again") ;
                choice = Console.ReadLine();
            }
            brd.setMove(Int32.Parse(choice), ID);
        }
    }
}