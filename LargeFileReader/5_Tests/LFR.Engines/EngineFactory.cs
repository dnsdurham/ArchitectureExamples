using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Engines
{
    public class EngineFactory : BaseFactory, IFactory
    {
        public override I Create<I>()
        {
            var result = base.Create<I>();
            if (result != null)
                return result;

            if (typeof(I).Name == typeof(IMakeLowerEngine).Name)
                return new MakeLowerEngine() as I;

            return null;
        }
    }
}
