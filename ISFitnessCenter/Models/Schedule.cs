using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public Trener trenerId { get; set; }
        public bool Mondeay { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Ftiday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        


    }
}
