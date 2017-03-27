using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspMvc5LangSwitcher.Models
{
    public class TypeSafeEnum<T> where T : TypeSafeEnum<T>
    {
        public string Name { get; }
        public string Code { get; }

        // Reflection
        public static IEnumerable<T> All
        {
            get
            {
                var type = typeof(T);
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                return fields.Select(info => info.GetValue(null)).OfType<T>().OrderBy(i => i.Name);
            }
        }

        protected TypeSafeEnum(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return Name;
        }

        public static TypeSafeEnum<T> FindByCode(string code)
        {
            return Parse(code, item => item.Code == code);
        }

        public static TypeSafeEnum<T> FindByName(string name)
        {
            return Parse(name, item => item.Name == name);
        }

        private static TypeSafeEnum<T> Parse(string identifier, Func<TypeSafeEnum<T>, bool> predicate)
        {
            var matchingItem = All.FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = $"'{identifier}' is not a valid identifier in {typeof(T)}";
                throw new ApplicationException(message);
            }

            return matchingItem;
        }
    }
}