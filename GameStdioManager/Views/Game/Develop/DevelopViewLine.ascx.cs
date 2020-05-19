using System;
using System.Configuration;
using System.Data.SqlClient;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Controllers.Staff;

namespace GameStdioManager.Views.Game.Develop
{
    public partial class DevelopViewLine : System.Web.UI.UserControl
    {
        // 这一行要显示的游戏
        public Models.Game.Game LineGame;

        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;


        public DevelopViewLine(Models.Game.Game game)
        {
            LineGame = game;
        }

        public DevelopViewLine()
        {
            LineGame = null;
        }

        private void UpdateView()
        {
            C_GameNumber.Text = LineGame.GameNumber;
            C_GameName.Text = LineGame.GameName;
            C_GameStartDevelopTime.Text = LineGame.GameStartDevelopTime.ToString("yyyy-MM-dd");
            C_GameFinishDevelopTime.Text = LineGame.GameFinishDevelopTime.ToString("yyyy-MM-dd");
            C_GameFun.Text = LineGame.GameFun.ToString();
            C_GameArt.Text = LineGame.GameArt.ToString();
            C_GameMusic.Text = LineGame.GameMusic.ToString();
            ShowDevelopers();
        }

        private void ShowDevelopers()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var sqlCommand = new SqlCommand("SELECT DeveloperStaffNumber From DeveloperRelation WHERE DeveloperGameNumber = '" + LineGame.GameNumber + "'", sqlConnection);
                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                while (result.Read())
                {
                    Developer dv = (Developer)LoadControl("Developer.ascx");
                    dv.ThisDeveloper = StaffSQLController.ReadStaffInfoSql(result["DeveloperStaffNumber"].ToString());
                    C_Developers.Controls.Add(dv);
                }

                result.Close();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}