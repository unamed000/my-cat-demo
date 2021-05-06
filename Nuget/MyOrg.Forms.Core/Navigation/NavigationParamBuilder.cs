using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyOrg.Forms.Core.Navigation
{
    public class NavigationParamBuilder
    {
        public static string ConvertObjectToQueryUrl(object instance)
        {
            StringBuilder urlBuilder = new StringBuilder();
            List<PropertyInfo> properties = instance.GetType().GetRuntimeProperties().ToList();

            for (int i = 0; i < properties.Count; i++)
            {
                object value = properties[i].GetValue(instance, null);
                string nameStr = properties[i].Name;
                if (char.IsUpper(nameStr[0]))
                {
                    nameStr = char.ToLowerInvariant(nameStr[0]) + nameStr.Substring(1);
                }
                else
                {
                    if (value == null)
                    {
                        continue;
                    }
                    string valueStr;
                    if (value is DateTime dateTime)
                    {
                        DateTime localDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                            dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, DateTimeKind.Local);

                        valueStr = localDateTime.ToString("o");
                    }
                    else if (value is bool)
                    {
                        valueStr = value.ToString().ToLower();
                    }
                    else
                    {
                        valueStr = value?.ToString() ?? string.Empty;
                    }

                    urlBuilder.AppendFormat("{0}={1}&", nameStr, valueStr);
                }
            }
            if (urlBuilder.Length > 1)
            {
                urlBuilder.Remove(urlBuilder.Length - 1, 1);
            }
            return urlBuilder.ToString();
        }
    }
}