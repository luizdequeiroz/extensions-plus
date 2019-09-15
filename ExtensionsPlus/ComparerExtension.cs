using System.Collections.Generic;
using System.Linq;

namespace ExtensionsPlus
{
    public static class ComparerExtension
    {
        public static bool Equals<E>(this E x, E y)
        {
            var genericComparer = new GenericComparer<E>();
            return genericComparer.Equals(x, y);
        }

        public class GenericComparer<E> : IEqualityComparer<E>
        {
            public bool Equals(E x, E y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    return false;

                var propertiesCount = x.GetType().GetProperties().Count();
                var equalsCount = 0;

                foreach (var propertyX in x.GetType().GetProperties())
                    foreach (var propertyY in y.GetType().GetProperties())
                        if (propertyX.Name == propertyY.Name)
                            if (propertyX.GetValue(x)?.ToString() == propertyY.GetValue(y)?.ToString())
                                equalsCount++;

                return propertiesCount == equalsCount;
            }

            public int GetHashCode(E e)
            {
                if (ReferenceEquals(e, null)) return 0;

                int hashCodeObject = 0;

                foreach (var property in e.GetType().GetProperties())
                {
                    var value = property.GetValue(e);
                    var hashCode = (value != null ? property.GetValue(e).GetHashCode() : 0);
                    if (hashCodeObject == 0) hashCodeObject = hashCode;
                    else hashCodeObject ^= hashCode;
                }

                return hashCodeObject;
            }
        }
    }    
}
