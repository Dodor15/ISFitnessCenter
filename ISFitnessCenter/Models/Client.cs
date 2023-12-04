using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? FIOclient { get; set; }
        public string? NumberPhone {get; set;}
        public bool Pool { get; set; }
        public bool Ring { get; set; }
        public bool Aerobic { get; set; }
        public bool Dance { get; set; }
        public bool trampoline { get; set; }
    }
}
