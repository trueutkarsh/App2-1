using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App2.Models
{
    public class User
    {
        [SQLite.PrimaryKey,SQLite.AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public bool isMale { get; set; }
        public int activityRate { get; set; }
        public bool loseCalories { get; set; }

        //public List<time>;
            
        public User() {
        }

        public User( string Name, string phonenumber, float Height, float Weight, bool IsMale, int ActivityRate, bool LoseCalories) {
            name = Name;
            phoneNumber = phonenumber;
            height = Height;
            weight = Weight;
            isMale = IsMale;
            activityRate = ActivityRate;
            loseCalories = LoseCalories;

        }





    }
}
