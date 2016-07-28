using LFR.Accessors;
using LFR.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Managers
{
    class BaseManager : BaseService, IManagerService
    {
        public BaseManager()
        {
            ResourceAccessorFactory = new ResourceAccessorFactory();
            EngineFactory = new EngineFactory();
        }

        public IFactory ResourceAccessorFactory { get; set; }


        public IFactory EngineFactory { get; set; }
    }
}
