using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    internal class BarangClass : Customer
    {
        public string kodeBarang { get; set; }
        public string nama { get; set; }
        public int harga { get; set; }

        public BarangClass()
        {
        }

        public BarangClass(string kodeBarang, string nama, int harga)
        {
            this.kodeBarang = kodeBarang;
            this.nama = nama;
            this.harga = harga;
        }

    }
}
