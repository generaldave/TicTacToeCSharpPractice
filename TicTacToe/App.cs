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
        // Declare Constants
        public const int EASY = (int)Constants.easy ;
        public const int HARD = (int)Constants.hard ;
        public const int IMPOSSIBLE = (int)Constants.impossible ;

        // Method validates choice
        private static string validateChoice(string choice, int min, int max) {
            while(String.IsNullOrEmpty(choice) ||
                   Int32.Parse(choice) < min ||
                   Int32.Parse(choice) > max) {
                Console.WriteLine("Invalid choice. Tray again");
                choice = Console.ReadLine();
            }
            return choice ;
        }

        // Method gathers user input for PVP or PVC
        public static int playerOrComputer() {
            string choice ;
            Console.WriteLine("0: vs. Player");
            Console.WriteLine("1: vs. Computer") ;
            choice = Console.ReadLine() ;
            validateChoice(choice, 0, 1) ;
            return Int32.Parse(choice);
        }

        // Method gathers user input for difficulty settings
        public static int chooseDifficulty() {
            string choice ;
            Console.WriteLine("\n0: Easy") ;
            Console.WriteLine("1: Hard") ;
            Console.WriteLine("2: Impossible") ;
            choice = Console.ReadLine() ;
            validateChoice(choice, 0, 2) ;
            switch(Int32.Parse(choice)) {
                case 0:
                    choice = EASY.ToString() ;
                    break ;
                case 1:
                    choice = HARD.ToString() ;
                    break ;
                case 2:
                    choice = IMPOSSIBLE.ToString() ;
                    break ;
            }
            return Int32.Parse(choice) ;
        }

        // Method gathers user input for main menu
        public static int mainMenu() {
            string choice ;
            Console.WriteLine("\n0: New Game") ;
            Console.WriteLine("1: Reset Scores") ;
            Console.WriteLine("2: Exit") ;
            Console.WriteLine("Choose 0-2: ") ;
            choice = Console.ReadLine() ;
            validateChoice(choice, 0, 2) ;
            return Int32.Parse(choice) ;
        }
        
        // Main method - starts program
        static void Main(string[] args) {
            // Declare main Game object
            Game game = new Game() ;
            
            // Declare variable for menu input
            int choice ;
            int difficulty = EASY ;

            // Gather user input for vs player or computer
            choice = playerOrComputer() ;

            // Set vs. Player or Computer
            bool computerAI = (choice == 0 ? false : true) ;

            // If vs. Computer choose difficulty
            if(computerAI) {
                difficulty = chooseDifficulty() ;
            }

            // Gather user input for main menu
            choice = mainMenu() ;

            // Play game, reset scores, or exit
            while(choice != 2) {
                switch(choice) {
                    case 0:
                        game.startGame(computerAI, difficulty) ;
                        break ;
                    case 1:
                        game.resetScores() ;
                        break ;
                }

                // Gather user input
                choice = mainMenu() ;
            }

            // Display exiting message
            Console.WriteLine("\nThank you for playing.") ;
            Console.WriteLine("\nPress enter to exit . . .") ;

            // Pause to capture output
            Console.ReadLine() ;
        }
    }
}