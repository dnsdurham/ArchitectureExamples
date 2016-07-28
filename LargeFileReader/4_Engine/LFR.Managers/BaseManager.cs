using LFR.Accessors;
using LFR.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Managers
{
    class BaseManager
    {
        public BaseManager()
        {
            ResourceAccessorFactory = new ResourceAccessorFactory();
            EngineFactory = new EngineFactory();
        }

        public ResourceAccessorFactory ResourceAccessorFactory { get; set; }


        public EngineFactory EngineFactory { get; set; }
    }
}
