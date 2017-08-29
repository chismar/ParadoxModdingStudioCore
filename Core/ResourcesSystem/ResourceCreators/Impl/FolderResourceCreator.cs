using Core.ResourcesSystem.CoreResourceTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.ResourcesSystem.ResourceCreators.Impl
{
    class FolderResourceCreator : IResourceCreator<ScriptsFolderResource>
    {

        IFileSystem _fileSystem;
        public FolderResourceCreator(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }
        public ScriptsFolderResource Create(string path)
        {
            return new ScriptsFolderResource(path, _fileSystem);
        }
    }
}
