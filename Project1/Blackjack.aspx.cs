﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{

    public partial class Blackjack : System.Web.UI.Page
    {

		private Random random = new Random(); // Used to generate a random integer.

		protected void Page_Load(object sender, EventArgs e)
        {
			// Set initial values for variables
			// Check that the Page is not executing after a postback (i.e. rendering for the first time)
			// This check is important because the variables will be set to initial values each events such as button clicks
			// which would prevent us to update or display variables appropriately.
			if (!Page.IsPostBack)
			{
				StartGame();
			}
        } // end Page_Load
		
		// Initialize variables and game states
		// Page_Load will call this method.
		protected void StartGame()
		{
			SetGameStatusMessage("Player is setting bet...");
			BetAmount.Text = "0";
            Session["maxBankAmount"] = "1000";
			BankAmount.Text = Session["maxBankAmount"].ToString();
			DealButton.Enabled = false;
			HitButton.Enabled = false;
			DoubleButton.Enabled = false;
			//QuitButton.Enabled = false;
			StandButton.Enabled = false;
			BetAmount.ReadOnly = true;
		} // end StartGame

		protected void EndGame()
		{
		} // end EndGame

		protected void NumPadClicked(object sender, EventArgs e)
		{
			DealerHand.Text = "0"; // Set Dealer's hand back to 0
			PlayerHand.Text = "0"; // Set Player's hand back to 0

			Button numButton = (Button)sender;
			int num = Convert.ToInt32(numButton.Text);

			int newBetAmount = Convert.ToInt32(BetAmount.Text + num.ToString()); // Concatenate digits and convert into an integer. Converting the string into integer also removes the leading zero (i.e. "0123" -> 123)
			int newBankAmount = (Convert.ToInt32(Session["maxBankAmount"]) - newBetAmount); // Calculate the new bank amount by subtracting the current bank amount to the new bet amount

			// Only display the new amounts when newBetAmount is less than newBankAmount
			if (newBetAmount < newBankAmount)
			{
				BetAmount.Text = newBetAmount.ToString();
				BankAmount.Text = newBankAmount.ToString();
			}

			// Enable the deal button if bet amount is greater than 0.
			if (Convert.ToInt32(BetAmount.Text) > 0)
            {
				DealButton.Enabled = true;
            }
		} // end NumPadClicked

		protected int GetRandomCard()
        {
			return random.Next(1, 10); // A random number will be generated/returned between 1 and 10 each time this function is called.
        }

		protected void AllInBet(object sender, EventArgs e)
		{
			BetAmount.Text = Session["maxBankAmount"].ToString(); // Set BetAmount textbox to display all from Bank
			BankAmount.Text = "0"; // Player bets all, the Bank should be empty.
			if (!BetAmount.Text.Equals("0"))
            {
				DealButton.Enabled = true; // Allow player to deal if the bet is more than 0.
            }
		} // end AllInBet
		
		protected void ClearBet(object sender, EventArgs e)
		{
			BetAmount.Text = "0"; // Clear bet amounts
			BankAmount.Text = Session["maxBankAmount"].ToString(); // Reset BankAmount (i.e. undo subtraction due to bet)
			DealButton.Enabled = false; // The player can no longer deal since bet amount is less than or equal to 0.
			EnableNumberButtons(); // Enable player to input digits into bet amount textbox.
		} // end ClearBet

		protected void Deal(object sender, EventArgs e)
		{
			SetGameStatusMessage("Player has locked in their bet. Select Hit, Stand, or Double.");
			AllInButton.Enabled = false; // The player can no longer place any more bets
			ClearBetButton.Enabled = false; // The player can no longer clear bets
			DisableNumberButtons();
			DealButton.Enabled = false; // The player can only deal once at a time

			HitButton.Enabled = true; // The player can now hit their current hand
			DoubleButton.Enabled = true; // The player can now double their bet. TODO
			StandButton.Enabled = true; // The player can now stand their current hand

			// Normally, the Dealer's hand will initally have one random card shown and one random card hidden
			// However, the Dealer will show both cards for simplicity sake.
			for (int i = 0; i < 2; i++)
            {
				DealerHand.Text = (Convert.ToInt32(DealerHand.Text) + GetRandomCard()).ToString();
            }

			// The player will initially have two random cards
			for (int i = 0; i < 2; i++)
            {
				PlayerHand.Text = (Convert.ToInt32(PlayerHand.Text) + GetRandomCard()).ToString();
            }

			// When player's hand is equal to dealer's hand, nothing happens and reset interface.
			if (Convert.ToInt32(PlayerHand.Text) == Convert.ToInt32(DealerHand.Text))
			{
				Tie();
			}

			// When player's hand is equal to dealer's hand, nothing happens and reset interface.
		} // end Deal

		protected void Hit(object sender, EventArgs e)
		{
			SetGameStatusMessage("Player have decided to hit. Continue to hit or stand?");
			// Player will choose to hit if they believe they can achieve blackjack or get a hand greater than Dealer's.

			PlayerHand.Text = (Convert.ToInt32(PlayerHand.Text) + GetRandomCard()).ToString(); // Each hit will increase Player's hand by a random amount between 1 and 10.

			// When player's hand is equal to dealer's hand, nothing happens and reset interface.
			if (Convert.ToInt32(PlayerHand.Text) == Convert.ToInt32(DealerHand.Text))
			{
				Tie();
			}
			else if (Convert.ToInt32(PlayerHand.Text) > 21) // If the Player's hand goes over 21, they have busted and lost their bet.
			{
				SetGameStatusMessage("Player busted. You have lost your bet. Continue playing by making another bet.");
				PlayerLost();
            } 
			else if (Convert.ToInt32(PlayerHand.Text) == 21) // The player hand hits a blackjack and wins
            {
				SetGameStatusMessage("Player hits Blackjack! You have won your bet. Continue playing by making another bet.");
				// The player will receive back the original bet and (1.5 * bet amount)
				Session["maxBankAmount"] = (Convert.ToInt32(Session["maxBankAmount"]) + (Convert.ToInt32(BetAmount.Text) * 1.5));
				BankAmount.Text = Session["maxBankAmount"].ToString();
				NewBet();
            }
		} // end Hit

		protected void Stand(object sender, EventArgs e)
		{
			SetGameStatusMessage("Player have decided to stand. Dealer will now reveal hand.");
			// Player will choose to stand if they believe they might bust if they hit one more time or confident that they will get a hand greater than Dealer's.
			HitButton.Enabled = false; // The player will no longer be able to hit.
			DisableNumberButtons(); // The player will no longer be able to input any digits

			
			// Dealer's hand will be fully revealed once player stands.
			// If the Dealer's hand is <= 16, then they must take a card.
			while (Convert.ToInt32(DealerHand.Text) <= 16)
            {
				DealerHand.Text = (Convert.ToInt32(DealerHand.Text) + GetRandomCard()).ToString(); // Dealer takes a random card (a random number)
            }

			// At this point, the Dealer will have a hand that is >= 17.
			//PlayerHand.Text = "21";
			DealerHand.Text = "21";

			// When player's hand is equal to dealer's hand, nothing happens and reset interface. (e.g. Player may have 17 and Dealer may have 17)
			if (Convert.ToInt32(PlayerHand.Text) == Convert.ToInt32(DealerHand.Text))
			{
				Tie();
			} 
			else
            {
				if (Convert.ToInt32(DealerHand.Text) > 21)
				{
					// Check whether the Dealer have busted (have a hand greater than 21)
					SetGameStatusMessage("Dealer busted. You have won your bet. Continue playing by making another bet.");
					// Dealer busted
					DealerLost();
				}
				else if (Convert.ToInt32(DealerHand.Text) < Convert.ToInt32(PlayerHand.Text) && Convert.ToInt32(PlayerHand.Text) < 21)
				{
					// Check whether the player's hand is greater than the dealer's hand (e.g. Dealer may have 17, but Player may have 19)
					SetGameStatusMessage("Dealer's hand is less than player's hand. You have won your bet. Continue playing by making another bet.");
					// Dealer's hand is less than player's hand and player did not bust
					DealerLost();
				}

				if (Convert.ToInt32(DealerHand.Text) == 21)
				{
					// If Dealer's hand is exactly 21, then they win a blackjack and Player loses bet.
					SetGameStatusMessage("Dealer hits Blackjack! You have lost your bet. Continue playing by making another bet.");
					// Dealer hits blackjack and wins
					PlayerLost();
				}
				else if (Convert.ToInt32(DealerHand.Text) > Convert.ToInt32(PlayerHand.Text) && Convert.ToInt32(DealerHand.Text) <= 21)
				{
					// Check whether dealer's hand is greater than player's hand (e.g. Dealer may have 17, but Player may have 16)
					SetGameStatusMessage("Dealer's hand is greater than player's hand. You have lost your bet. Contiue playing by making another bet.");
					// The Dealer's hand is greater than player's hand without busting
					PlayerLost();
				}
			}
		} // end Stand

		protected void Double(object sender, EventArgs e)
		{
			// Give player a chance to double their bet now that the hands are shown.
			// The player cannot undo betting double.
			BetAmount.Text = (Convert.ToInt32(BetAmount.Text) * 2).ToString();

			int newBetAmount = Convert.ToInt32(BetAmount.Text);
			int newBankAmount = Convert.ToInt32(BankAmount.Text) - newBetAmount;

			// Only display the new amounts when newBetAmount is less than newBankAmount
			if (newBetAmount <= newBankAmount)
			{
				BetAmount.Text = newBetAmount.ToString();
				BankAmount.Text = newBankAmount.ToString();
			}

			DoubleButton.Enabled = false; // They can only double once per bet.
		} // end Double

		//protected void Quit(object sender, EventArgs e)
		//{
		//} // end Quit

		protected void PlayerLost()
        {
			// Player lost conditions:
			// 1. Player busted
			// 2. Dealer's hand hit 21
			// 3. Dealer's hand is more than Player's hand, but the Dealer does not bust as well
			Session["maxBankAmount"] = BankAmount.Text;
			// Reset interface for new bet.
			NewBet();
		} // end PlayerLost

		protected void DealerLost()
        {
			// Dealer lost conditions:
			// 1. Dealer busted
			// 2. Dealer's hand is less than Player's hand
			Session["maxBankAmount"] = Convert.ToInt32(BankAmount.Text) + (Convert.ToInt32(BetAmount.Text) * 2);
			BankAmount.Text = Session["maxBankAmount"].ToString();
			// Reset interface for new bet.
			NewBet();
        } // end DealerLost

		protected void Tie()
        {
			BankAmount.Text = Session["maxBankAmount"].ToString();
			SetGameStatusMessage("Dealer and Player have the same hands. No wins or losses. Continue playing by making another bet.");
			NewBet();
        } // end Tie

		protected void NewBet()
        {
			BetAmount.Text = "0"; // Clear bet amount
			AllInButton.Enabled = true; // The player can now all in bet
			ClearBetButton.Enabled = true; // The player can now clear bet
			EnableNumberButtons(); // The player can now input digits

			DealButton.Enabled = false; // The player can no longer deal until a bet has been made.
			HitButton.Enabled = false; // The player can no longer hit until a bet has been made.
			DoubleButton.Enabled = false; // The player can no longer double until a bet has been made.
			StandButton.Enabled = false; // The player can no longer stand until a bet has been made.
        } // end NewBet

		protected void DisableNumberButtons()
        {
			// Disable all number buttons with this function call.
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

		protected void EnableNumberButtons()
        {
			// Enable all number buttons with this function call.
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

		// Set the status to let the player know the current state of the game.
		protected void SetGameStatusMessage(string status)
        {
			GameStatusMessage.Text = status;
        } // end SetGameStatusMessage
    }
}
