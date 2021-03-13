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
        private Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StopTimer();
                Session["maxTime"] = 100;
                ResetTimerDisplay();
            }
        }

        protected void StartGame(object sender, EventArgs e)
        {
            Message.Text = "";
            EnableNumberButtons();
            IncreaseTimeButton.Enabled = false;
            DecreaseTimeButton.Enabled = false;
            StartGameButton.Enabled = false;
            StartTimer();
            KeyLabel.Text = random.Next(0, 9).ToString();
        } // end StartGame

        protected void QuitGame(object sender, EventArgs e)
        {
            IncreaseTimeButton.Enabled = true;
            DecreaseTimeButton.Enabled = true;
            StartGameButton.Enabled = true;
            ResetTimerDisplay();
            StopTimer();
            ResetScore();
            KeyLabel.Text = "";
        } // end QuitGame

        protected void NumPadClicked(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(((Button)sender).Text);
            int expectedAnswer = Convert.ToInt32(KeyLabel.Text);
            
            // If player hits the right button, they get a score. Otherwise, they lose points and time.
            if (input == expectedAnswer)
            {
                IncreaseScore();
            } 
            else
            {
                DecreaseScore();
                DecreaseTime();
            }

            KeyLabel.Text = random.Next(0, 9).ToString(); // Get a new key
            RandomizeNumberButtons(); // Move the numbers around

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
                // TODO
                Message.Text = "Time's up!";
                KeyLabel.Text = "";
               // DisableNumberButtons();
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
    }
}