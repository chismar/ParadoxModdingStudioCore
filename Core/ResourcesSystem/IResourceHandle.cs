using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem
{
    public interface IResourceHandle<T> where T : IResource
    {
        bool IsDirty { get; }
        T Resource { get; }
    }
}
