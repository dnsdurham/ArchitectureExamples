using LFR.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Engines
{
    class BaseEngine : BaseService, IEngineService
    {
        public BaseEngine()
        {
            ResourceAccessorFactory = new ResourceAccessorFactory();
        }

        public IFactory ResourceAccessorFactory { get; set; }

    }
}
