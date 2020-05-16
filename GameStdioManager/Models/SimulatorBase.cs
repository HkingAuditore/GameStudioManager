using System;
using System.Text;

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

    public interface IPropertyGetter
    {
        object GetPropertyValue(string propertyName);
        string GetTypeName();
    }

    public class SimulatorBase : IPropertyGetter
    {
        public object GetPropertyValue(string propertyName) => GetType().GetProperty(propertyName)?.GetValue(this, null);

        public string GetTypeName() => GetType().Name;

    }

}