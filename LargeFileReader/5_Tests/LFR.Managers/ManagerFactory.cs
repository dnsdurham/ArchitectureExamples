using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Managers
{
    public class ManagerFactory : BaseFactory, IFactory
    {
        public override I Create<I>()
        {
            var result = base.Create<I>();
            if (result != null)
                return result;

            if (typeof(I).Name == typeof(IDataFileManager).Name)
                return new DataFileManager() as I;

            return null;
        }
    }
}
