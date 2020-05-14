using System;
using System.Web.UI;
using GameStdioManager.Controllers.Studio;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Views
{
    public partial class StudioEditor : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region 交互

        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            StudioSQLController.InsertStudioInfoSql(GenerateStudioThisPanel());
        }

        protected void ReadFromSQL_OnClick(object sender, EventArgs e)
        {
            ShowStudioInfo(StudioSQLController.ReadStudioInfoSql(StudioNumber.Text.Trim()));
            StudioNumber.ReadOnly = true;
        }

        protected void Update_OnClick(object sender, EventArgs e)
        {
            StudioSQLController.UpdateStudioInfoSql(StudioSQLController.ReadStudioInfoSql(StudioNumber.Text.Trim()),GenerateStudioThisPanel());
        }

        protected void Reset_OnClick(object sender, EventArgs e)
        {
            ResetStudioInfoPanel();
            StudioNumber.ReadOnly = false;
        }

        #endregion

        #region 逻辑

        /// <summary>
        ///     根据当前页面信息生成Studio对象
        /// </summary>
        /// <returns></returns>
        private Studio GenerateStudioThisPanel()
        {
            return new Studio(StudioNumber.Text,
                              StudioName.Text,
                              int.Parse(StudioProperty.Text),
                              int.Parse(StudioReputation.Text));
        }

        /// <summary>
        ///     重置界面
        /// </summary>
        private void ResetStudioInfoPanel()
        {
            StudioName.Text       = "";
            StudioProperty.Text   = "";
            StudioReputation.Text = "";
            StudioNumber.Text     = "";
        }

        /// <summary>
        ///     在面板上显示工作室信息
        /// </summary>
        /// <param name="studio"></param>
        private void ShowStudioInfo(Studio studio)
        {
            StudioNumber.Text     = studio.StudioNumber;
            StudioName.Text       = studio.StudioName;
            StudioProperty.Text   = studio.StudioProperty.ToString();
            StudioReputation.Text = studio.StudioReputation.ToString();
        }

        #endregion
    }
}