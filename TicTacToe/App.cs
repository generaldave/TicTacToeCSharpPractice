//////////////////////////////////////////////////////////
//                                                      //
// David Fuller                                         //
//                                                      //
// Tic Tac Toe: App class starts game                   //
//                                                      //
// 6-23-2016                                            //
//                                                      //
//////////////////////////////////////////////////////////

using System ;

namespace TicTacToe {
    class App {
        // Method gathers user input
        public static int userInput() {
            string choice ;
            Console.WriteLine("0: New Game") ;
            Console.WriteLine("1: Reset Scores") ;
            Console.WriteLine("2: Exit") ;
            Console.WriteLine("Choose 0-2: ") ;
            choice = Console.ReadLine() ;
            return Int32.Parse(choice) ;
        }
        
        // Main method - starts program
        static void Main(string[] args) {
            // Declare main Game object
            Game game = new Game() ;
            
            // Declare variable for menu input
            int choice ;

            // Gather user input
            choice = userInput() ;

            // Decide what to do with user input
            while(choice != 2) {
                switch(choice) {
                    case 0:
                        game.startGame() ;
                        break ;
                    case 1:
                        game.resetScores() ;
                        break ;
                }

                // Gather user input
                choice = userInput() ;
            }

            // Display exiting message
            Console.WriteLine("\nThank you for playing.") ;
            Console.WriteLine("\nPress enter to exit . . .") ;

            // Pause to capture output
            Console.ReadLine() ;
        }
    }
}