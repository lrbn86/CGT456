using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign02
{
    public partial class table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Create table web control
            System.Web.UI.WebControls.Table table = new Table();

            // Create a table cell web control
            System.Web.UI.WebControls.TableCell tc = new TableCell();

            // Create a table row web control
            System.Web.UI.WebControls.TableRow tr = new TableRow();

            // The table has a width of 360 units
            table.Width = 360;

            // Each table cell has padding of 0 units
            table.CellPadding = 0;

            // There is a spacing of 1 unit between each table cell
            table.CellSpacing = 1;

            /* Create Top Banner */
            tc.ColumnSpan = 3;
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = "topBanner.jpg"; //**** THIS MAY BE DIFFERENT ****//
            img.Visible = true; // The image will be visible
            img.Width = 360; // Set the width of the image
            tc.Controls.Add(img);
            tc.HorizontalAlign = HorizontalAlign.Center;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Scoreboard */
            tr = new TableRow(); // Create a new table row
            tc = new TableCell(); // Create a new table cell

            tc.ColumnSpan = 3; // This table cell has a column span of 3 units
            tc.Text = "PUR &nbsp; &nbsp; 0 &nbsp; &nbsp; | &nbsp; &nbsp; OSU &nbsp; &nbsp; 0"; // Set the content of this table cell
            tc.BackColor = System.Drawing.Color.LightGray; // This table cell has a background color of light gray
            tc.HorizontalAlign = HorizontalAlign.Center; // The table cell's content is horizontally centered
            tc.Font.Size = 16; // The table cell's content has a font size of 16 units
            tr.Controls.Add(tc); // Add the table cell into the table row

            table.Controls.Add(tr); // Add the created table row into the table

            /** 
             The following/below code will follow a similar pattern as above.
             Comments will be made for new code statements.
            **/

            /* Next Row - Team Comparison */
            tr = new TableRow();
            tc = new TableCell();

            tc.ColumnSpan = 3;
            tc.Text = "Team Comparison";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 14;
            tc.Font.Underline = true; // This table cell's content will be underlined
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row */
            tr = new TableRow();
            tc = new TableCell();

            tc.ColumnSpan = 3;
            tc.Text = "Page reloads every 30 seconds";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row */
            tr = new TableRow();
            tc = new TableCell();

            img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = "purdue.jpg"; //**** THIS MAY BE DIFFERENT ****//
            img.Visible = true;
            tc.Controls.Add(img);
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Width = 100;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "VS";
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 14;
            tc.Font.Bold = true;
            tc.Width = 160;
            tr.Controls.Add(tc);

            tc = new TableCell();
            img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = "osu.jpg"; //**** THIS MAY BE DIFFERENT ****//
            img.Visible = true;
            tc.Controls.Add(img);
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Width = 100;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Start of what repeats */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "First Downs";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);
            /* End of what repeats */

            /* Next Row - 3rd down efficiency */
            tr = new TableRow();
            tc = new TableCell();
            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "3rd down efficiency";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - 4th down efficiency */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "4th down efficiency";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Total Yards */
            tr = new TableRow();
            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Total Yards";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Passing Yards */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Passing Yards";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Comp-Att */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Comp-Att";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Yards per Pass */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Yards per Pass";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Rushing Yards */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Rushing Yards";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* New Row - Rushing Attempts */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Rushing Attempts";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Yards per Rush */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Yards per Rush";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Penalty Yards */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Penalty Yards";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0-0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Turnovers */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Turnovers";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Fumbles Lost */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Fumbles Lost";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Interceptions */
            tr = new TableRow();
            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Interceptions";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "0";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Time of Possession */
            tr = new TableRow();
            tc = new TableCell();

            tc.Text = "";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "Time of Possession";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            tc = new TableCell();
            tc.Text = "";
            tc.BackColor = System.Drawing.Color.LightGray;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Links */
            tr = new TableRow();
            tc = new TableCell();

            tc.ColumnSpan = 3;
            tc.Text = "<a href='refresh.aspx'>Refresh</a> &nbsp; &nbsp; | &nbsp; &nbsp; <a href='playbyplay.aspx'>Play by Play</a> &nbsp; &nbsp; | &nbsp; &nbsp; <a href='morestats.aspx'>More Stats</a>";
            tc.BackColor = System.Drawing.Color.White;
            tc.HorizontalAlign = HorizontalAlign.Center;
            tc.Font.Size = 10;
            tc.Font.Bold = true;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            /* Next Row - Bottom Banner */
            tr = new TableRow();
            tc = new TableCell();

            tc.ColumnSpan = 3;
            img = new System.Web.UI.WebControls.Image();
            img.ImageUrl = "bottomBanner.jpg"; //**** THIS MAY BE DIFFERENT ****//
            img.Visible = true;
            img.Width = 360;
            tc.Controls.Add(img);
            tc.HorizontalAlign = HorizontalAlign.Center;
            tr.Controls.Add(tc);

            table.Controls.Add(tr);

            //**** Add the table to the Panel(myTable) on the aspx ****//

            myTable.Controls.Add(table);
        }
    }
}