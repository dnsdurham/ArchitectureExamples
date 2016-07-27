using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Managers
{
    /// <summary>
    /// Normally we would use something such as Unity for the 
    /// Dependency Injection, but I wanted to keep this exampl
    /// simple.
    /// </summary>
    public class ManagerFactory
    {
        public I Create<I>()
            where I : class
        {
            if (typeof(I).Name == typeof(ICustomerManager).Name)
                return new CustomerManager() as I;

            return null;
        }
    }
}
