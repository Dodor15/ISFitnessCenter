using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class Specialtiy
    {
        public int specialtiyId { get; set; }
        public string specialityName { get; set; }
        public int gruppa { get; set; }
        public Zals zalsId { get; set; }
    }
}
