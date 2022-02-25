using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    internal class RoleUser : Print
    {
        public string roleName { get; set; }
        public string pass;

        public RoleUser()
        {
        }

        public bool roleDigunakan(string role, string pass)
        {
            
            if(role == "Admin" && pass == "12345")
            {
                return true;
            }else if(role == "pembeli")
            {
                return true;
            }else
            {
                Enter();
                Console.WriteLine($"Role hanya ada Admin dan Pembeli");
                return false;
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
