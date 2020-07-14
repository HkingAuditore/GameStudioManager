using System;
using System.Data;
using System.Data.SqlClient;
using GameStdioManager.Controllers.Player;
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

        public Models.Player.Player PlayerTarget;
        public bool IsCorrespond;
        public LoginController(string playerNumber,string password)
        {
            _playerNumber = playerNumber;
            _password = password;
            GetPlayer();
        }

        private Models.Player.Player GetPlayer()
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

                        PlayerTarget = PlayerSqlController.ReadPlayerInfoSql(_playerNumber,true);
                    }
                }

                result.Close();
            }

            return PlayerTarget;

        }

        public static void RegisterPlayer(Models.Player.Player player,string password)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("insert_player", sqlConnection)
                                 {
                                     CommandType = CommandType.StoredProcedure
                                 };
                sqlCommand.Parameters.Add(new SqlParameter("@studio", SqlDbType.NVarChar, 256));
                sqlCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 256));
                sqlCommand.Parameters.Add(new SqlParameter("@number", SqlDbType.NVarChar, 256));

                sqlCommand.Parameters["@studio"].Value = player.PlayerStudio.StudioNumber;
                sqlCommand.Parameters["@password"].Value = password;
                sqlCommand.Parameters["@number"].Value = player.PlayerNumber;


                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}