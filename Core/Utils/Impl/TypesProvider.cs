using Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Utils.Impl
{
    public class TypesProvider : ITypesProvider
    {
        public IList<Type> GetChildrenOf(Type type)
        {
            throw new NotImplementedException();
        }

        public IList<Type> GetChildrenOfGeneric(Type type)
        {
            throw new NotImplementedException();
        }

        public IList<Type> GetGenericInterfaceImplementations(Type type)
        {
            IList<Type> types = new List<Type>();
            foreach (var asmType in Assembly.GetExecutingAssembly().GetTypes())
                if (asmType.GetBaseGenericInterfaces(type).Count > 0)
                    types.Add(asmType);
            return types;
        }

        public IList<Type> GetInterfaceImplementations(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
