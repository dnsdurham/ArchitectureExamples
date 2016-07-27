using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.DataContracts
{
    public class Customer
    {
        public string First { get; set; }
        public string Last { get; set; }

        public override string ToString()
        {
            return First + " " + Last;
        }
    }
}
