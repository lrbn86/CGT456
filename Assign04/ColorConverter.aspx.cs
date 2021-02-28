using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign04
{
    public partial class ColorConverter : System.Web.UI.Page
    {
        bool firstValueChanged; // Boolean true/false flag for displaying bitwise

        // This function is called when the page loads for the first time
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page_Load runs each postback (round trip to the server)
            // Make sure that the page is not a postback (i.e. the page has not post back to itself yet / initial page load)
            if (!Page.IsPostBack)
            {
                firstValueChanged = false; // No values have been changed
                //bit1.Enabled = false; // Disable bit1 from being used
                //bit2.Enabled = false; // Disable bit2 from being used
                //bit3.Enabled = false; // Disable bit3 from being used
                //bitwiseResult.Enabled = false; // Disable the textbox from being used
                //bit1.Visible = false; // Don't display bit1
                //bit2.Visible = false; // Don't display bit2
                //bit3.Visible = false; // Don't display bit3
                //bitEqual.Visible = false; // Don't display the equal sign
                //bitwiseResult.Visible = false; // Don't display the textbox
                bitwiseResult.Enabled = false;
                DisplayBitwiseControls(false);
            }
        }

        // This function is connected to each color dropdownlist and will be called if a listitem is selected
        protected void ValueChanged(object sender, EventArgs e)
        {
            // Declare variables for the bits
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;

            string color = ""; // Initially, there is no color defined

            firstValueChanged = true; // Boolean true/false flag used to show bitwise

            DropDownList dl = (DropDownList)sender; // Grab the dropdownlist that called ValueChanged

            // Check which color dropdownlist was changed
            // Get the values from the listitem selected
            // Set the color variable to the appropriate color
            if (dl.ID.Contains("red"))
            {
                num1 = Convert.ToInt32(red1.SelectedValue);
                num2 = Convert.ToInt32(red2.SelectedValue);
                num3 = Convert.ToInt32(red3.SelectedValue);
                num4 = Convert.ToInt32(red4.SelectedValue);
                num5 = Convert.ToInt32(red5.SelectedValue);
                num6 = Convert.ToInt32(red6.SelectedValue);
                num7 = Convert.ToInt32(red7.SelectedValue);
                num8 = Convert.ToInt32(red8.SelectedValue);
                color = "red";
            }
            else if (dl.ID.Contains("blue"))
            {
                num1 = Convert.ToInt32(blue1.SelectedValue);
                num2 = Convert.ToInt32(blue2.SelectedValue);
                num3 = Convert.ToInt32(blue3.SelectedValue);
                num4 = Convert.ToInt32(blue4.SelectedValue);
                num5 = Convert.ToInt32(blue5.SelectedValue);
                num6 = Convert.ToInt32(blue6.SelectedValue);
                num7 = Convert.ToInt32(blue7.SelectedValue);
                num8 = Convert.ToInt32(blue8.SelectedValue);
                color = "blue";
            }
            else if (dl.ID.Contains("green"))
            {
                num1 = Convert.ToInt32(green1.SelectedValue);
                num2 = Convert.ToInt32(green2.SelectedValue);
                num3 = Convert.ToInt32(green3.SelectedValue);
                num4 = Convert.ToInt32(green4.SelectedValue);
                num5 = Convert.ToInt32(green5.SelectedValue);
                num6 = Convert.ToInt32(green6.SelectedValue);
                num7 = Convert.ToInt32(green7.SelectedValue);
                num8 = Convert.ToInt32(green8.SelectedValue);
                color = "green";
            }

            int[] bits = { num1, num2, num3, num4, num5, num6, num7, num8 };

            CalculateDecimalValue(color, bits);
            ChangeBackgroundColor();

            if (firstValueChanged)
            {
                // The first dropdownlist was changed, display the bitwise controls
                DisplayBitwiseControls(true);
            }

            CalculateBitwiseValue(sender, e); // Calculate bitwise value after every change
        } // end ValueChanged

        protected void CalculateBitwiseValue(object sender, EventArgs e)
        {
            // Only Calculate the bitwise value if the user has chosen the operands and an operator
            if (!bit1.SelectedValue.Equals("--") && !bit2.SelectedValue.Equals("--") && !bit3.SelectedValue.Equals("--"))
            {
                int num1 = 0;
                int num2 = 0;
                int result = 0;

                if (bit1.SelectedValue.Equals("R"))
                    num1 = Convert.ToInt32(rDecText.Text);
                if (bit1.SelectedValue.Equals("B"))
                    num1 = Convert.ToInt32(bDecText.Text);
                if (bit1.SelectedValue.Equals("G"))
                    num1 = Convert.ToInt32(gDecText.Text);

                if (bit3.SelectedValue.Equals("R"))
                    num2 = Convert.ToInt32(rDecText.Text);
                if (bit3.SelectedValue.Equals("B"))
                    num2 = Convert.ToInt32(bDecText.Text);
                if (bit3.SelectedValue.Equals("G"))
                    num2 = Convert.ToInt32(gDecText.Text);

                if (bit2.SelectedValue.Equals("&"))
                    result = num1 & num2;
                if (bit2.SelectedValue.Equals("|"))
                    result = num1 | num2;
                if (bit2.SelectedValue.Equals("^"))
                    result = num1 ^ num2;

                string inBinary = "";
                int binNum = result;

                if (binNum >= 128)
                {
                    inBinary = "1";
                    binNum -= 128;
                }
                else
                {
                    inBinary = "0";
                }

                if (binNum >= 64)
                {
                    inBinary += "1";
                    binNum -= 64;
                }
                else
                {
                    inBinary += "0";
                }

                if (binNum >= 32)
                {
                    inBinary += "1";
                    binNum -= 32;
                }
                else
                {
                    inBinary += "0";
                }

                if (binNum >= 16)
                {
                    inBinary += "1";
                    binNum -= 16;
                }
                else
                {
                    inBinary += "0";
                }

                if (binNum >= 8)
                {
                    inBinary += "1";
                    binNum -= 8;
                }
                else
                {
                    inBinary += "0";
                }

                if (binNum >= 4)
                {
                    inBinary += "1";
                    binNum -= 4;
                }
                else
                {
                    inBinary += "0";
                }

                if (binNum >= 2)
                {
                    inBinary += "1";
                    binNum -= 2;
                }
                else
                {
                    inBinary += "0";
                }

                if (binNum >= 1)
                {
                    inBinary += "1";
                    binNum -= 1;
                }
                else
                {
                    inBinary += "0";
                }

                bitwiseResult.Text = inBinary.ToString();

            }
        } // end CalculateBitwiseValue

        private void DisplayBitwiseControls(Boolean flag)
        {
            bit1.Enabled = flag;
            bit2.Enabled = flag;
            bit3.Enabled = flag;
            bit1.Visible = flag;
            bit2.Visible = flag;
            bit3.Visible = flag;
            bitEqual.Visible = flag;
            bitwiseResult.Visible = flag;
        } // end DisplayBitwiseControls

        private void CalculateDecimalValue(string color, int[] bits)
        {
            int total = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                total += bits[i] * (int)Math.Pow(2, i);
            }

            if (color == "red")
            {
                rHexText.Text = CalculateHexValue(total);
                rDecText.Text = total.ToString();
            }
            else if (color == "blue")
            {
                bHexText.Text = CalculateHexValue(total);
                bDecText.Text = total.ToString();
            }
            else if (color == "green")
            {
                gHexText.Text = CalculateHexValue(total);
                gDecText.Text = total.ToString();
            }
        } // end CalculateDecimalValue

        private string GetHexFromNum(int num)
        {
            if (num <= 9)
                return num.ToString();

            string hexNum = "";

            if (num > 9)
            {
                if (num == 10)
                    hexNum = "A";
                else if (num == 11)
                    hexNum = "B";
                else if (num == 12)
                    hexNum = "C";
                else if (num == 13)
                    hexNum = "D";
                else if (num == 14)
                    hexNum = "E";
                else if (num == 15)
                    hexNum = "F";
            }
            return hexNum;
        } // end GetHexFromNum

        private string CalculateHexValue(int num)
        {
            int num1 = 0;
            int num2 = 0;
            string firstNum = "";
            string secondNum = "";

            // Calculate the hex number (1-16)
            num1 = (num / 16) % 16;
            num2 = num % 16;

            firstNum = GetHexFromNum(num1);
            secondNum = GetHexFromNum(num2);

            return firstNum + secondNum;
        } // end CalculateHexValue

        private void ChangeBackgroundColor()
        {
            string rColor = "";
            string bColor = "";
            string gColor = "";

            if (rHexText.Text.Equals(""))
                rColor = "00";
            else
                rColor = rHexText.Text.ToString();

            if (bHexText.Text.Equals(""))
                bColor = "00";
            else
                bColor = bHexText.Text.ToString();

            if (gHexText.Text.Equals(""))
                gColor = "00";
            else
                gColor = gHexText.Text.ToString();

            bgColor.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + rColor + gColor + bColor);
        } // end ChangeBackgroundColor

    }
}