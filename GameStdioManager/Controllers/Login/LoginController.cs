using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Controllers.Studio;
using GameStdioManager.Models.Game;
using GameStdioManager.Models.Player;
using GameStdioManager.Models.Studio;
using GameStdioManager.Pages;

namespace GameStdioManager.Controllers.Login
{
    public class LoginController : ControllerBase
    {
        public string PlayerNumber;
        private readonly string _password;

        public Models.Player.Player PlayerTarget;
        public List<Models.Staff.Staff> StaffList;
        public bool IsCorrespond;


        public LoginController(string playerNumber,string password)
        {
            PlayerNumber = playerNumber;
            _password = password;
            GetPlayerCorrespond();
        }

        private Models.Player.Player GetPlayerCorrespond()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM PlayerInfo WHERE PlayerNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = PlayerNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    if (result["PlayerPassword"].ToString() == _password)
                    {
                        IsCorrespond = true;
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
                sqlCommand.Parameters.Add(new SqlParameter("@studio", SqlDbType.VarChar, 255));
                sqlCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 255));
                sqlCommand.Parameters.Add(new SqlParameter("@number", SqlDbType.VarChar, 255));

                sqlCommand.Parameters["@studio"].Value = player.PlayerStudio.StudioNumber;
                sqlCommand.Parameters["@password"].Value = password;
                sqlCommand.Parameters["@number"].Value = player.PlayerNumber;


                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}