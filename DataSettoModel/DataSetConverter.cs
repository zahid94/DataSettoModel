using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataSettoModel
{
    public class DataSetConverter
    {
        public static T ConvertDataSetToClass<T>(DataSet dataSet) where T : new()
        {
            var result = new T();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Assuming that the tables are in the order of the properties in the class
            int tableIndex = 0;

            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var listType = property.PropertyType.GetGenericArguments()[0];

                    if (tableIndex < dataSet.Tables.Count)
                    {
                        var table = dataSet.Tables[tableIndex];
                        var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listType));

                        foreach (DataRow row in table.Rows)
                        {
                            var item = Activator.CreateInstance(listType);
                            foreach (var prop in listType.GetProperties())
                            {
                                if (table.Columns.Contains(prop.Name))
                                {
                                    var value = row[prop.Name];
                                    if (value != DBNull.Value)
                                    {
                                        prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType));
                                    }
                                }
                            }
                            list.Add(item);
                        }

                        property.SetValue(result, list);
                    }

                    tableIndex++;
                }
            }

            return result;
        }
    }
}
