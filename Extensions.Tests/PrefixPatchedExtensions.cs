using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Tests;

internal static  class PrefixPatchedExtensions
{
    public static bool Prefix(List<byte> input, ref List<byte> __result)
    {
        __result = new List<byte>(input);
        return false; // skip original method 
    }
}
