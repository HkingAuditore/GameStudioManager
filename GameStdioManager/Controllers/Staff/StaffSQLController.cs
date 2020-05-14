using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using GameStdioManager.Models.Staff;

namespace GameStdioManager.Controllers.Staff
{
    public class StaffSQLController : ControllerBase
    {
        /// <summary>
        ///     从数据库中读取员工数据并生成对象
        /// </summary>
        /// <param name="staffNumber">员工编号</param>
        /// <returns></returns>
        public static Models.Staff.Staff ReadStaffInfoSql(string staffNumber)
        {
            Models.Staff.Staff staff = null;
            SqlDataReader      result;

            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM StaffInfo WHERE StaffNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
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
                                                   (Gender) int.Parse(result["StaffGender"].ToString()),
                                                   int.Parse(result["StaffSalary"].ToString()),
                                                   (Rank) int.Parse(result["StaffRank"].ToString()),
                                                   (Occupation) int.Parse(result["StaffOccupation"].ToString()),
                                                   int.Parse(result["StaffStrength"].ToString()),
                                                   int.Parse(result["StaffIntelligence"].ToString()),
                                                   int.Parse(result["StaffLoyalty"].ToString()),
                                                   int.Parse(result["StaffProperty"].ToString()),
                                                   (Temperament) int.Parse(result["StaffTemperament"].ToString()),
                                                   int.Parse(result["TimeToWork"].ToString()),
                                                   int.Parse(result["TimeToQuit"].ToString()),
                                                   int.Parse(result["WeekdaysLength"].ToString()),
                                                   result["StaffStudio"].ToString()
                                                  );
                }

                result.Close();
            }

            return staff;
        }

        /// <summary>
        ///     向数据库中写入员工信息
        /// </summary>
        /// <param name="staff">员工实例</param>
        public static void InsertStaffInfoSql(Models.Staff.Staff staff)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("INSERT INTO StaffInfo VALUES ("
                                              + ConvertStringToSql(staff.StaffNumber) + ","
                                              + ConvertStringToSql(staff.StaffName)   + ","
                                              + (int) staff.StaffGender               + ","
                                              + staff.StaffSalary                     + ","
                                              + (int) staff.StaffRank                 + ","
                                              + (int) staff.StaffOccupation           + ","
                                              + staff.StaffStrength                   + ","
                                              + staff.StaffIntelligence               + ","
                                              + staff.StaffLoyalty                    + ","
                                              + staff.StaffProperty                   + ","
                                              + staff.TimeToWork                      + ","
                                              + staff.TimeToQuit                      + ","
                                              + staff.WeekdaysLength                  + ","
                                              + (int) staff.StaffTemperament          + ","
                                              + ConvertStringToSql(staff.StaffStudio)
                                              + ")", sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     比对两个Staff实例，将更新的部分提交SQL数据库进行更新
        /// </summary>
        /// <param name="origin">旧Staff实例</param>
        /// <param name="target">新Staff实例</param>
        public static void UpdateStaffInfoSql(Models.Staff.Staff origin, Models.Staff.Staff target)
        {
            // 属性比对，生成的SQL语句只包含要修改的部分
            var properties = origin.GetType().GetProperties();
            var updateList = new List<PropertyInfo>();
            foreach (var property in properties)
                if (!Equals(origin.GetPropertyValue(property.Name), target.GetPropertyValue(property.Name)))
                    updateList.Add(property);

            // 生成SQL语句
            var commandStringBuilder = new StringBuilder("UPDATE StaffInfo SET ");

            var cur = 1;
            foreach (var targetProperty in updateList)
            {
                if (targetProperty.PropertyType.Name == "String")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                ConvertStringToSql((string) target
                                                                      .GetPropertyValue(targetProperty.Name)));
                // 用了Flags特性的枚举不能直接转int，不知道为什么
                else if (targetProperty.PropertyType.Name == "Temperament")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                (int) (Temperament) target.GetPropertyValue(targetProperty.Name));
                else
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                (int) target.GetPropertyValue(targetProperty.Name));

                if (cur++ < updateList.Count) commandStringBuilder.Append(", ");
            }

            commandStringBuilder.Append(" WHERE StaffNumber = " + ConvertStringToSql(origin.StaffNumber));

            // 执行
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var sqlCommand = new SqlCommand(commandStringBuilder.ToString(), sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}