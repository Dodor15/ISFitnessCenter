using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class Specialyty_Trener
    {
        public int Specialyty_TrenerId { get; set; }
        public Specialtiy SpecialtiyId { get; set; }
        public Trener trenerId { get; set; }
    }
}
