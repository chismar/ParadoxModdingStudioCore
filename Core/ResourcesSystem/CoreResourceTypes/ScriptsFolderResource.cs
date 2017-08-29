using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.ResourcesSystem.CoreResourceTypes
{
    public class ScriptsFolderResource : IResource
    {
        string _relativePath;
        IFileSystem _fileSystem;
        public ScriptsFolderResource(string relativePath, IFileSystem fileSystem)
        {
            _relativePath = relativePath;
            _fileSystem = fileSystem;
            Paths = new List<string>();
            ReadAllFiles();
        }
        public IList<string> Paths { get; }
        bool _recursive = false;
        public bool Recursive { get { return _recursive; } set { if (_recursive != value) { _recursive = value; ReadAllFiles(); } else _recursive = value; } }
        public long Version => 0;

        void ReadAllFiles()
        {
            Paths.Clear();
            foreach (var file in _fileSystem.GetAllFiles(_relativePath, Recursive))
            {
                Paths.Add(file);
            }
        }
    }
}
