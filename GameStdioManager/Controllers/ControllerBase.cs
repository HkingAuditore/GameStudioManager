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
    }
}