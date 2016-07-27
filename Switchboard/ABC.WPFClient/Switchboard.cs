using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.WPFClient
{
    public class Switchboard
    {
        public event EventHandler OnCustomerInserted;

        public void FireOnCustomerInserted()
        {
            if (OnCustomerInserted != null)
            {
                OnCustomerInserted(this, null);
            }
        }
    }
}
