using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Models
{
    public class FoodItems 
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public float cal { get; set; }
        public FoodItems() {

        }

        public FoodItems(string Name, float Cal) {
            name = Name;
            cal = Cal;

        }
    }
}
