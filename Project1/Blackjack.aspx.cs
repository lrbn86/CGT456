using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class Blackjack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        } // end Page_Load
		
		// A playing card is represented as a string (e.g. 9 of clubs).
		// This array contains all these playing cards.
		int[] playingCards;
		
		protected void StartGame()
		{
		} // end StartGame

		protected void EndGame()
		{
		} // end EndGame

		protected void NumPadClicked(object sender, EventArgs e)
		{
			Button numButton = (Button)sender;
			int num = Convert.ToInt32(numButton.Text);
			BetAmount.Text = num.ToString();
		} // end NumPadClicked

		// Get a random playing card string from the playing card strings array
		protected string GetRandomCard()
		{
			return "";
		} // end GetRandomCard

		protected void AllInBet(object sender, EventArgs e)
		{
		} // end AllInBet
		
		protected void ClearBet(object sender, EventArgs e)
		{
		} // end ClearBet

		//protected void Deal(object sender, EventArgs e)
		//{
		//} // end Deal

		//protected void AddBet(object sender, EventArgs e)
		//{
		//} // end AddBet

		//protected void SubtractBet(object sender, EventArgs e)
		//{
		//} // end SubtractBet

		//protected void Hit(object sender, EventArgs e)
		//{
		//} // end Hit

		//protected void Double(object sender, EventArgs e)
		//{
		//} // end Double

		//protected void Split(object sender, EventArgs e)
		//{
		//} // end Split

		//protected void Stand(object sender, EventArgs e)
		//{
		//} // end Stand
    }
}
