using ClassesScheduler.Models;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace ClassesScheduler.Helpers
{
    public static class EnumToListHelper
    {
        public static ObservableCollection<KeyValue> Convert<T>()
        {
            ObservableCollection<KeyValue> result = new ObservableCollection<KeyValue>();
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            KeyValue kv;
            Array valueAry = Enum.GetValues(typeof(T));
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                kv = new KeyValue();
                kv.Key = item;
                kv.Value = (int)Enum.Parse(typeof(T), item);
                kv.Description = r.Replace(item, " ");
                result.Add(kv);
            }
            return result;
        }
    }
}
