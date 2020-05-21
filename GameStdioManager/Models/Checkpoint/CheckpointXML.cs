using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Controllers.Studio;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Models.Checkpoint
{
    public partial class Checkpoint : SimulatorBase
    {
        /// <summary>
        ///     将Checkpoint转换为XElement
        /// </summary>
        /// <returns></returns>
        public XElement ConvertCheckpointToXElement()
        {
            var objectNumber = "";
            switch (CheckpointTypeIndicator)
            {
                case "Game":
                    objectNumber = ((Game.Game) CheckpointTransferObject).GetObjectNumber();
                    break;

                case "Staff":
                    objectNumber = ((Staff.Staff) CheckpointTransferObject).GetObjectNumber();
                    break;

                case "Studio":
                    objectNumber = ((Studio.Studio) CheckpointTransferObject).GetObjectNumber();
                    break;
            }

            var root = new XElement("Checkpoint",
                                    new XAttribute("CheckpointNumber",               CheckpointNumber),
                                    new XAttribute("CheckpointTime",                 CheckpointTime),
                                    new XAttribute("CheckpointCheckMethodIndicator", CheckpointCheckMethodIndicator),
                                    new XAttribute("CheckpointTypeIndicator",        CheckpointTypeIndicator),
                                    new XAttribute("CheckpointTransferObject",       objectNumber),
                                    new XElement("CheckpointProcessIndicators"),
                                    new XElement("CheckpointUpdateIndicators"),
                                    new XElement("CheckpointTransferArgs")
                                   );

            // 将Process中的各个字符串输入XML文档
            (from str in CheckpointProcessIndicators
             select str).ForEach(str => root.Element("CheckpointProcessIndicators")
                                       ?.Add(new XElement("CheckpointProcessIndicator",
                                                          new XAttribute("target", str))));
            // 将Update中的各个字符串输入XML文档
            (from str in CheckpointUpdateIndicators
             select str).ForEach(str => root.Element("CheckpointUpdateIndicators")
                                       ?.Add(new XElement("CheckpointUpdateIndicator",
                                                          new XAttribute("target", str))));

            // root.Element("CheckpointTransferArgs")?.Add(new XElement("CheckParm",
            //                                                          new XAttribute("Parm",
            //                                                                         CheckpointTransferArgs.CheckParm)),
            //                                             new XElement("UpdateParm",
            //                                                          new XAttribute("Parm",
            //                                                                         CheckpointTransferArgs.UpdateParm)),
            //                                             new XElement("UpdateSpeed",
            //                                                          new XAttribute("Parm",
            //                                                                         CheckpointTransferArgs.UpdateSpeed))
            //                                            );

            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(this.CheckpointTransferArgs.GetType());
                serializer.Serialize(sw, this.CheckpointTransferArgs);

                // (from e in XDocument.Load((TextReader)new StringReader(sw.ToString())).Element("CheckpointArgs")?.Elements()
                //  select e).ForEach(e => root.Element("CheckpointTransferArgs")?.Add(e));

                root.Element("CheckpointTransferArgs")
                   ?.Add(XDocument.Load((TextReader) new StringReader(sw.ToString())).Element("CheckpointArgs"));
            }



            return root;
        }

        /// <summary>
        /// 从XElement中读取Checkpoint
        /// </summary>
        /// <param name="xe"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Checkpoint ReadCheckpointXml(XElement xe,Player.Player player)
        {
            var checkpointProcessIndicators =
                (from element in xe.Element("CheckpointProcessIndicators")
                                  ?.Elements("CheckpointProcessIndicator")
                 select element.Attribute("target")?.Value).ToArray();

            var checkpointUpdateIndicators =
                (from element in xe.Element("CheckpointUpdateIndicators")
                                  ?.Elements("CheckpointUpdateIndicator")
                 select element.Attribute("target")?.Value).ToArray();

            // var args =
            //     new
            //         CheckpointArgs(int.Parse(xe.Element("CheckpointTransferArgs")?.Element("CheckParm")?.FirstAttribute.Value 
            //                               ?? throw new InvalidOperationException()),
            //                        int.Parse(xe.Element("CheckpointTransferArgs")?.Element("CheckParm")?.FirstAttribute.Value 
            //                               ?? throw new InvalidOperationException()),
            //                        int.Parse(xe.Element("CheckpointTransferArgs")?.Element("UpdateSpeed")?.FirstAttribute.Value
            //                               ?? throw new InvalidOperationException())
            //                       );

            CheckpointArgs args = null;
            using (StringReader sr = new StringReader(xe.Element("CheckpointTransferArgs")?.Element("CheckpointArgs")?.ToString() ?? throw new InvalidOperationException()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CheckpointArgs));
                args = serializer.Deserialize(sr) as CheckpointArgs;
            }


            SimulatorBase obj = null;
            switch (xe.Attribute("CheckpointTypeIndicator")?.Value)
            {
                case "Game":
                    obj =
                        player.PlayerStudio.FindGame(xe.Attribute("CheckpointTransferObject")?.Value);
                    break;

                case "Staff":
                    obj =
                        player.PlayerStudio.FindStaff(xe.Attribute("CheckpointTransferObject")?.Value);
                    break;

                case "Studio":
                    // TODO 这里的Studio读取方式不行，要优化
                    obj =
                        StudioSQLController
                           .ReadStudioInfoSql(xe.Attribute("CheckpointTransferObject")?.Value);
                    break;
            }

            return new
                Checkpoint(int.Parse(xe.Attribute("CheckpointNumber")?.Value ?? throw new InvalidOperationException()),
                           DateTime.Parse(xe.Attribute("CheckpointTime")?.Value),
                           checkpointProcessIndicators,
                           checkpointUpdateIndicators,
                           xe.Attribute("CheckpointCheckMethodIndicator")?.Value,
                           obj,
                           args,
                           xe.Attribute("CheckpointTypeIndicator")?.Value
                          );
        }

        #region 字符串存储

        /// <summary>
        ///     将存储的字符串数组用逗号组合起来
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string MergeStringArray(string[] source) => source.Select(s => s).Aggregate("", (current, s)
                                                                                                           => current +
                                                                                                              s)
                                                                         .TrimEnd('.');

        /// <summary>
        ///     将组合字符串拆开
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string[] ParseStringToArray(string source) => source.Split(',');

        #endregion 字符串存储
    }
}