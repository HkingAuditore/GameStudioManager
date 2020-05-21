using System;
using System.Collections.Generic;
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
        }
        
    }
}