using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    internal class ControlCRUD : Print
    {
        private int inp;
        private string inp2;
        public void TambahBarang(List<BarangClass> barang, string nama, int harga)
        {

            Enter();
            BarangClass a = new BarangClass();
            a.nama = nama;
            a.harga = harga;
            barang.Add(a);
            Console.WriteLine("Barang Berhasil di tambahkan");
            Enter();
        }
        public void UpdateBarang(List<BarangClass> barang, string nama)
        {
            if (barang != null)
            {
                foreach (BarangClass b in barang)
                {
                    if (b.nama == nama)
                    {
                        Console.Clear();
                        Enter();
                        Console.WriteLine("\tBarang ditemukan");
                        do
                        {
                        Enter();
                        Console.WriteLine("Apa yang akan di rubah \n1. Nama \n2. Harga \n3. Keduanya: ");
                        Console.Write("Pilih Update : ");
                        inp = Convert.ToInt32(Console.ReadLine());
                        Enter();
                        switch (inp)
                        {
                            case 1:
                                Console.Write("Masukkan Perubahan Nama : ");
                                inp2 = Console.ReadLine();
                                b.nama = inp2;
                                Console.WriteLine("\t Update Berhasil");
                                break;
                            case 2:
                                Console.Write("Masukkan Perubahan Harga : ");
                                inp = Convert.ToInt32( Console.ReadLine());
                                b.harga=inp;
                                Console.WriteLine("\t Update Berhasil");
                                break;
                            case 3:
                                Console.Write("Masukkan Perubahan Nama : ");
                                inp2 = Console.ReadLine();
                                b.nama = inp2;
                                Console.Write("Masukkan Perubahan Harga : ");
                                inp = Convert.ToInt32( Console.ReadLine());
                                b.harga = inp;
                                Console.WriteLine("\t Update Berhasil");
                                break;
                        }
                            Console.Write("Ulangi Perubahan ? ");
                            inp2 = Console.ReadLine();
                            Console.Clear();
                        } while (inp2.Equals("y"));
                    }
                }
            }
        }
        public void CheckBarang(List<BarangClass> barang)
        {
            if (barang != null)
            {
                Console.WriteLine("=============== List Barang ==============");
                int i = 0;
                foreach (BarangClass item in barang)
                {
                    Console.WriteLine($"{i+1}. {item.nama} \tRp.{item.harga},00");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Semua Stock Habis (Kosong)");
            }
        }
        public void DeleteBarang(List<BarangClass> barang, string nama)
        {
            BarangClass temp = null;

            if (barang != null)
            {
                foreach (BarangClass c in barang)
                {
                    if (c.nama == nama)
                    {
                        temp = c;
                    }
                }
                barang.Remove(temp);
                Console.WriteLine("\t Delete Berhasil");
            }
            else
            {
                Console.WriteLine("Semua Stock Habis (Kosong)");
            }
        }

        public void SelectItem(List<BarangClass> terpilih)
        {
        }

        public void Enter()
        {
            Console.WriteLine("==========================================");
        }
    }
}
