using System;
using System.ComponentModel;

namespace ExtensionsPlus
{
    public static class EnumExtension
    {
        public static T GetAttr<T>(this Enum @enum) where T : Attribute
        {
            var memb = @enum.GetType().GetMember(@enum.ToString());
            var attr = memb[0].GetCustomAttributes(typeof(T), false);
            return (T)attr[0];
        }

        public static string ToDescriptionString(this Enum @enum)
        {
            var attr = @enum.GetAttr<DescriptionAttribute>();
            return (attr == null) ? @enum.ToString() : attr.Description;
        }
    }
}
