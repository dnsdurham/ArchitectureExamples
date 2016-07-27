using ABC.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Managers
{
    class BaseManager
    {
        AccessorFactory _accessorFactory = new AccessorFactory();
        public AccessorFactory AccessorFactory
        {
            get
            {
                return _accessorFactory;
            }
        }
    }
}
