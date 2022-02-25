using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    internal class Transaksi : Print
    {
        List<BarangClass> buyItem;

        public string invoice { get; set; }
        public int totalHarga { get; set; }

        public int temp = 1100;
        public int cs = 80;

        DateTime date;
        const string PREFIX = "INV";
        public Transaksi()
        {
        }

        public Transaksi(List<BarangClass> buyItem)
        {
            this.buyItem = buyItem;
            this.totalHarga = totalHarga;
        }

        public int sumPrice()
        {
            totalHarga = 0;
            foreach (BarangClass a in buyItem)
            {
                totalHarga = totalHarga + a.harga;
            }
            return totalHarga;
        }

        public bool Pembayaran(int duit, int totalHarga, List<BarangClass>
            inInvoice)
        {
            if (duit > totalHarga)
            {
                int kembalian = 0;
                kembalian = duit - totalHarga;
                Console.WriteLine($"Uang Kembalian : {kembalian}");
                Enter();
                Console.WriteLine("\tTrimakasih Telah membayar");
                RealiseInvoice(duit, kembalian, totalHarga, inInvoice);
                return true;
            }
            else if (duit<totalHarga)
            {
                Enter();
                Console.WriteLine("\tUang tidak Cukup");
                return false;
            }
            else
            {
                Enter();
                Console.WriteLine("Trimakasih Telah membayar");
                RealiseInvoice(duit, totalHarga, inInvoice);
                return true;
            }
        }

        public void RealiseInvoice(int duit, int kembalian, int totalHarga,List<BarangClass>
            inInvoice)
        {
            Console.Clear();
            Console.WriteLine(CountIdCustomer(cs));
            Enter();
            Console.WriteLine($"CODE : {CodeInvoice()}");
            Enter();
            Console.WriteLine("=========== List Barang Terbeli ==========");
            SelectItem(inInvoice);
            Console.WriteLine($"Total pembayaran belanja {totalHarga}");
            Console.WriteLine($"Jumlah membayar {duit}");
            Enter();
        }

        public void RealiseInvoice(int duit, int totalHarga, List<BarangClass>
            inInvoice)
        {
            Console.Clear();
            Console.WriteLine(CountIdCustomer(cs));
            Enter();
            Console.WriteLine($"CODE : {CodeInvoice()}");
            Enter();
            Console.WriteLine("=========== List Barang Terbeli ==========");
            SelectItem(inInvoice);
            Console.WriteLine($"Total pembayaran belanja {totalHarga}");
            Console.WriteLine($"Jumlah membayar {duit}");
            Enter();
        }

        public string CountIdCustomer(int av)
        {
            this.cs = av + 1;
            string kodeCus = "CST";
            BarangClass a = new BarangClass();
            string full = $"Id Pembeli : {kodeCus}{cs}";

            return full;
        }

        public String CodeInvoice()
        {
            temp = temp + 1;
            date = DateTime.Now;

            int tahun = Convert.ToInt32(date.ToString("yyyy").Substring(2, 2));
            int tanggal = Convert.ToInt32(date.ToString("dd"));
            String day = date.ToString("dddd").Substring(0, 2).ToUpper();
            String pfxTahun = date.ToString("yyyy");
            String bulan = date.ToString("MM");


            String invoice = $"{PREFIX}/{pfxTahun}{bulan}/{day}/{ToRoman(tanggal)}/{ToRoman(tahun)}/{temp}";
            return invoice;
        }

        static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public void SelectItem(List<BarangClass> terpilih)
        {
            int i = 0;
            foreach (BarangClass a in terpilih)
            {
                Console.WriteLine($"\t{i + 1}. {a.nama} \t {a.harga}");
                i++;
            }
        }

        public void Enter()
        {
            Console.WriteLine("==========================================");
        }

    }
}
