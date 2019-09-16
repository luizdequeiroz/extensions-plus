using System.Linq;

namespace ExtensionsPlus
{
    public static class ObjectsExtension
    {
        public static void SetProperties<T, F>(this T to, F from, params string[] exception)
        {
            foreach (var propTo in to.GetType().GetProperties())
            {
                foreach (var propFrom in from.GetType().GetProperties())
                {
                    if (propFrom.Name == propTo.Name)
                    {
                        if (propTo.CustomAttributes.Where(ca => ca.AttributeType.Name == "KeyAttribute" || ca.AttributeType.Name == "DatabaseGeneratedAttribute").Count() == 0)
                        {
                            if (!exception.Contains(propFrom.Name))
                            {
                                propTo.SetValue(to, propFrom.GetValue(from));
                            }
                        }
                    }
                }
            }
        }
    }
}
