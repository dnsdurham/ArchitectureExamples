using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR
{
    public interface IManagerService : IBaseService
    {
        IFactory ResourceAccessorFactory { get; set; }

        IFactory EngineFactory { get; set; }
    }
}
