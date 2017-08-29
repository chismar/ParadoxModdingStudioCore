using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils.Extensions
{
    public static class TypeExtensions
    {
        public static IList<Type> GetBaseGenericInterfaces(this Type target, Type interfaceType)
        {
            var list = new List<Type>();
            var interfaces = target.GetInterfaces();
            foreach (var inter in interfaces)
                if (inter.IsGenericType && inter.GetGenericTypeDefinition() == interfaceType)
                    list.Add(inter);
            return list;
            
        }
        
    }
}
