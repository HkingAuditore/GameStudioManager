using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models.Staff;

namespace GameStdioManager.Views.Game.Develop
{
    public partial class Developer : System.Web.UI.UserControl
    {
        public Staff ThisDeveloper;
        protected void Page_Load(object sender, EventArgs e)
        {
            DeveloperName.Text = ThisDeveloper.StaffName;
            DeveloperOccupation.Text = ThisDeveloper.StaffOccupation.ToString();
        }
    }
}