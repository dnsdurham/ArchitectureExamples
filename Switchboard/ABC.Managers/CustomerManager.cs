using ABC.Accessors;
using ABC.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Managers
{
    public interface ICustomerManager
    {
        Customer[] All();

        void Insert(Customer customer);
    }

    /// <summary>
    /// This is a very very basic manager. Normally they just don't
    /// call accessors. But this is a very simple example.
    /// </summary>
    class CustomerManager : BaseManager, ICustomerManager
    {
        public Customer[] All()
        {
            return AccessorFactory.Create<ICustomerAccessor>().All();
        }

        public void Insert(Customer customer)
        {
            AccessorFactory.Create<ICustomerAccessor>().Insert(customer);
        }
    }
}
