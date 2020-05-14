using System;

namespace GameStdioManager.Models
{
    [AttributeUsage(AttributeTargets.Enum)]
    public sealed class CustomEnumAttribute : System.Attribute
    {
        public CustomEnumAttribute(int enumInt)
        {
            EnumInt = enumInt;
        }

        public int EnumInt { get; }
    }

    public class SimulatorBase
    {

    }

}