using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Accessors
{
    public class ResourceAccessorFactory : BaseFactory, IFactory
    {
        public override I Create<I>()
        {
            var result = base.Create<I>();
            if (result != null)
                return result;

            if (typeof(I).Name == typeof(IFileReader).Name)
                return new FileReader() as I;

            return null;
        }
    }
}
