using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR
{
    public interface IMakeLowerEngine : IEngineService
    {
        string Lower(string input);
    }
}
