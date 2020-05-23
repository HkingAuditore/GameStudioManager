using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace GameStdioManager.Models.Player
{
    public class Player : SimulatorBase
    {
        public string PlayerNumber { get; set; }

        public DateTime PlayerStartTime { get; set; }

        public string PlayerStudioNumber { get; set; }

        public Studio.Studio PlayerStudio;

        public DateTime PlayerNowTime { get; set; }

        public Player(Studio.Studio studio) => PlayerStudio = studio;

        /// <summary>
        /// 保存员工上班信息到XML
        /// </summary>
        public void SaveStaffCurWorkDataListXml()
        {
            var xd = new XDocument(new XElement("Staffs"));
            (from staff in this.PlayerStudio.StudioStaffs
             select staff).ForEach(staff => xd.Element("Staffs")?.Add(staff.ConvertStaffCurWorkDataToXElement()));
            Debug.WriteLine(xd);

            // var path = HttpContext.Current.Server.MapPath("~/Data/CheckpointList/checkpoints.xml");
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/" +this.PlayerNumber + "/StaffCurWorkData.xml");
            xd.Save(path);
            if (File.Exists(path)) Debug.WriteLine("Saved!");
            Debug.WriteLine(path);
        }

        /// <summary>
        /// 读取员工上班信息到XML
        /// </summary>
        public void ReadStaffCurWorkDataListXml()
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/" + this.PlayerNumber + "/StaffCurWorkData.xml");
            var xd = XDocument.Load(path);

            foreach (var element in (xd.Element("Staffs")?.Elements("Staff") ??
                                     throw new InvalidOperationException())
               .Select(xe => xe))
            {
                var staff = this.PlayerStudio.FindStaff(element.Attribute("StaffNumber")?.Value);
                staff.StaffCurStrength = int.Parse(element.Element("StaffCurStrength")?.Value ?? throw new InvalidOperationException());
                staff.IsWorking = bool.Parse(element.Attribute("StaffIsWorking")?.Value ?? throw new InvalidOperationException());
            }

        }

    }
}