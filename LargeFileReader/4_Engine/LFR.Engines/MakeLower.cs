using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Engines
{
    public interface IMakeLower
    {
        string Lower(string input);
    }

    class MakeLower : BaseEngine, IMakeLower
    {
        public string Lower(string input)
        {
            return input.ToLower();
        }
    }
}
