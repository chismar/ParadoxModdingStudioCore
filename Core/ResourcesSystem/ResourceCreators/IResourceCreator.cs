using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem.ResourceCreators
{
    public interface IResourceCreator<T>
    {
        T Create(string path);
    }
}
