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

        // TODO: Prevent the player from clicking on the buttons while the color sequence is playing
        // TODO: Add a losing condition. Should the player continue playing or will there be a loss popup?
        // TODO: Add score, each successful guesses will give a score. There is no "win" condition as the game will continue forever until the player fails
        // TODO: Add number of tries left, maybe 3 max, after that it's game over
        // TODO: Add credits
        // TODO: Add the functionality of the player to guess correctly, separate function?
        // TODO: Add the ability to adjust game difficulty (may or may not implement this depending on mood)

        private SoundPlayer soundPlayer = new SoundPlayer(); // Used to play sound effects, it can be used anywhere in this class

        private int TIME = 1000; // Used when adjusting difficulty, shorter the time, the faster the color sequence will be played.
        // Difficulty:
        // 1000ms - Easy
        // 700ms - Mediuum
        // 300ms - Hard

        // This contains the main colors of the game. It will be used to generate a random color to be pushed into the correctColors List.
        private List<String> mainColors = new List<String>() {
            "green", "red", "orange", "blue"
        };

        // This List contains the colors to be played. It will be used to match/validate the player's inputs.
        // Each time the player guesses correctly, this List will add another random color
        private List<String> correctColors = new List<String>() {
            "green", "blue", "green", "orange", "red", "orange", "blue", "blue", "red", "green"
        };
     

        public MainWindow() {
            InitializeComponent();
            ResetFillButtons(); // Initially, the radial gradient is on the buttons, so remove it
        }

        private void Buttons_Click(object sender, RoutedEventArgs e) {

            // This function is called when the "buttons" are clicked/tapped on.
    
            Rectangle b = (Rectangle)sender;
            
            // Set the sound player stream to the appropriate sound effect according to which color
            if (b.Name.Equals("GreenButton")) {
                soundPlayer.Stream = Properties.Resources.G_note_octave_higher;
                Play_Color("green");
            } else if (b.Name.Equals("RedButton")) {
                soundPlayer.Stream = Properties.Resources.E_note;
                Play_Color("red");
            } else if (b.Name.Equals("OrangeButton")) {
                soundPlayer.Stream = Properties.Resources.C_note;
                Play_Color("orange");
            } else if (b.Name.Equals("BlueButton")) {
                soundPlayer.Stream = Properties.Resources.G_note;
                Play_Color("blue");
            }
            
        } // end Buttons_Click

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
            ResetFillButtons(); // Make the color buttons have solid color instead of radial gradient
            soundPlayer.Play();
        } // end Play_Color

        private void ResetFillButtons() {
            // Make all "buttons" to have solid color without radial gradient
            GreenButtonFill.Color = Colors.Green;
            RedButtonFill.Color = Colors.Red;
            OrangeButtonFill.Color = Colors.Orange;
            BlueButtonFill.Color = Colors.Blue;
        } // end ResetFillButtons

        private async void Play_Pattern() { // The function will be running asynchronously, this prevents UI main thread block

            await Task.Delay(1000); // 1 second delay to allow the player to prepare for color sequence to follow. This is used instead of Thread.Sleep because it would freeze everything. This will not block main thread.

            foreach (string color in correctColors) {
                Play_Color(color);
                await Task.Delay(TIME); // Give time for color sequence to play out, otherwise it would rapidly go through the list. This is used instead of Thread.Sleep because it would freeze everything. This will not block main thread.
                // TIME variable can be used if we want to adjust difficulty (e.g. shorter time between each color to be presented which may prove to be more difficult)
            }
        } // end Play_Pattern

        private void Start_Game(object sender, RoutedEventArgs e) {
            StartText.Visibility = Visibility.Hidden; // Remove the start text from view
            Play_Pattern(); // Start playing the pattern the player should follow
        } // end Start_Game

        private void Mouse_Enter(object sender, RoutedEventArgs e) {
            // For now, this function will change the opacity of the start text upon hover (e.g. CSS hover effect)
            StartText.Opacity = .8;
        } // end Mouse_Enter

        private void Mouse_Leave (object sender, RoutedEventArgs e) {
            // For now, this function will change the opacity of the start text when not hovering (e.g. CSS hover effect)
            StartText.Opacity = 1;
        } // end Mouse_Leave
    }
}
