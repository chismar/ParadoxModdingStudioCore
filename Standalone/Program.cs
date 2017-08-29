using Core.ResourcesSystem;
using Core.ResourcesSystem.CoreResourceTypes;
using Core.ResourcesSystem.Impl;
using Core.ResourcesSystem.ResourceCreators;
using Core.ResourcesSystem.ResourceCreators.Impl;
using Core.Utils;
using Core.Utils.Impl;
using System;
using System.Collections.Generic;

namespace Standalone
{
    class Program
    {
        static void Main(string[] args)
        {
            string gameInstall = @"C:\Program Files (x86)\Steam\steamapps\common\Hearts of Iron IV\";
            string modsFolder = @"C:\Users\Виталий\Documents\Paradox Interactive\Hearts of Iron IV\mod\";
            string developedMod = "falloutmod";
            IFileSystem fs = new ModsFileSystem(gameInstall, modsFolder, developedMod);
            ITypesProvider types = new TypesProvider();

            IResourceCreators creators = new ResourceCreators(fs);
            IResourcesKeeper keeper = new ResourcesKeeper(creators, types);
            var unitsFolder = keeper.Handle<ScriptsFolderResource>(@"common\units");
            unitsFolder.Resource.Recursive = false;
            IList<IResourceHandle<ScriptResource>> scripts = new List<IResourceHandle<ScriptResource>>();
            foreach(var path in unitsFolder.Resource.Paths)
            {
                scripts.Add(keeper.Handle<ScriptResource>(path));
            }
        }
    }
}
