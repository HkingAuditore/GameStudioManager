using GameStdioManager.Controllers;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Models.Game;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Views.Editors
{
    public partial class GameEditor : CustomUserEditorControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region 交互

        protected void Confirm_OnClick(object sender, EventArgs e)
        {
            ControllerBase.InsertInfoSql(GenerateGameThisPanel());
        }

        protected void ReadFromSQL_OnClick(object sender, EventArgs e)
        {
            ShowGameInfo(GameSQLController.ReadGameInfoSql(GameNumber.Text));
            GameNumber.ReadOnly = true;
        }

        protected void Update_OnClick(object sender, EventArgs e)
        {
            GameSQLController.UpdateGameInfoSql(GameSQLController.ReadGameInfoSql(GameNumber.Text),
                                                GenerateGameThisPanel());
        }

        protected void Reset_OnClick(object sender, EventArgs e)
        {
            ResetGameInfoPanel();
            GameNumber.ReadOnly = false;
        }

        #endregion 交互

        #region 逻辑

        /// <summary>
        ///     获取当前页面抓取的游戏类型
        /// </summary>
        /// <returns></returns>
        private Genres GetGenresThisPanel() => (from Control ct in Genres.Controls
                                                where ct.GetType().ToString()
                                                        .Equals("System.Web.UI.WebControls.CheckBox")
                                                select (CheckBox)ct
                                                into cb
                                                where cb.Checked
                                                select cb)
           .Aggregate<CheckBox, Genres>(0, (current, cb)
                                               => current | (Genres)Enum.Parse(typeof(Genres), cb.ID));

        /// <summary>
        ///     从当前页面输入生成Game实例
        /// </summary>
        /// <returns></returns>
        private Models.Game.Game GenerateGameThisPanel() => new Models.Game.Game(GameNumber.Text,
                                                                                 GameName.Text,
                                                                                 int.Parse(GamePrice.Text),
                                                                                 int.Parse(GameFun.Text),
                                                                                 int.Parse(GameArt.Text),
                                                                                 int.Parse(GameMusic.Text),
                                                                                 int.Parse(GameSales.Text),
                                                                                 GameStudio.Text,
                                                                                 GetGenresThisPanel(),
                                                                                 false
                                                                                );

        /// <summary>
        ///     重置输入框
        /// </summary>
        private void ResetGameInfoPanel()
        {
            (from Control ct in Controls
             where ct.GetType().ToString()
                     .Equals("System.Web.UI.WebControls.TextBox")
             select (TextBox)ct).ForEach(textBox => textBox.Text = "");

            (from Control ct in Genres.Controls
             where ct.GetType().ToString()
                     .Equals("System.Web.UI.WebControls.CheckBox")
             select (CheckBox)ct
             into cb
             where cb.Checked
             select cb).ForEach(checkBox => checkBox.Checked = false);
        }

        /// <summary>
        ///     在当前面板展示Game实例信息
        /// </summary>
        /// <param name="game"></param>
        private void ShowGameInfo(Models.Game.Game game)
        {
            Controls.Cast<Control>()
                    .Where(ct => ct.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
                    .Select(ct => (TextBox)ct)
                    .ForEach(textBox =>
                             {
                                 try
                                 {
                                     textBox.Text = (string)game.GetPropertyValue(textBox.ID);
                                 }
                                 catch
                                 {
                                     textBox.Text = ((int)game.GetPropertyValue(textBox.ID)).ToString();
                                 }
                             });

            Genres.Controls.Cast<Control>()
                  .Where(ct => ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                  .Select(ct => (CheckBox)ct)
                  .ForEach(checkBox => checkBox.Checked =
                                           game.GameGenres.HasFlag((Genres)Enum.Parse(typeof(Genres), checkBox.ID)));
        }

        #endregion 逻辑
    }
}