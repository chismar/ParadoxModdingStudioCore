using Core.ResourcesSystem.CoreResourceTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.ResourcesSystem.ResourceCreators.Impl
{
    class ScriptResourceCreator : IResourceCreator<ScriptResource>
    {
        public ScriptResource Create(string path)
        {
            if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                return new ScriptResource(path);
            }
            return null;
        }
    }
}
