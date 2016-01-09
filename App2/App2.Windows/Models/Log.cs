using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Models
{
    class Log
    {
        public float cumCalorie { get; set; }
        public DateTime time { get; set; }

        public Log() {

        }

        public Log(float cal) {
            this.cumCalorie = cal;
            this.time = new DateTime();
            
        }
    }
}
