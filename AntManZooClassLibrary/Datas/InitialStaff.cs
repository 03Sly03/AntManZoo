using AntManZooClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntManZooClassLibrary.Datas
{
    public class InitialStaff
    {
        public static readonly List<Staff> staffs = new List<Staff>()
        {
            new Staff{ Id = 1, Firstname = "Anthony", Lastname = "Douchet", Email = "anthony.douchet@hotmail.fr", Password = null}
        };
    }
}
