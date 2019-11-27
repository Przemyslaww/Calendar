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

        private StackPanel parent;

        public TaskControl(StackPanel list, string taskText)
        {
            InitializeComponent();
            parent = list;
            textBlock.Text = taskText;
        }


        //do poprawy
        private void SettingKeybordFocus(IInputElement ie)
        {
            Keyboard.ClearFocus();
            Keyboard.Focus(ie);
        }

        private void UpdateTaskText(object sender, RoutedEventArgs e)
        {
            // TO DO Later
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            parent.Children.Remove(this);
            //MessageBox.Show(string.Format("Kliknięto delete"));
        }
    }
}
