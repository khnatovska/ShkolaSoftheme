using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandle
{
    [Flags]
    public enum FileAccessEnum
    {
        Read = 0x0, Write = 0x1
    }
}
