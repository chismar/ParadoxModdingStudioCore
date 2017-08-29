using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
    public interface ITypesProvider
    {
        IList<Type> GetChildrenOf(Type type);
        IList<Type> GetInterfaceImplementations(Type type);
        IList<Type> GetChildrenOfGeneric(Type type);
        IList<Type> GetGenericInterfaceImplementations(Type type);
    }
}
