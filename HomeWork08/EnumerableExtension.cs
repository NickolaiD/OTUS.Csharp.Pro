using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HomeWork08
{
    public static class EnumerableExtension
    {
        public static T? GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (convertToNumber == null)
                throw new ArgumentNullException(nameof(convertToNumber));

            T? maxElement = null;
            float maxValue = float.MinValue;
            bool hasElements = false;

            foreach (object item in collection)
            {
                if (item is T typedItem)
                {
                    float currentValue = convertToNumber(typedItem);

                    if (!hasElements || currentValue > maxValue)
                    {
                        maxValue = currentValue;
                        maxElement = typedItem;
                        hasElements = true;
                    }
                }
            }

            if (!hasElements)
                throw new InvalidOperationException("Коллекция не содержит элементов типа T или пуста");

            return maxElement;
        }
    }
}
