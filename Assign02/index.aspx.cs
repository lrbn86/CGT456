using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign02
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the element's content with the id="myName" to my name
            myName.Text = "Brandon Nguyen";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // When the submit button is clicked, store values obtained from the form inputs into variables
            string strFirstName = fName.Text.ToString();
            string strLastName = lName.Text.ToString();
            string strCity = city.Text.ToString();
            string strZip = zip.Text.ToString();
            string strState = state.SelectedValue.ToString();

            // Concatenate the variables's values into the results element
            results.Text = "First Name: " + strFirstName + "<br/>";
            results.Text += "Last Name: " + strLastName + "<br/>";
            results.Text += "City: " + strCity + "<br/>";
            results.Text += "State: " + strState + "<br/>";
            results.Text += "Zip: " + strZip + "<br/>";

            // Initially, the display of results element is set to none, which means it is not visible on the page
            // So when the submit button is clicked, we will display the concatenated result by setting display to block
            results.Style.Add("display", "block");
        }
    }
}