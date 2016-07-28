using LFR.Accessors;
using LFR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Managers
{
    class DataFileManager : BaseManager, IDataFileManager
    {
        public string Read(string path, int start)
        {
            return ResourceAccessorFactory.Create<IFileReader>().Read(path, start);
        }
    }
}
