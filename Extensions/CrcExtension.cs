using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions;

public static class CrcExtension
{
    public static List<byte> AddCrc(this List<byte> input)
    {
        byte crc = 0x00;
        input.ForEach(b=>crc^=b);
        input.Add(crc);

        return input;
    }
}
