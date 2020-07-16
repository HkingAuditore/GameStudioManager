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

        private static List<Models.Staff.Staff> _studioStaffs = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _studioStaffs = (from staff in PageBase.StaffList
                                 where staff.StaffStudio !=
                                       PageBase.PagePlayer.PlayerStudioNumber
                                 select staff).ToList();
            }
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
            _studioStaffs?.ForEach(staff =>
                                  {
                                      StaffEmployViewLine dl =
                                          (StaffEmployViewLine) LoadControl("StaffEmployViewLine.ascx");
                                      dl.LineStaff = staff;
                                      GamesView.Controls.Add(dl);
                                  });
        }

        protected void B_Salary_OnClick(object sender, ImageClickEventArgs e)
        {
            var tmp = (from staff in _studioStaffs
                       orderby staff.StaffSalary descending 
                       select staff).ToList();
            _studioStaffs = tmp;
            UpdateLines();

        }

        protected void B_HP_OnClick(object sender, ImageClickEventArgs e)
        {
            var tmp = (from staff in _studioStaffs
                             orderby staff.StaffStrength descending
                             select staff).ToList();
            _studioStaffs = tmp;
            UpdateLines();

        }

        protected void B_Intelligence_OnClick(object sender, ImageClickEventArgs e)
        {
            var tmp = (from staff in _studioStaffs
                       orderby staff.StaffIntelligence descending
                       select staff).ToList();
            _studioStaffs = tmp;
            UpdateLines();

        }

        protected void B_Loyalty_OnClick(object sender, ImageClickEventArgs e)
        {
            var tmp = (from staff in _studioStaffs
                       orderby staff.StaffLoyalty descending
                       select staff).ToList();
            _studioStaffs = tmp;
            UpdateLines();

        }
    }
}