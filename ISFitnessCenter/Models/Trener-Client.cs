using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class Trener_Client
    {
        public int trener_ClientId { get; set; }
        public Client clientID { get; set; }
        public Trener trenerID { get; set; }
        public Week week { get; set; }
        public Time time { get; set; }
        public DateTime EndTime { get; set; }
        
    }
}
