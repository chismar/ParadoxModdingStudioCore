using Core.ResourcesSystem.ResourceCreators;
using Core.Utils;
using Core.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.ResourcesSystem.Impl
{
    public class ResourcesKeeper : IResourcesKeeper
    {
        IResourceCreators _creators;
        public ResourcesKeeper(IResourceCreators creators, ITypesProvider typesProvider)
        {
            _creators = creators;
        }
        public IResourceHandle<T> Handle<T>(string path) where T : IResource
        {
            var handle = new ResourceHandle<T>(_creators.GetResourceCreator<T>().Create(path));
            return handle;
        }
    }
}
