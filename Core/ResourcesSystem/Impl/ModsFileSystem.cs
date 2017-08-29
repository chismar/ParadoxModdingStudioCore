using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Parser;
using static Parser.ParadoxScriptParser;
namespace Core.ResourcesSystem.Impl
{
    public class ModsFileSystem : IFileSystem
    {
        string _gameInstall;
        string _modsFolder;
        IList<string> _referencedMods;
        string _developedMod;
        HashSet<string> _replacePathSet = new HashSet<string>();
        public ModsFileSystem(string gameInstall, string modsFolder, string developedMod, IEnumerable<string> referencedMods = null)
        {
            _gameInstall = gameInstall;
            var modFolderHost = modsFolder.Substring(0, modsFolder.Length - @"mod\".Length);
            var modFile = ParseOps(File.ReadAllText(modsFolder + developedMod + ".mod"));
            var path = modFile.Find(x => x.NameId() == "path").String();
            _modsFolder = modFolderHost + path.Replace(@"/", @"\");
            var replacePaths = modFile.FindAll(x => x.NameId() == "replace_path");
            foreach(var replacePath in replacePaths)
            {
                var replaceLocalPath = replacePath.String();
                _replacePathSet.Add(replaceLocalPath.Replace(@"/", @"\"));
            }
            _developedMod = modsFolder + developedMod + @"\";
            _referencedMods = new List<string>();
            if (referencedMods != null)
                foreach (var refMod in referencedMods)
                {
                    _referencedMods.Add(_modsFolder + refMod + @"\");
                }
        }

        public string[] GetAllDirectories(string relativePath)
        {
            if (_replacePathSet.Contains(relativePath))
                return new string[] { _developedMod + relativePath };
            List<string> dirs = new List<string>();
            dirs.Add(_gameInstall + relativePath);
            foreach (var refMod in _referencedMods)
                if (Directory.Exists(refMod + relativePath))
                    dirs.Add(refMod + relativePath);
            if (Directory.Exists(_developedMod + relativePath))
                dirs.Add(_developedMod + relativePath);
            return dirs.ToArray();
        }

        public string[] GetAllFiles(string relativePath, bool recursive)
        {
            Dictionary<string, string> filesDictionary = new Dictionary<string, string>();
            var dirs = GetAllDirectories(relativePath);
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir, "*.txt", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    var localPath = file.Substring(dir.Length);
                    if (filesDictionary.ContainsKey(localPath))
                        filesDictionary[localPath] = file;
                    else
                        filesDictionary.Add(localPath, file);
                }
            }
            var array = new string[filesDictionary.Count];
            int index = 0;
            foreach (var file in filesDictionary)
                array[index++] = file.Value;
            return array;
        }
    }
}
