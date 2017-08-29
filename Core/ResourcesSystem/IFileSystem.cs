using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem
{
    public interface IFileSystem
    {
        string[] GetAllDirectories(string relativePath);
        string[] GetAllFiles(string relativePath, bool recursive);
    }
}
