using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ObjectSystem
{
    interface IObjectRef<T> where T : IObject
    {
        T Object { get; }
        IObjectId Id { get; set; }
        bool IsValid { get; }
    }
}
