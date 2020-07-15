using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models;
using GameStdioManager.Pages;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Staff
{
    public partial class StaffEmployView : System.Web.UI.UserControl
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        private static List<Models.Staff.Staff> _studioStaffs = PageBase.StaffList;



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!SimulatorTimer.IsTicking())
            {
                UP_UpdatePanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
            }
            else
            {
                UP_UpdatePanel.UpdateMode = UpdatePanelUpdateMode.Always;
            }
            UpdateLines();
        }


        private void UpdateLines()
        {
            (from staff in PageBase.StaffList
             where staff.StaffStudio !=
                   PageBase.PagePlayer.PlayerStudioNumber
             select staff).ForEach(staff =>
                                   {
                                       StaffEmployViewLine dl = (StaffEmployViewLine)LoadControl("StaffEmployViewLine.ascx");
                                       dl.LineStaff = staff;
                                       GamesView.Controls.Add(dl);
                                   });
        }
    }
}