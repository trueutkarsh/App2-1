using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;

using App2.Models;
using Windows.Storage;
using System.IO;

namespace App2.Helpers
{
     public class DatabaseHelper
    {
        SQLiteConnection dbConn;
        SQLiteConnection dbConnUser;
        SQLiteConnection dbConnLog;

         string DB_PATH = Path.Combine(ApplicationData.Current.LocalFolder.Path, "FoodItems2.sqlite");//DataBase Name   
         string DB_PATH2 = Path.Combine(ApplicationData.Current.LocalFolder.Path, "User2.sqlite");//DataBase Name   
        string DB_PATH3 = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Log.sqlite");//DataBase Name 

        public async Task<bool> onCreate()
        {
            try
            {
                //create the server
                if (!CheckFileExists("FoodItems2.sqlite").Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH,false))
                    {
                        
                        dbConn.CreateTable<FoodItems>();

                    }
                }
                if (!CheckFileExists("User2.sqlite").Result)
                {

                    using (dbConnUser = new SQLiteConnection(DB_PATH2,false))
                    {
                        dbConnUser.CreateTable<User>();

                    }
                }
                if (!CheckFileExists("Log.sqlite").Result)
                {
                    using (dbConnLog = new SQLiteConnection(DB_PATH3, false))
                    {

                        dbConnLog.CreateTable<Log>();

                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                //server not created
                return false;
            }
        }

        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store =  Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            }
            catch(Exception x)
            {
                return false;
            }
            return true;

        }

        public List<FoodItems> findFood( string name)
        {
            List<FoodItems> list = new List<FoodItems>();

            /*
            string query = "SELECT * FROM food WHERE";
            if (foodid != -1)
            {
                query += " ID = " + foodid + "AND name LIKE (% " + name + " %)";
            }
            else if (name != null)
            {
                query += " name LIKE (%" + name + "%)";
            }
            else
            {

            }
            */
            using (var dbConn = new SQLiteConnection(App.DB_PATH,false))
            {

                var foodItem = dbConn.Table<FoodItems>().Where(f =>  f.name.Contains(name));
                list = foodItem.ToList();

            }
            return list;
        }

        public  void insertFood(FoodItems food)
        {

            using (var dbConn = new SQLiteConnection(App.DB_PATH,false))
            {


                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(food);
                });

            }

        }

         public void upsert(User user)
        {
            //string query = "SELECT count(*) from user";
            //Debug.WriteLine(CheckFileExists(DB_PATH));
            //Debug.WriteLine(CheckFileExists(DB_PATH2));

            using (var dbConnUser = new SQLiteConnection(App.DB_PATH2,false))
            {
                try
                {
                    int count = dbConnUser.Table<User>().Count();
                    if (count == 0)
                    {
                        dbConnUser.RunInTransaction(() =>
                        {
                            dbConnUser.Insert(user);
                        });
                    }
                    else
                    {
                        var User = dbConnUser.Table<User>().Where(f => true).FirstOrDefault();
                        User.name = user.name;
                        User.phoneNumber = user.phoneNumber;
                        User.isMale = user.isMale;
                        User.loseCalories = user.loseCalories;
                        User.height = user.height;
                        User.weight = user.weight;
                        User.activityRate = user.activityRate;
                        dbConnUser.RunInTransaction(() =>
                        {
                            dbConnUser.Update(User);
                        });
                    }
                    Debug.WriteLine("done");
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.StackTrace);

                }
            }
        }



        public User readUser()
        {
            using (var dbConnUser = new SQLiteConnection(App.DB_PATH2,false))
            {
                var existingconact = dbConnUser.Table<User>().FirstOrDefault();
                return existingconact;
            }
        }

        public void updateLog(Log log) {

            log.cumCalorie += lastLog().cumCalorie;
            using (var dbConnLog = new SQLiteConnection(DB_PATH3, false))
            {
                dbConnLog.RunInTransaction(() =>
                {
                    dbConnLog.Insert(log);
                });
            }
        }

        public Log lastLog() {

            using (var dbConn = new SQLiteConnection(App.DB_PATH3, false))
            {

                var foodItem = dbConn.Table<Log>().Last();
                return foodItem;
            }
        }

        public List<Log> getAllLog() {
            List<Log> list = new List<Log>();
            using (var dbConn = new SQLiteConnection(App.DB_PATH3, false))
            {

                var foodItem = dbConn.Table<Log>().Where(f => true);
                list = foodItem.ToList();

            }
            return list;
        }
         public List<FoodItems> getAllFood()
        {
            List<FoodItems> list = new List<FoodItems>();
            using (var dbConn = new SQLiteConnection(App.DB_PATH, false))
            {

                var foodItem = dbConn.Table<FoodItems>().Where(f => true);
                list = foodItem.ToList();

            }
            return list;
        }
        /*
                public static void main(String[] args) {

                    User user = new User();
                    user.name = "xyz";
                    user.phoneNumber = "adasdfas";
                    user.Id = 1;
                    DatabaseHelper dbh = new DatabaseHelper();
                    dbh.onCreate();
                }
          */


    }
}
    

