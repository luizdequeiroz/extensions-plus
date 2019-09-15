using System;
using System.ComponentModel;
using System.Reflection;

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

        public static T ToEnumIndex<T>(this string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                string[] values = Enum.GetNames(typeof(T));

                for (int i = 0; i < values.Length; i++)
                {
                    FieldInfo oFieldInfo = typeof(T).GetField(values[i]);
                    object[] attributes = oFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attributes.Length > 0)
                        if (((DescriptionAttribute)attributes[0]).Description.ToUpper() == description.ToUpper() || values[i] == description)
                            return (T)Convert.ChangeType(Enum.ToObject(typeof(T), i + 1), typeof(T));
                }

                return (T)Convert.ChangeType(typeof(T).GetField(description).GetValue(typeof(T)), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(Enum.ToObject(typeof(T), 1), typeof(T));
            }
        }
    }
}
