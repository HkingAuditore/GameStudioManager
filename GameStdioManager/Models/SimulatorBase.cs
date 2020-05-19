using System;

namespace GameStdioManager.Models
{
    [AttributeUsage(AttributeTargets.Enum)]
    public sealed class CustomEnumAttribute : Attribute
    {
        public CustomEnumAttribute(int enumInt) => EnumInt = enumInt;

        public int EnumInt { get; }
    }

    public interface IPropertyGetter
    {
        object GetPropertyValue(string propertyName);

        string GetTypeName();

        string GetObjectNumber();
    }

    public class SimulatorBase : IPropertyGetter
    {
        public object GetPropertyValue(string propertyName) =>
            GetType().GetProperty(propertyName)?.GetValue(this, null);

        public string GetTypeName() => GetType().Name;

        public virtual string GetObjectNumber() => throw new NotImplementedException();
    }
}