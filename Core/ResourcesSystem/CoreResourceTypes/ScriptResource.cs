using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Parser.ParadoxScriptParser;

namespace Core.ResourcesSystem.CoreResourceTypes
{
    public class ScriptResource : IResource
    {
        IList<Operator> Ops { get; }
        public ScriptResource(string path)
        {
            Ops = ParseOps(File.ReadAllText(path));
        }
        public long Version => 0;
    }
}
