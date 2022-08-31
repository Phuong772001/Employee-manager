using System.Collections.Generic;
using System.Text;

namespace Manage.Logger
{
    public static class CollectionExtensions
    {
        public static bool isEmpty(this Dictionary<string, string> data)
        {
            return data == null || data.Count == 0;
        }

        public static bool isEmpty<T>(this List<T> data) where T : class
        {
            return data == null || data.Count == 0;
        }

        public static bool isEmpty(this List<long> data)
        {
            return data == null || data.Count == 0;
        }

        public static string dumpHeaderForPostman(this Dictionary<string, string> data, string reservationString)
        {
            // no data -> return null
            if (data.isEmpty())
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            int totalItem = data.Count;
            int i = 1;
            foreach (string key in data.Keys)
            {
                stringBuilder.Append(string.Format("{0}{1} : {2}", reservationString, key, data[key]));
                // if the loop is still less than the total number of items, add \n to the line
                // the last element will not have \n
                if (i < totalItem)
                {
                    stringBuilder.Append("\n");
                }

                i++;
            }

            return stringBuilder.ToString();
        }
    }
}
