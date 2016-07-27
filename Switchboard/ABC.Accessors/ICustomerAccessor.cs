using ABC.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Accessors
{
    public interface ICustomerAccessor
    {
        Customer[] All();

        void Insert(Customer customer);
    }

    /// <summary>
    /// Fake customer accessor. Just store everything in memory.
    /// Normally there would need to be more error handling. The 
    /// insert method normally wouldn't return nothing.
    /// </summary>
    class CustomerAccessor : BaseAccessor, ICustomerAccessor
    {
        private static List<Customer> _customers = new List<Customer>();

        public Customer[] All()
        {
            return _customers.ToArray();
        }

        public void Insert(Customer customer)
        {
            _customers.Add(customer);
        }
    }

}
