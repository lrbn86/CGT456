using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign03
{
    public partial class calc1 : System.Web.UI.Page
    {

        /*
         In this code, there will be 16 click event handlers
        */

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StoreDisplay(string fromDisplay)
        {
            Session["displayedValue"] = fromDisplay.ToString();
        }

        protected void Btn0_Click(object sender, EventArgs e)
        {
            display.Text = Btn0.Text.ToString();
            StoreDisplay(Btn0.Text.ToString());
        }

        protected void Btn1_Click(object sender, EventArgs e)
        {
            display.Text = Btn1.Text.ToString();
            StoreDisplay(Btn1.Text.ToString());
        }

        protected void Btn2_Click(object sender, EventArgs e)
        {
            display.Text = Btn2.Text.ToString();
            StoreDisplay(Btn2.Text.ToString());
        }

        protected void Btn3_Click(object sender, EventArgs e)
        {
            display.Text = Btn3.Text.ToString();
            StoreDisplay(Btn3.Text.ToString());
        }

        protected void Btn4_Click(object sender, EventArgs e)
        {
            display.Text = Btn4.Text.ToString();
            StoreDisplay(Btn4.Text.ToString());
        }

        protected void Btn5_Click(object sender, EventArgs e)
        {
            display.Text = Btn5.Text.ToString();
            StoreDisplay(Btn5.Text.ToString());
        }

        protected void Btn6_Click(object sender, EventArgs e)
        {
            display.Text = Btn6.Text.ToString();
            StoreDisplay(Btn6.Text.ToString());
        }

        protected void Btn7_Click(object sender, EventArgs e)
        {
            display.Text = Btn7.Text.ToString();
            StoreDisplay(Btn7.Text.ToString());
        }

        protected void Btn8_Click(object sender, EventArgs e)
        {
            display.Text = Btn8.Text.ToString();
            StoreDisplay(Btn8.Text.ToString());
        }

        protected void Btn9_Click(object sender, EventArgs e)
        {
            display.Text = Btn9.Text.ToString();
            StoreDisplay(Btn9.Text.ToString());
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Session["operand1"] = Session["displayedValue"];
            Session["operation"] = "add";
        }

        protected void BtnSubtract_Click(object sender, EventArgs e)
        {
            Session["operand1"] = Session["displayedValue"];
            Session["operation"] = "subtract";
        }

        protected void BtnMult_Click(object sender, EventArgs e)
        {
            Session["operand1"] = Session["displayedValue"];
            Session["operation"] = "multiply";
        }

        protected void BtnDiv_Click(object sender, EventArgs e)
        {
            Session["operand1"] = Session["displayedValue"];
            Session["operation"] = "divide";
        }

        protected void BtnEqual_Click(object sender, EventArgs e)
        {
            Session["operand2"] = Session["displayedValue"];

            // Store into variables to keep code smaller
            string operation = Session["operation"].ToString();
            int operand1 = Convert.ToInt32(Session["operand1"].ToString());
            int operand2 = Convert.ToInt32(Session["operand2"].ToString());

            if (operation == "add")
                display.Text = (operand1 + operand2).ToString();
            else if (operation == "subtract")
                display.Text = (operand1 - operand2).ToString();
            else if (operation == "multiply")
                display.Text = (operand1 * operand2).ToString();
            else if (operation == "divide")
                display.Text = (operand1 / operand2).ToString();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            display.Text = "";
            Session["operation"] = "";
            Session["operand1"] = "";
            Session["operand2"] = "";
            Session["displayedValue"] = "";
        }
    }
}