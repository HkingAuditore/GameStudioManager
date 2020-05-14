using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GameStdioManager.Controllers
{
    public class ControllerBase
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        #region SQL语句转换

        /// <summary>
        /// 将string类型转换为SQL语句使用的格式
        /// </summary>
        /// <param name="target">目标字符串</param>
        /// <returns></returns>
        protected static string ConvertStringToSql(string target) => " '" + target + "' ";

        #endregion
    }
}