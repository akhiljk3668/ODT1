using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ODT.Utitlity
{
    public static class DataTableExtention
    {
        public static List<T> ConvertDataTable<T>(this DataTable dt)
        {
            List<T> data = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);

            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        var dbValue = dr[column.ColumnName];
                        if (dbValue != DBNull.Value)
                            pro.SetValue(obj, Convert.ChangeType(dbValue, pro.PropertyType), null);

                    }
                    else
                        continue;
                }
            }

            return obj;
        }

    }
}
