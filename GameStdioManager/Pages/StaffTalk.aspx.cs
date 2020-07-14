using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Models.Staff;

namespace GameStdioManager.Pages
{
    public partial class StaffTalk : System.Web.UI.Page
    {
        private static Staff _talkStaff;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ShowStaff();
        }

        protected void D_Staff_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _talkStaff = PageBase.PagePlayer.PlayerStudio.FindStaff(D_Staff.SelectedValue);
            ShowStaff();
        }

        private void ShowStaff()
        {
            if (_talkStaff != null)
            {
                L_StaffName.Text         = _talkStaff.StaffName.ToString();
                L_StaffHP.Text           = "体力值：" + _talkStaff.StaffStrength.ToString();
                L_StaffIntelligence.Text = "智力值：" + _talkStaff.StaffIntelligence.ToString();
                L_StaffTalkLoyalty.Text  = "忠诚度：" + _talkStaff.StaffLoyalty.ToString();
            }
        }
    }
}