using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem
{
    public interface IResourcesKeeper
    {
        IResourceHandle<T> Handle<T>(string path) where T : IResource;
    }
    
}
