using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Models
{
    public class Log
    {
        public float cumCalorie { get; set; }
        public DateTime time { get; set; }
        public string name { get; set; }

        public Log() {

        }

        public Log(float cal,string Name) {
            cumCalorie = cal;
            time = new DateTime();
            name = Name;
            
        }
    }
}
