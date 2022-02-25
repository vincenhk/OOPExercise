using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    internal class MainClass
    {
        public static List<BarangClass> stockBarang = new List<BarangClass>();
        public static List<BarangClass> selectItem = new List<BarangClass>();

        static void Main(string[] args)
        {
            StockAwalBarang();
            string nama_barang, back;
            int uangDimasukan;
            int pilih, save;
            
            do
            {
                save = Role();
                Console.Clear();
                if (save == 1)
                {
                    ControlCRUD a = new ControlCRUD();
                    do
                    {
                        menuAdmin();
                        Console.Write("Ketik angka untuk memilih : ");
                        pilih = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (pilih)
                        {
                            case 1:
                                do
                                {

                                    Console.WriteLine("============== Tambah Barang =============");
                                    Console.Write("Masukkan Nama Barang : ");
                                    back = Console.ReadLine();
                                    Console.Write("Masukkan Harga Barang : ");
                                    save = Convert.ToInt32(Console.ReadLine());

                                    a.TambahBarang(stockBarang, back, save);

                                    Console.Write("Tambah Barang lagi ? ");
                                    back = Console.ReadLine();
                                    Console.Clear();
                                } while (back.Equals("y"));
                                break;

                            case 2:
                                do
                                {
                                    Console.WriteLine("============== Update Barang =============");
                                    a.CheckBarang(stockBarang);
                                    enterL();

                                    Console.Write("Masukkan Nama Barang : ");
                                    back = Console.ReadLine();

                                    a.UpdateBarang(stockBarang, back);

                                    Console.Write("Update Barang lagi ? ");
                                    back = Console.ReadLine();
                                    Console.Clear();
                                } while (back.Equals("y"));
                                break;

                            case 3:
                                do
                                {
                                    Console.WriteLine("============== Delete Barang =============");
                                    a.CheckBarang(stockBarang);
                                    enterL();
                                    Console.Write("Masukkan Nama Barang : ");
                                    back = Console.ReadLine();
                                    enterL();
                                    a.DeleteBarang(stockBarang, back);

                                    Console.Write("Delete Barang lagi ? ");
                                    back = Console.ReadLine();
                                    Console.Clear();
                                } while (back.Equals("y"));
                                break;

                            case 4:
                                ControlCRUD b = new ControlCRUD();
                                b.CheckBarang(stockBarang);
                                break;

                            case 5:

                                break;
                        }
                        Console.Write("Kembali ke Menu Admin ? ");
                        back = Console.ReadLine();
                        Console.Clear();
                    } while (back.Equals("y"));
                }
                else if (save == 2)
                {
                    do
                    {
                        menu();
                        Console.Write("Ketik angka untuk memilih : ");
                        pilih = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (pilih)
                        {
                            case 1:
                                do
                                {
                                    PrintStockBarang();
                                    PilihBarang();
                                    enterL();
                                    Console.Write("Kembali berblanja ? ");
                                    back = Console.ReadLine();
                                    Console.Clear();
                                } while (back.Equals("y"));
                                break;
                            case 2:
                                do
                                {
                                    KeranjangBelanja(selectItem);
                                    PembayaranKeranjang();
                                    Console.WriteLine("Mencoba lagi ?");
                                    back = Console.ReadLine();
                                    Console.Clear();
                                } while (back.Equals("y"));
                                break;
                            case 3:
                                break;
                        }
                        Console.Clear();
                        enterL();
                        Console.WriteLine("Kembali Ke menu ? ");
                        back = Console.ReadLine();
                        Console.Clear();
                    } while (back.Equals("y"));
                }
                enterL();
                Console.Write("Kembali ke Menu Login ? ");
                back = Console.ReadLine();
                Console.Clear();
            } while (back.Equals("y"));
            
        }

        static void StockAwalBarang()
        {
            BarangClass a = new BarangClass("B1", "Shampo", 7000);
            BarangClass b = new BarangClass("B2", "Sunlight", 5000);
            BarangClass c = new BarangClass("B3", "Beras", 12000);
            BarangClass d = new BarangClass("B4", "Ciki", 10000);

            stockBarang.Add(a);
            stockBarang.Add(b);
            stockBarang.Add(c);
            stockBarang.Add(d);
        }

        static void menu()
        {
            string pilihanMenu = $"1. Beli Barang \n2. Keranjang & Bayar \n3. Keluar";
            enterL();
            Console.WriteLine("=============== MENU UTAMA ===============");
            Console.WriteLine(pilihanMenu);
            enterL();

        }
        
        static void menuAdmin()
        {
            string pilihanMenu = $"1. Tambah Barang \n2. Update Harga Barang \n3. Delete Barang \n4. Check Semua Barang  \n5. Keluar";
            enterL();
            Console.WriteLine("=============== MENU ADMIN ===============");
            Console.WriteLine(pilihanMenu);
            enterL();

        }

        static void PrintStockBarang()
        {
            enterL();
            Console.WriteLine("\t\t Menu Barang");
            int i = 0;
            foreach (BarangClass a in stockBarang)
            {
                Console.WriteLine($"{i + 1}. {a.nama} \t Rp.{a.harga}",00);
                i++;
            }
            enterL();
        }

        static void PilihBarang()
        {
            string item;
            Console.Write("Masukkan Nama Barang : ");
            item = Console.ReadLine();
            bool cek = false;
            enterL();

            foreach (BarangClass a in stockBarang)
            {
                if (a.nama.Equals(item))
                {
                    selectItem.Add(a);
                    Console.WriteLine("\tDitambahkan ke ranjang");
                    cek = true;
                }
            }

            if (cek == false)
            {
                Console.WriteLine("\tBarang tidak ditemukan");
            }
        }
        static void KeranjangBelanja(List<BarangClass> terpilih)
        {
            enterL();
            int i = 0;
            foreach (BarangClass a in selectItem)
            {
                Console.WriteLine($"{i + 1}. {a.nama} \t {a.harga}");
                i++;
            }
            enterL();
        }

        static void PembayaranKeranjang()
        {
            string op;
            int cash;
            bool val;
            Transaksi a = new Transaksi(selectItem);

            int temp = a.sumPrice();

            Console.WriteLine($"Total Belanja Rp.{temp}");
            enterL();
            Console.Write("Melanjutkan Pembayaran ? ");
            op = Console.ReadLine();

            if (op.Equals("y"))
            {
                do
                {
                    enterL();
                    Console.Write("Masukkan jumlah uang anda : ");
                    cash = Convert.ToInt32(Console.ReadLine());

                    val = a.Pembayaran(cash, temp, selectItem);

                    if (val == true)
                    {
                        selectItem.Clear();
                    }
                } while (val == false);
            }


        }
        static void MainMenu(int pilihan)
        {
            if (pilihan == 1)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("================ BELANJA ===============");
            }else if (pilihan == 2)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("=============== KERANJANG ==============");
            }


        }

        static public void enterL()
        {

            Console.WriteLine("==========================================");
        }

        static public int Role()
        {
            string rolee, pass;
            enterL();
            Console.WriteLine("====== Masukan Role Admin / Pembeli ======");
            Console.Write("Role : ");
            rolee = Console.ReadLine();
            if (rolee == "Admin")
            {
                bool a;
                int i = 0;
                Console.Write("Password : ");
                pass = Console.ReadLine();

                RoleUser user = new RoleUser();
                a = user.roleDigunakan(rolee, pass);

                return 1;
            }
            else 
            {
                pass = null;
                RoleUser user = new RoleUser();
                user.roleDigunakan(rolee, pass);

                return 2;
            }
        }
    }
}
