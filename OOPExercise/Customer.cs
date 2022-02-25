using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    internal class Customer
    {
        private string idPembeli { get; set; }
        public int no { get; set; }


        public Customer()
        {
        }

        public Customer(string idPembeli)
        {
            this.idPembeli = idPembeli;
        }

    }
}
