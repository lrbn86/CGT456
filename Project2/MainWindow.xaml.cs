using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project2 {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private int numTries; // The player will have limited tries to guess the correct sequence

        private int score; // Although there is no "win" condition, this keeps track of how many correct guesses on the sequence

		private bool canClick; // Use flag to determine whether the player can click on the colors

        private SoundPlayer soundPlayer; // Used to play sound effects, it can be used anywhere in this class

		// Holds the difficulty levels (a string is mapped to an integer, in this case the difficulty is matched to the millseconds used for managing delays)
        // May be implemented in the future..., but the default difficulty will be "easy" and can only be configured here for now.
		Dictionary<string, int> difficulty = new Dictionary<string, int>() {
			{"easy", 1000}, {"medium", 700}, {"hard", 300}
		};

		private string mode; // Use this variable to set the difficulty (e.g. if mode = "easy", then the sequence will be played slower with 1000ms delay)

        private int time; // Used when adjusting difficulty, shorter the time, the faster the color sequence will be played.

        // This contains the main colors of the game. It will be used to generate a random color to be pushed into the correctColors List.
        private List<String> mainColors = new List<String>() {
            "green", "red", "orange", "blue"
        };

        // This List contains the colors to be played. It will be used to match/validate the player's inputs.
        // Each time the player guesses correctly, this List will add another random color
        private List<String> correctColors = new List<String>();

        // This List contains the colors the player has clicked/tapped on. It should be cleared every time the player got the sequence right or wrong.
        private List<String> playerColorsInput = new List<String>();
     

        public MainWindow() {

			// Initialize variables and user interface
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Start up the window in the center of the screen instead of the default at the corner.
			mode = "easy"; // Future implementation would player to configure difficulty
            time = difficulty[mode]; // Future implementation would allow player to configure difficulty
            soundPlayer = new SoundPlayer(); // Used to play sounds
			canClick = false; // Set to determine whether player can click on the solid colors
            numTries = 3; // The player only has 3 tries, future implementations would allow player to configure this
            score = 0; // Initially, the player has no score
            StatusText.Text = ""; // Clear status text
            ScoreText.Text = score.ToString(); // Set the score display to show the appropriate variable
            TriesText.Text = numTries.ToString(); // Set the tries display to show the appropriate variable
            StatusText.Visibility = Visibility.Hidden; // Initially, the player cannot see the status text
			Disable_Color_Buttons(); // Remove the hand cursor on the color buttons
            Reset_Fill_Color_Buttons(); // Initially, the radial gradient is on the buttons, so remove it

        } // end MainWindow

		/////////// BEGIN EVENT HANDLERS /////////// 

        private void Buttons_Click(object sender, RoutedEventArgs e) {

			// The player cannot click on the colors if the sequencing is playing
			if (!canClick) {
				return;
			}

            // This function is called when the "buttons" are clicked/tapped on.
    
            Rectangle b = (Rectangle)sender;
            string color = ""; // Used to determine which color was clicked
            
            // Set the sound player stream to the appropriate sound effect according to which color
            if (b.Name.Equals("GreenButton")) {
                soundPlayer.Stream = Properties.Resources.G_note_octave_higher;
                color = "green";
            } else if (b.Name.Equals("RedButton")) {
                soundPlayer.Stream = Properties.Resources.E_note;
                color = "red";
            } else if (b.Name.Equals("OrangeButton")) {
                soundPlayer.Stream = Properties.Resources.C_note;
                color = "orange";
            } else if (b.Name.Equals("BlueButton")) {
                soundPlayer.Stream = Properties.Resources.G_note;
                color = "blue";
            }

            playerColorsInput.Add(color); // Store all player's colors that have been clicked on

            Play_Color(color); // Play the sound and highlight that color
            Validate_Player_Input(); // See if the player's last color click would be correct
            
        } // end Buttons_Click

        private void Start_Game(object sender, RoutedEventArgs e) {
            Reset_Game();
            StatusText.Visibility = Visibility.Visible;
            StatusText.FontSize = 24;
            StatusText.Text = "Ready?";
            Play_Pattern(); // Start playing the pattern the player should follow
            correctColors.Add(Get_Random_Color()); // Add a random color into the color sequence

        } // end Start_Game

		/////////// END EVENT HANDLERS /////////// 

		/////////// BEGIN UTILITY FUNCTIONS /////////// 

        private async void Play_Color(string color) { // The function will be running asynchronously, this prevents UI main thread block

            // This function is called to create an illusion of a button being clicked/tapped on and sound effect will be played

            // Set the sound player stream to the appropriate sound effect according to which color
            switch(color) {
                case "green":
                    soundPlayer.Stream = Properties.Resources.G_note_octave_higher;
                    GreenButtonFill.Color = Colors.White;
                    break;
                case "red":
                    soundPlayer.Stream = Properties.Resources.E_note;
                    RedButtonFill.Color = Colors.White;
                    break;
                case "orange":
                    soundPlayer.Stream = Properties.Resources.C_note;
                    OrangeButtonFill.Color = Colors.White;
                    break;
                case "blue":
                    soundPlayer.Stream = Properties.Resources.G_note;
                    BlueButtonFill.Color = Colors.White;
                    break;
                default:
                    Console.WriteLine("Unknown Color"); // Highly unlikely the player will input a color that is not green, red, orange, or blue, but this is for defensive programming
                    break;
            }

            await Task.Delay(100); // 100ms delay give time for the radial gradient to show up. This is used instead of Thread.Sleep because it would freeze everything. This will not block main thread.
            Reset_Fill_Color_Buttons(); // Make the color buttons have solid color instead of radial gradient
            soundPlayer.Play();

        } // end Play_Color

        private void Reset_Fill_Color_Buttons() {

            // Make all "buttons" to have solid color without radial gradient
            GreenButtonFill.Color = Colors.Green;
            RedButtonFill.Color = Colors.Red;
            OrangeButtonFill.Color = Colors.Orange;
            BlueButtonFill.Color = Colors.Blue;

        } // end Reset_Fill_Color_Buttons

		private void Disable_Color_Buttons() {

			canClick = false; // The player cannot click on the colors

            // This function removes the cursor hand on the colors. It is used when the player cannot click on the colors;

            GreenButton.Cursor = Cursors.Arrow;
			RedButton.Cursor = Cursors.Arrow;
			OrangeButton.Cursor = Cursors.Arrow;
			BlueButton.Cursor = Cursors.Arrow;

		} // end Disable_Fill_Buttons

        private void Enable_Color_Buttons() {

			canClick = true; // The player can click on the colors

            // This function removes the cursor hand on the colors. It is used when the player cannot click on the colors;

            GreenButton.Cursor = Cursors.Hand;
			RedButton.Cursor = Cursors.Hand;
			OrangeButton.Cursor = Cursors.Hand;
			BlueButton.Cursor = Cursors.Hand;

        } // end Enable_Color_Buttons

        private async void Play_Pattern() { // The function will be running asynchronously, this prevents UI main thread block

			Disable_Color_Buttons();

            await Task.Delay(2000);
            StatusText.Text = "Follow";

            // For debugging purposes if there are no colors to sequence through
            if (correctColors.Count <= 0) {
                Console.WriteLine("There are no colors to play!");
                return;
            }

			// Play the color sequence/pattern
            foreach (string color in correctColors) {
                Play_Color(color);
                await Task.Delay(time); // Give time for color sequence to play out, otherwise it would rapidly go through the list. This is used instead of Thread.Sleep because it would freeze everything. This will not block main thread.
                // time variable can be used if we want to adjust difficulty (e.g. shorter time between each color to be presented which may prove to be more difficult)
            }

            StatusText.Text = "Your Turn";
            Enable_Color_Buttons();

        } // end Play_Pattern

		private void Validate_Player_Input() {

            Enable_Color_Buttons(); // If the player did get incorrect sequence guess, then renable the buttons

            // This function is responsibile for checking if the player is clicking/tapping the correct colors sequence

            // This loop checks to see if the player is on the right track. It gives an immediate feedback if the player inputs a color that is not in order or in the correctColors list
            if (playerColorsInput.Count <= correctColors.Count) {
                for (int i = 0; i < playerColorsInput.Count; i++) {
                    if (playerColorsInput[i] != correctColors[i]) {
                        Disable_Color_Buttons(); // Prevent player from clicking on the color buttons when the player is incorrect (e.g. prevent the player from rapidly clicking on the color button)
                        Update_Tries();
                        if (Is_Game_Over()) {
                            return;
                        }
                        Show_Status("Try again!", 18);
                        playerColorsInput.Clear(); // Clear player inputs
                        Play_Pattern(); // Replay the pattern sequence because the player was wrong
                        return; // Return to caller (i.e. prevent from executing the code below)
                    }
                }
            }

            // Otherwise, the player is on the right track
            if (correctColors.Count == playerColorsInput.Count) {
                Update_Score();
                Show_Status("OK!", 24);
                correctColors.Add(Get_Random_Color()); // Add a random color
                playerColorsInput.Clear(); // Clear player inputs
                Play_Pattern(); // Play the pattern with the new color added
            }

		} // end Validate_Player_Input

		private bool Is_Game_Over() {

            // This function will be used if the game is over. In this case, if the numTries is <= 0, then tell the player the game is over and disable the buttons
            // Allow the player to replay the game.

            if (numTries <= 0) {
                StatusText.FontSize = 14;
                StatusText.Text = "GAME OVER";
                StartGame.Content = "Play Again";
                StartGame.IsEnabled = true;
                Disable_Color_Buttons();
                return true;
            }
            return false;

		} // end Is_Game_Over

        // Add score, each successful guesses will give a score. There is no "win" condition as the game will continue forever until the player fails
		private void Update_Score() {

            score++;
            ScoreText.Text = score.ToString();

		} // end Update_Score

        // Add number of tries left, maybe 3 max, after that it's game over
		private void Update_Tries() {

            numTries--;
            TriesText.Text = numTries.ToString();

		} // end Update_Tries

        private string Get_Random_Color() {

            // This function generates a random color string (e.g. 'red', 'yellow', 'blue', or 'green')

            Random rnd = new Random();
            string color = mainColors[rnd.Next(0, mainColors.Count - 1)];
            return color;

        } // end Get_Random_Color

        private async void Show_Status(string status, int fontSize) {
            // This function show indicators of whether the player guessed correctly or not. It is shown in the middle.
            StatusText.Text = status;
            StatusText.FontSize = fontSize;
            await Task.Delay(1000);
            StatusText.Text = "";
            StatusText.FontSize = 24; // Reset to default font size.
        } // end Show_Status

        private void Print_List(List<String> list) {

            // This function helps to debug the list contents
            Console.WriteLine("[" + String.Join(", ", list) + "]");

        } // end Print_List

        private void Reset_Game() {
            // This function resets score and tries and clears out the lists. This is used when we are playing a new game.
            numTries = 3;
            score = 0;
            ScoreText.Text = score.ToString();
            TriesText.Text = numTries.ToString();
            correctColors.Clear();
            playerColorsInput.Clear();
            StartGame.IsEnabled = false;
            StatusText.Text = "";
        } // end Reset_Game

        /////////// END UTILITY FUNCTIONS /////////// 

    } // end MainWindow

} // end namespace Project2
