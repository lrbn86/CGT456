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

		private bool canClick; // Use flag to determine whether the player can click on the colors

        private SoundPlayer soundPlayer; // Used to play sound effects, it can be used anywhere in this class

		// Holds the difficulty levels
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

        private List<String> playerColorsInput = new List<String>();
     

        public MainWindow() {

			// Initialize variables and UI
            InitializeComponent();
			mode = "easy";
            time = difficulty[mode];
            soundPlayer = new SoundPlayer();
			canClick = false;
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
            string color = "";
            
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

            playerColorsInput.Add(color);

            Play_Color(color);
            Validate_Player_Input(color);
            
        } // end Buttons_Click

        private void Start_Game(object sender, RoutedEventArgs e) {

            StartText.Visibility = Visibility.Hidden; // Remove the start text from view
            Play_Pattern(); // Start playing the pattern the player should follow
            correctColors.Add(Get_Random_Color()); // Add a random color into the color sequence

        } // end Start_Game

        private void Mouse_Enter(object sender, RoutedEventArgs e) {

            // For now, this function will change the opacity of the start text upon hover (e.g. CSS hover effect)
            StartText.Opacity = .8;

        } // end Mouse_Enter

        private void Mouse_Leave (object sender, RoutedEventArgs e) {

            // For now, this function will change the opacity of the start text when not hovering (e.g. CSS hover effect)
            StartText.Opacity = 1;

        } // end Mouse_Leave
		
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

        } // end Reset_Fill_Buttons

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

        }

        private async void Play_Pattern() { // The function will be running asynchronously, this prevents UI main thread block

			Disable_Color_Buttons();

            await Task.Delay(1000); // 1 second delay to allow the player to prepare for color sequence to follow. This is used instead of Thread.Sleep because it would freeze everything. This will not block main thread.

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

            Enable_Color_Buttons();

        } // end Play_Pattern

        // TODO: Add the functionality of the player to guess correctly, separate function?
		private void Validate_Player_Input(string color) {
            bool isCorrect = true;

            if (correctColors.Count == playerColorsInput.Count) {
                for (int i = 0; i < correctColors.Count; i++) {
                    if (correctColors[i] != playerColorsInput[i]) {
                        isCorrect = false;
                    }
                }
                if (isCorrect) {
                    Console.WriteLine("Correct");
                    correctColors.Add(Get_Random_Color());
                    playerColorsInput.Clear();
                    Play_Pattern();
                } else {
                    Console.WriteLine("Wrong");
                    playerColorsInput.Clear();
                    Play_Pattern();
                }
            }

		} // Validate_Player_Input

        // TODO: Add a losing condition. Should the player continue playing or will there be a loss popup?
		private void Game_Over() {
		} // end Game_Over

        // TODO: Add score, each successful guesses will give a score. There is no "win" condition as the game will continue forever until the player fails
		// This might be an event handler function
		private void Update_Score() {
		} // end Update_Score

        // TODO: Add number of tries left, maybe 3 max, after that it's game over
		// This might be an event handler function
		private void Update_Tries() {
		} // end Update_Tries

        // TODO: Add the ability to adjust game difficulty (may or may not implement this depending on mood)
		private void Set_Game_Difficulty() {
		} // Set_Game_Difficulty

        private String Get_Random_Color() {

            Random rnd = new Random();
            string color = mainColors[rnd.Next(0, mainColors.Count - 1)];
            return color;

        }

        // TODO: Add credits

		/////////// END UTILITY FUNCTIONS /////////// 

    } // end MainWindow

} // end namespace Project2
