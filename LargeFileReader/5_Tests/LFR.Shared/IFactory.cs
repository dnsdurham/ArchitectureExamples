using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR
{
    public interface IFactory
    {
        void AddOverride<I>(I proxy) where I : class;

        void ClearOverrides();

        I Create<I>() where I : class;
    }
}
