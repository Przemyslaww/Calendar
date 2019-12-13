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
        private bool isEdited;
        private TaskControl editControl;

        public DayWindow(string d, MainWindow mw)
        {
            InitializeComponent();
            this.appControler = AppControler.getInstance();
            this.mainWindow = mw;
            dayLabel.Content = d;
            date = d;
            isEdited = false;
            UpdateTasksInThisDay();
        }

        private void UpdateTasksInThisDay()
        {
            foreach(TaskModel tm in AppControler.LoadTasksForDay(date))
            {
                toDoList.Children.Add(new TaskControl(toDoList, tm.taskText, Convert.ToBoolean(tm.isChecked),this ));
            }
        }

        public void RemoveTask(string text)
        {
            AppControler.RemoveTask( text ,date);
        }

        public void UpdateTask(TaskControl taskControl)
        {
            isEdited = true;
            editControl = taskControl;
            enteredText.Text = taskControl.textBlock.Text;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            if(isEdited)
            {
                isEdited = false;
                AppControler.UpdateTask(editControl.textBlock.Text, enteredText.Text, date);
                editControl.textBlock.Text = enteredText.Text;
            }
            else
            {
                toDoList.Children.Add(new TaskControl(toDoList, enteredText.Text, this));
                AppControler.CreateTask(enteredText.Text, date);
            }
            enteredText.Text = "";
        }


    }
}
