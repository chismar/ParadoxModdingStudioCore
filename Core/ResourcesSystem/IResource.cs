using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResourcesSystem
{
    public interface IResource
    {
        long Version { get; }
    }
}
