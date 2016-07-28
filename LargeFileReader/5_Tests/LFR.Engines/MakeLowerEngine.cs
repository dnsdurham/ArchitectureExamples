using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Engines
{
    class MakeLowerEngine : BaseEngine, IMakeLowerEngine
    {
        public string Lower(string input)
        {
            return input.ToLower();
        }
    }
}
