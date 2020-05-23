using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models.Staff;


namespace GameStdioManager.Views.Game.DevelopedInfo
{
    public partial class Developer : System.Web.UI.UserControl
    {
        public Models.Staff.Staff ThisDeveloper;
        public DevelopedViewLine ParentViewLine;

        protected void Page_Load(object sender, EventArgs e)
        {
            DeveloperName.Text = ThisDeveloper.StaffName;
            DeveloperOccupation.Text = ThisDeveloper.StaffOccupation.ToString();

            DeveloperName.ForeColor = ThisDeveloper.IsWorking ? Color.FromArgb(51, 204, 255) : Color.FromArgb(28, 28, 28);

        }

    }
}