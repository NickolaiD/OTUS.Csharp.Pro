using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflection
{
    public static class Serializer
    {
        public static string Serialize(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            StringBuilder result = new StringBuilder();
            Type type = obj.GetType();

            result.AppendLine($"{type.Name}:");
            // Сериализация свойств
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {

                // Проверяем, есть ли геттер
                MethodInfo? getMethod = property.GetGetMethod(true);
                if (getMethod != null)
                {
                    object? value = property.GetValue(obj);
                    result.AppendLine($"  {property.Name} ({property.PropertyType.Name}) = {(value == null ? "null" : value)}");
                }
            }

            return result.ToString();
        }

        public static T Deserialize<T>(string csvLine, char delimiter = ',') where T : new()
        {
            string[] values = csvLine.Split(delimiter);
            T obj = new T();

            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < Math.Min(properties.Length, values.Length); i++)
            {
                if (!string.IsNullOrEmpty(values[i]))
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(values[i], properties[i].PropertyType);
                        properties[i].SetValue(obj, convertedValue);
                    }
                    catch
                    {
                        // Пропускаем ошибки конвертации
                    }
                }
            }

            return obj;
        }
    }
}
