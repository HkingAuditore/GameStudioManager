using System;
using System.Data;
using System.Data.SqlClient;
using GameStdioManager.Controllers.Studio;
using GameStdioManager.Models.Game;
using GameStdioManager.Models.Player;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Controllers.Login
{
    public class LoginController : ControllerBase
    {
        private string _playerNumber;
        private string _password;

        public Player PlayerStudio;
        public bool IsCorrespond;
        public LoginController(string playerNumber,string password)
        {
            _playerNumber = playerNumber;
            _password = password;
            GetPlayer();
        }

        private Player GetPlayer()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM PlayerInfo WHERE PlayerNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = _playerNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    if (result["PlayerPassword"].ToString() == _password)
                    {
                        IsCorrespond = true;
                        PlayerStudio = new Player(StudioSQLController.ReadStudioInfoSql(result["PlayerStudioNumber"].ToString()));
                        PlayerStudio.PlayerStartTime = DateTime.Parse(result["PlayerStartTime"].ToString());
                        PlayerStudio.PlayerNowTime = DateTime.Parse(result["PlayerNowTime"].ToString());
                    }
                }

                result.Close();
            }

            return PlayerStudio;

        }
    }
}