using System;
using System.Collections.Generic;
using System.Data;

namespace ExtensionsPlus
{
    public static class ConvertersExtension
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> enumerable) where T : class
        {
            Type type = typeof(T);
            if (type.Name == "Object")
            {
                throw new NotImplementedException("Implementation not exists for ToDataTable from IEnumerable of dynamic");
            }
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (var info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in enumerable)
            {
                object[] values = new object[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
