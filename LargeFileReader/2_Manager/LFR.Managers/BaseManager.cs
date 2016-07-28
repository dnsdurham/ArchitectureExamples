using LFR.Accessors;
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
        }

        public ResourceAccessorFactory ResourceAccessorFactory { get; set; }
    }
}
