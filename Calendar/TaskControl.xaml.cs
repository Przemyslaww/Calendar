using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        private DayWindow dayWindow;
        private StackPanel parent;

        public TaskControl(StackPanel list, string taskText, DayWindow window)
        {
            InitializeComponent();
            parent = list;
            textBlock.Text = taskText;
            dayWindow = window;
        }

        public TaskControl(StackPanel list, string taskText, bool isChecked, DayWindow window)
        {
            InitializeComponent();
            parent = list;
            textBlock.Text = taskText;
            checkBox.IsChecked = isChecked;
            dayWindow = window;
        }

        
        private void UpdateTaskText(object sender, RoutedEventArgs e)
        {
            //TODO    
            dayWindow.UpdateTask(this);
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            parent.Children.Remove(this);
            dayWindow.RemoveTask(this.textBlock.Text);
        }
    }
}
