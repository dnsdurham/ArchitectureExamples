using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR
{
    public abstract class BaseService : IBaseService
    {
        public string TestMe(string input)
        {
            return input;
        }
    }
}
