using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calendar
{

    public partial class DayWindow : Window
    {
        private AppControler appControler;
        private MainWindow mainWindow;
        private string date;

        public DayWindow(string d, MainWindow mw)
        {
            InitializeComponent();
            this.appControler = AppControler.getInstance();
            this.mainWindow = mw;
            dayLabel.Content = d;
            date = d;
            UpdateTasksInThisDay();
        }

        private void UpdateTasksInThisDay()
        {
            foreach(TaskModel tm in AppControler.LoadTasksForDay(date))
            {
                toDoList.Children.Add(new TaskControl(toDoList, tm.taskText, Convert.ToBoolean(tm.isChecked) ));
            }
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            AppControler.CreateTask(enteredText.Text, date);
            toDoList.Children.Add(new TaskControl(toDoList, enteredText.Text));

            enteredText.Text = "";
        }


    }
}
