using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem.Impl
{
    public class ResourceHandle<T> : IResourceHandle<T> where T : IResource
    {
        public ResourceHandle(T resource)
        {
            _resource = resource;
            _version = resource.Version - 1;
        }
        private long _version;
        private T _resource;
        public bool IsDirty => _version != _resource.Version;
        public T Resource
        {
            get
            {
                if (IsDirty)
                {
                    _version = _resource.Version;
                }
                return _resource;
            }
        }
    }
}
