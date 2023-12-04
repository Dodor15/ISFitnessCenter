using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class Trener
    {
        public int TrenerId { get; set; }
        public string FIOtrener { get; set; }
        public Adress AdressTrener { get; set; }
    }
}
