using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Accessors
{
    /// <summary>
    /// Normally we would use something such as Unity for the 
    /// Dependency Injection, but I wanted to keep this exampl
    /// simple.
    /// </summary>
    public class AccessorFactory
    {
        public I Create<I>()
            where I : class
        {
            if (typeof(I).Name == typeof(ICustomerAccessor).Name)
                return new CustomerAccessor() as I;

            return null;
        }
    }
}
