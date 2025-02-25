using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Tests;

internal static class FakeExtensions
{
    public static List<byte> AddCrc(this List<byte> input)
    {
        return input;
    }
}
