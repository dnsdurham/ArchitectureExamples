using LFR.Accessors;
using LFR.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Managers
{
    class DataFileManager : BaseManager, IDataFileManager
    {
        public string Read(string path, int start, bool makeLower)
        {
            var result = ResourceAccessorFactory.Create<IFileReader>().Read(path, start);
            if (makeLower)
                result = EngineFactory.Create<IMakeLowerEngine>().Lower(result);
            return result;
        }

        public int NumberOfParts(string path)
        {
            return ResourceAccessorFactory.Create<IFileReader>().NumberOfParts(path);
        }
    }
}
