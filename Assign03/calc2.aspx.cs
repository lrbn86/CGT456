using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign03
{
    public partial class calc2 : System.Web.UI.Page
    {
        /*
         In this code, there will be 4 event handlers compared to calc1.aspx.cs
        */
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StoreDisplay(string fromDisplay)
        {
            Session["operand"] = fromDisplay.ToString();
        }

        protected void BtnClicked(object sender, EventArgs e)
        {
            Button myBtn = (Button)sender;
            display.Text = myBtn.Text.ToString();
            StoreDisplay(myBtn.Text.ToString());
        }

        protected void OperationClicked(object sender, EventArgs e)
        {
            Session["operand1"] = Session["operand"];
            Button myBtn = (Button)sender;
            Session["operation"] = myBtn.Text.ToString();
        }

        protected void BtnEqual_Click(object sender, EventArgs e)
        {
            Session["operand2"] = Session["operand"];

            // Store into variables to keep code smaller
            string operation = Session["operation"].ToString();
            int operand1 = Convert.ToInt32(Session["operand1"].ToString());
            int operand2 = Convert.ToInt32(Session["operand2"].ToString());

            if (operation == "+")
                display.Text = (operand1 + operand2).ToString();
            else if (operation == "-")
                display.Text = (operand1 - operand2).ToString();
            else if (operation == "*")
                display.Text = (operand1 * operand2).ToString();
            else if (operation == "/")
                display.Text = (operand1 / operand2).ToString();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            display.Text = "";
            Session["operation"] = "";
            Session["operand"] = "";
            Session["operand1"] = "";
            Session["operand2"] = "";
        }
    }
}