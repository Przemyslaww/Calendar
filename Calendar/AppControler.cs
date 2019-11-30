using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Calendar
{
    class AppControler
    {
        private static AppControler instance;

        private AppControler() {}

        public static AppControler getInstance()
        {
            if (instance == null)
            {
               instance = new AppControler();
            }
            return instance;
        }

        public static int TasksForDay(string date)
        {
            List<TaskModel> list = LoadTasksForDay(date);
            return list.Count;
        }

        public static List<TaskModel> LoadTasksForDay(string date)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "SELECT * FROM Tasks WHERE date = @Date;";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Date", date);

                var output = cnn.Query<TaskModel>(sql, dynamicParameters);
                return output.ToList();
            }
        }

        public static void CreateTask(string text, string date)
        {
            TaskModel tm = new TaskModel
            {
                date = date,
                taskText = text,
                isChecked = 0
            };

            SaveTask(tm);

        }

        public static void SaveTask(TaskModel task)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Tasks (taskText, isChecked, date) values (@taskText, @isChecked, @date)", task);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
