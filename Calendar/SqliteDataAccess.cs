using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class SqliteDataAccess
    {
        public static List<TaskModel> LoadTasksForDay(int dayID)
        {
            //connection to database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //query syntax
                var output = cnn.Query<TaskModel>("SELECT * FROM Tasks" + "WHERE dayID = " + dayID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveTask(TaskModel task)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Tasks (taskText, isChecked, dayID) values (@taskText, @isChecked, @dayID)", task);
            }
        }

        public static void CountTasksForDay(int dayID)
        {
            //TO DO
        }



        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
