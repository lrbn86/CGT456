using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class TapNumbers : System.Web.UI.Page
    {
        private Random random = new Random(); // This will be used to generate random integers. 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StopTimer(); // The timer will initally not be running
                Session["maxTime"] = 100; // Set the max (initial) time to be 100
                ResetTimerDisplay(); // Reset the timer
                DisableNumberButtons(); // Disable the number buttons
                QuitGameButton.Enabled = false; // The quit game button will not be clickable
                QuitGameButton.Visible = false; // The quit game button will not be viewable
            }
        }

        protected void StartGame(object sender, EventArgs e)
        {
            Introduction.Visible = false; // The game introduction message will no longer be in view
            GameDifficulty.Visible = false; // The game difficulty selection will no longer be in view
            Message.Text = "Tap the number that corresponds to the number in the white box.";
            SetGameDifficulty();
            EnableNumberButtons(); // Enable the number buttons
            IncreaseTimeButton.Enabled = false; // The player can no longer increase the time
            DecreaseTimeButton.Enabled = false; // The player can no longer decrease the time
            StartGameButton.Enabled = false; // The player can no longer the start the game because the game is already playing
            StartGameButton.Visible = false; // The player can no longer see the start game button
            IncreaseTimeButton.Visible = false; // The player can no longer see the increase timer button
            DecreaseTimeButton.Visible = false; // The player can no longer see the decrease timer button
            QuitGameButton.Enabled = true; // The quit game button is now clickable
            QuitGameButton.Visible = true; // The quit game button will now be viewable
            StartTimer(); // Start the timer
            KeyLabel.Text = random.Next(0, 9).ToString(); // A randon number will be shown in the key label
        } // end StartGame

        // This function is called when the player clicks the Quit Game button
        protected void QuitGame(object sender, EventArgs e)
        {
            Introduction.Visible = true; // Bring back the game introduction message into view
            GameDifficulty.Visible = true; // Bring back the game difficulty selection into view
            IncreaseTimeButton.Enabled = true; // Enable the increase timer button
            DecreaseTimeButton.Enabled = true; // Enable the decrease timer button
            StartGameButton.Enabled = true; // Enable the start game button
            StartGameButton.Visible = true; // Bring back the start game button into view
            IncreaseTimeButton.Visible = true; // Bring back the increase timer button back into view
            DecreaseTimeButton.Visible = true; // Bring back the decrease timer button back into view
            QuitGameButton.Enabled = false; // The quit game button will not be clickable
            QuitGameButton.Visible = false; // The quit game button will not be viewable
            DisableNumberButtons(); // Disable the number buttons
            ResetTimerDisplay(); // Reset the timer
            StopTimer(); // Stop the timer
            ResetScore(); // Reset the score
            Message.Text = "You have quit the current game session. Click 'Start Game' for a new game session.";
            KeyLabel.Text = "";
        } // end QuitGame

        // This function is called whenever a number button is clicked
        // It will also resolve whether the player tapped the right number
        protected void NumPadClicked(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(((Button)sender).Text); // Cast the clicked number button into an integer 
            int expectedAnswer = Convert.ToInt32(KeyLabel.Text); // Grab the key label integer
            
            // If player hits the right button, they get increased score. Otherwise, they lose time.
            if (input == expectedAnswer)
            {
                string[] correctAnswerMessages = { "Nice!", "Great Job!", "You got it!" };
                IncreaseScore();
                Message.Text = correctAnswerMessages[random.Next(0, correctAnswerMessages.Length)];
            } 
            else
            {
                string[] wrongAnswerMessages = { "You lost time!", "Be careful!", "Uh-oh!" };
                Message.Text = wrongAnswerMessages[random.Next(0, wrongAnswerMessages.Length)];
                DecreaseScore();
                DecreaseTime();
            }

            KeyLabel.Text = random.Next(0, 9).ToString(); // Get a new key
            RandomizeNumberButtons(); // Move the numbers around in the number buttons

        } // end NumPadClicked

        // This function moves numbers in the number buttons around randomly
        // The use of list, list.remove, and random allows the number buttons to be unique, but still in the range of 1-10
        protected void RandomizeNumberButtons()
        {
            List<int> nums = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Button0.Text = random.Next(0, nums.Count()).ToString();
            nums.Remove(Convert.ToInt32(Button0.Text));
            Button1.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button1.Text));
            Button2.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button2.Text));
            Button3.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button3.Text));
            Button4.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button4.Text));
            Button5.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button5.Text));
            Button6.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button6.Text));
            Button7.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button7.Text));
            Button8.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button8.Text));
            Button9.Text = nums[random.Next(0, nums.Count())].ToString();
            nums.Remove(Convert.ToInt32(Button9.Text));
        } // end RandomizeNumberButtons

        // This function gets called every interval defined in the aspx file from the Timer control
        protected void Count_Down(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TimerLabel.Text) <= 0)
            {
                // The game is over when the timer reaches 0
                Message.Text = "Time's up! Your final score is shown below. You may now tap the 'Quit Game'";
                KeyLabel.Text = "";
                DisableNumberButtons();
            }

            // Keep decreasing time by one, but make sure it doesn't go below 0.
            if (Convert.ToInt32(TimerLabel.Text) > 0)
            {
                TimerLabel.Text = (Convert.ToInt32(TimerLabel.Text) - 1).ToString();
            }
        } // end Count_Down

        // This function starts the timer.
        protected void StartTimer()
        {
            Timer1.Enabled = true;
        } // end StartTimer

        // This function stops the timer.
        protected void StopTimer()
        {
            Timer1.Enabled = false;
        } // end StopTimer

        // This function increases the timer by 30
        protected void IncreaseTimer(object sender, EventArgs e)
        {
            TimerLabel.Text = (Convert.ToInt32(TimerLabel.Text) + 30).ToString();
            UpdateMaxTimeDisplay();
        } // end IncreaseTimer

        // This function decreases the timer by 30
        protected void DecreaseTimer(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TimerLabel.Text) - 30 > 0 && Convert.ToInt32(TimerLabel.Text) - 30 != 0)
            {
                TimerLabel.Text = (Convert.ToInt32(TimerLabel.Text) - 30).ToString();
                UpdateMaxTimeDisplay();
            }

        } // end DecreaseTimer

        // This function updates the session variable maxTime based on the timer label text
        protected void UpdateMaxTimeDisplay()
        {
            Session["maxTime"] = TimerLabel.Text;
        } // end UpdateMaxTimeDisplay

        // This function resets the timer display (e.g. if player sets timer to be 60, the timer will reset back to 60)
        protected void ResetTimerDisplay()
        {
            TimerLabel.Text = Session["maxTime"].ToString();
        } // end ResetTimerDisplay

        // This function is used to disable all the number buttons.
        protected void DisableNumberButtons()
        {
            Button0.Enabled = false;
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;
            Button9.Enabled = false;
        } // end DisableNumberButtons

        // This function is used to enable all the number buttons.
        protected void EnableNumberButtons()
        {
            Button0.Enabled = true;
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
            Button7.Enabled = true;
            Button8.Enabled = true;
            Button9.Enabled = true;
        } // end EnableNumberButtons

        // This function increases the score by 10
        protected void IncreaseScore()
        {
            ScoreLabel.Text = (Convert.ToInt32(ScoreLabel.Text) + 10).ToString();
        } // end IncreaseScore

        // This function decreases the score by 10, but makes sure it doesn't drop below 0
        protected void DecreaseScore()
        {
            if (Convert.ToInt32(ScoreLabel.Text) - 10 >= 0)
            {
                ScoreLabel.Text = (Convert.ToInt32(ScoreLabel.Text) - 10).ToString();
            }
        } // end DecreaseScore

        // This function resets the score back to 0
        protected void ResetScore()
        {
            ScoreLabel.Text = "0";
        } // end ResetScore

        // This function decreases time (not by button)
        protected void DecreaseTime()
        {
            if (Convert.ToInt32(TimerLabel.Text) - 30 > 0 && Convert.ToInt32(TimerLabel.Text) - 30 != 0)
            {
                TimerLabel.Text = (Convert.ToInt32(TimerLabel.Text) - 30).ToString();
            }
            else if (Convert.ToInt32(TimerLabel.Text) - 30 <= 0)
            {
                TimerLabel.Text = "0";
            }
        } // end DecreaseTime

        protected void SetGameDifficulty()
        {
            if (EasyMode.Checked)
            {
                Timer1.Interval = 1000;
            }
            else if (MediumMode.Checked)
            {
                Timer1.Interval = 600;
            }
            else if (HardMode.Checked)
            {
                Timer1.Interval = 300;
            }
        }
    }
}