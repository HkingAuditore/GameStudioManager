using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using GameStdioManager.Models.Staff;
using GameStdioManager.Models.Studio;

namespace GameStdioManager.Controllers.Studio
{
    public class StudioSQLController : ControllerBase
    {
        /// <summary>
        ///     从数据库中读取工作室数据并生成对象
        /// </summary>
        /// <param name="staffNumber">工作室编号</param>
        /// <returns></returns>
        public static Models.Studio.Studio ReadStudioInfoSql(string studioNumber)
        {
            Models.Studio.Studio studio = null;

            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                var sqlCommand = new SqlCommand("SELECT * FROM StudioInfo WHERE StudioNumber = @Target", sqlConnection);
                // 构造Parameter对象
                var targetSqlParameter = new SqlParameter("@Target", SqlDbType.VarChar, 255);
                targetSqlParameter.Value = studioNumber;
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();
                    studio = new Models.Studio.Studio(result["StudioNumber"].ToString(),
                                                      result["StudioName"].ToString(),
                                                      int.Parse(result["StudioProperty"].ToString()),
                                                      int.Parse(result["StudioReputation"].ToString())
                                                     );
                }

                result.Close();
            }

            return studio;
        }


        /// <summary>
        /// 向数据库插入工作室数据
        /// </summary>
        /// <param name="studio"></param>
        public static void InsertStudioInfoSql(Models.Studio.Studio studio)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                StringBuilder commandStringBuilderFirstPart = new StringBuilder("INSERT INTO StudioInfo (");
                StringBuilder commandStringBuilderSecondPart = new StringBuilder(") VALUES (");
                var properties = studio.GetType().GetProperties();

                // 抓取属性名称生成SQL语句
                int cur = 1;
                foreach (var property in properties)
                {
                    commandStringBuilderFirstPart.Append(property.Name);
                    if (property.PropertyType.Name == "String")
                    {
                        commandStringBuilderSecondPart.Append(ConvertStringToSql((string)studio.GetPropertyValue(property.Name)));
                    }
                    else
                    {
                        commandStringBuilderSecondPart.Append((int)studio.GetPropertyValue(property.Name));
                    }
                    if (cur++ < properties.Length)
                    {
                        commandStringBuilderFirstPart.Append(", ");
                        commandStringBuilderSecondPart.Append(", ");
                    }
                }

                string command = commandStringBuilderFirstPart.ToString() + commandStringBuilderSecondPart.ToString() +
                                 ")";
                SqlCommand sqlCommand = new SqlCommand(command,sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新数据库的Studio数据
        /// </summary>
        /// <param name="origin">旧实例</param>
        /// <param name="target">新实例</param>
        public static void UpdateStudioInfoSql(Models.Studio.Studio origin, Models.Studio.Studio target)
        {
            // 属性比对，生成的SQL语句只包含要修改的部分
            var properties = origin.GetType().GetProperties();
            var updateList = new List<PropertyInfo>();
            foreach (var property in properties)
                if (!Equals(origin.GetPropertyValue(property.Name), target.GetPropertyValue(property.Name)))
                    updateList.Add(property);

            // 生成SQL语句
            var commandStringBuilder = new StringBuilder("UPDATE StudioInfo SET ");

            var cur = 1;
            foreach (var targetProperty in updateList)
            {
                if (targetProperty.PropertyType.Name == "String")
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                ConvertStringToSql((string)target
                                                                      .GetPropertyValue(targetProperty.Name)));
                else
                    commandStringBuilder.Append(targetProperty.Name + " = " +
                                                (int)target.GetPropertyValue(targetProperty.Name));

                if (cur++ < updateList.Count) commandStringBuilder.Append(", ");
            }

            commandStringBuilder.Append(" WHERE StudioNumber = " + ConvertStringToSql(origin.StudioNumber));

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