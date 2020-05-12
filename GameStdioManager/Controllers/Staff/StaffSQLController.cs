using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GameStdioManager.Models.Staff;


namespace GameStdioManager.Controllers.Staff
{
    public class StaffSQLController : ControllerBase
    {
        public static Models.Staff.Staff ReadStaffInfoSql(string staffNumber)
        {
            Models.Staff.Staff staff = null;
            SqlDataReader result;
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM StaffInfo WHERE StaffNumber = @Target", sqlConnection);
                // 构造Parameter对象
                SqlParameter targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = staffNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    staff = new Models.Staff.Staff(
                    result["StaffNumber"].ToString(),
                    result["StaffName"].ToString(),
                    (Gender)int.Parse(result["StaffGender"].ToString()),
                    int.Parse(result["StaffSalary"].ToString()),
                    (Rank)int.Parse(result["StaffRank"].ToString()),
                    (Occupation)int.Parse(result["StaffOccupation"].ToString()),
                    int.Parse(result["StaffStrength"].ToString()),
                    int.Parse(result["StaffIntelligence"].ToString()),
                    int.Parse(result["StaffLoyalty"].ToString()),
                    int.Parse(result["StaffProperty"].ToString()),
                    (Temperament)int.Parse(result["StaffTemperament"].ToString()));
                }
                result.Close();
            }

            return staff;

        }

    }
}