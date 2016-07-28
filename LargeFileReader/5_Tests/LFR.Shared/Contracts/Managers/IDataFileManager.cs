using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR
{
    public interface IDataFileManager : IBaseService
    {
        string Read(string path, int start, bool makeLower);
        int NumberOfParts(string text);
    }
}
