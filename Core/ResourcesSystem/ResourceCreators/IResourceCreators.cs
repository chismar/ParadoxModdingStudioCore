using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem.ResourceCreators
{
    public interface IResourceCreators
    {
        IResourceCreator<T> GetResourceCreator<T>();
    }
}
