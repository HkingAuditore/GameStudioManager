using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models.Staff;

namespace GameStdioManager.Pages
{
    public partial class StaffTalk : System.Web.UI.Page
    {
        private static Staff _talkStaff;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                B_Demote.Enabled = false;
                B_Fire.Enabled = false;
                B_Penalize.Enabled = false;
                B_Promote.Enabled = false;
                B_Reward.Enabled = false;
            }
            // ScriptManager.RegisterStartupScript(Page, typeof(string), "GetCheckTime", "GetCheckTime(1,true);", true);
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
                L_StaffTalkContent.Text = _talkStaff.Greet();
                Refresh();
            }
        }

        private void Refresh()
        {
            L_StaffName.Text         = _talkStaff.StaffName.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(string), "Draw", "Draw();", true);


            if (_talkStaff.StaffStudio != PageBase.PagePlayer.PlayerStudioNumber)
            {
                B_Demote.Enabled   = false;
                B_Fire.Enabled     = false;
                B_Penalize.Enabled = false;
                B_Promote.Enabled  = false;
                B_Reward.Enabled   = false;
            }
            else
            {
                B_Demote.Enabled   = true;
                B_Fire.Enabled     = true;
                B_Penalize.Enabled = true;
                B_Promote.Enabled  = true;
                B_Reward.Enabled   = true;
            }
        }

        protected void B_Reward_OnClick(object sender, EventArgs e)
        {
            L_StaffTalkContent.Text = _talkStaff.Talk(TalkChoice.Reward);
            Refresh();
        }

        protected void B_Penalize_OnClick(object sender, EventArgs e)
        {
            L_StaffTalkContent.Text = _talkStaff.Talk(TalkChoice.Penalize);
            Refresh();
        }

        protected void B_Promote_OnClick(object sender, EventArgs e)
        {
            L_StaffTalkContent.Text = _talkStaff.Talk(TalkChoice.Promote);
            Refresh();
        }

        protected void B_Demote_OnClick(object sender, EventArgs e)
        {
            L_StaffTalkContent.Text = _talkStaff.Talk(TalkChoice.Demote);
            Refresh();
        }

        protected void B_Fire_OnClick(object sender, EventArgs e)
        {
            L_StaffTalkContent.Text = _talkStaff.Talk(TalkChoice.Fire);
            Refresh();
        }

        protected int GetStaffHP() => _talkStaff?.StaffStrength ?? 0;
        protected int GetStaffIntelligence() => _talkStaff?.StaffIntelligence ?? 0;
        protected int GetStaffLoyalty() => _talkStaff?.StaffLoyalty ?? 0;
        protected string GetStaffName() => _talkStaff?.StaffName ?? "";


        [WebMethod]
        public static int GetStaffCheck(int hour, bool isWork) => _talkStaff == null ? 0 : StaffSQLController.GetStaffCheckTimes(_talkStaff, hour, isWork);
    }
}