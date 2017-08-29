using Core.ResourcesSystem.CoreResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem.ResourceCreators.Impl
{
    public class ResourceCreators : IResourceCreators
    {
        FolderResourceCreator _folderResourceCreator;
        ScriptResourceCreator _scriptResourceCreator;
        public ResourceCreators(IFileSystem system)
        {
            _folderResourceCreator = new FolderResourceCreator(system);
            _scriptResourceCreator = new ScriptResourceCreator();
        }
        public IResourceCreator<T> GetResourceCreator<T>()
        {
            if(typeof(T) == typeof(ScriptResource))
            {
                return _scriptResourceCreator as IResourceCreator<T>;
            }
            if (typeof(T) == typeof(ScriptsFolderResource))
            {
                return _folderResourceCreator as IResourceCreator<T>;
            }
            return default(IResourceCreator<T>);
        }
    }
}
