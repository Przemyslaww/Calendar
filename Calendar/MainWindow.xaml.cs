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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    public partial class MainWindow : Window
    {
        private AppControler appControler;
        private List<Button> dayList = new List<Button>();

        public DateTime myDate;
        private int daysInMonth;
        private DayOfWeek firstDayOfWeek;

        public MainWindow()
        {
            InitializeComponent();
            this.appControler = AppControler.getInstance();
            CreateMonth();
            HighlightCurrentDay();
            UpdateDays();
        }


        private Brush GetColor(int value)
        {
            switch(value)
            {
                case 0:
                    return "#00ffffff".ToBrush();
                case 1:
                    return "#80ffffe0".ToBrush();
                case 2:
                    return "#8090ee90".ToBrush();
                case 3:
                    return "#80008000".ToBrush();
                case 4:
                    return "#80006400".ToBrush();
                case 5:
                    return "#80ffff00".ToBrush();
                case 6:
                    return "#80ffa500".ToBrush();
                case 7:
                    return "#80ff4500".ToBrush();
                default:
                    return "#80ff0000".ToBrush();
            }
        }

        private void UpdateDays()
        {
            foreach(Button b in dayList)
            {
                string day = b.Content.ToString();
                string date = day +"."+ myDate.Month.ToString()+"."+ myDate.Year.ToString();

                //zapytanie do bazy
                int taskCount = AppControler.TasksForDay(date);

                b.BorderThickness = new Thickness(1, 4, 1, 1);
                b.BorderBrush = GetColor(taskCount);
            }
        }

        public void GetTime()
        {
            myDate = DateTime.Today;
            daysInMonth = DateTime.DaysInMonth(myDate.Year, myDate.Month);
            DateTime firstDay = new DateTime(myDate.Year, myDate.Month, 1);
            // sun - 0 sat - 6
            firstDayOfWeek = firstDay.DayOfWeek;
        }

        private void CreateButton(int col, int row, int day)
        {

            Button btn = new Button
            {
                FontSize = 20,
                FontWeight = FontWeights.Light,
                Background = Brushes.Transparent,
                Foreground = "#ffdcfd".ToBrush(),
                Name = "Button" + (row + 1) + (col + 1),
                Content = day,
                Margin = new Thickness(1, 1, 1, 1)
            };
            btn.Click += CalendarClick;
            Grid.SetRow(btn, row + 1);
            Grid.SetColumn(btn, col + 1);
            calendarGrid.Children.Add(btn);
            dayList.Add(btn);
        }

        public void CreateMonth()
        {
            int offset = 0;
            GetTime();
            switch (firstDayOfWeek)
            {
                case DayOfWeek.Monday:
                    offset = 0;
                    break;
                case DayOfWeek.Tuesday:
                    offset = 1;
                    break;
                case DayOfWeek.Wednesday:
                    offset = 2;
                    break;
                case DayOfWeek.Thursday:
                    offset = 3;
                    break;
                case DayOfWeek.Friday:
                    offset = 4;
                    break;
                case DayOfWeek.Saturday:
                    offset = 5;
                    break;
                case DayOfWeek.Sunday:
                    offset = 6;
                    break;
            }

            int day = 1;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if(offset != 0)
                    {
                        col += offset;
                        offset = 0;
                    }
                    if(day <= daysInMonth)
                    {
                        CreateButton(col, row, day);
                        day++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(day >= daysInMonth)
                {
                    break;
                }
            }
            

        }

        private void HighlightCurrentDay()
        {
            foreach(Button b in dayList)
            {
                if(b.Content.ToString() == myDate.Day.ToString())
                {
                    //b.Background = Brushes.MediumPurple;
                    b.Background = "#1affffff".ToBrush();
                    b.Foreground = Brushes.White;
                    //b.BorderThickness = new Thickness(5,5,5,5);
                    //b.BorderBrush = Brushes.MediumPurple;
                }
            }
        }

        private void CalendarClick(object sender, RoutedEventArgs e)
        {
            string day;
            Button button = sender as Button;
            day = button.Content.ToString();
            string clickedDay = day + "." + myDate.Month.ToString() + "." + myDate.Year.ToString();

            DayWindow dayWindow = new DayWindow(clickedDay, this);
            dayWindow.Closed += DayWindowClosed;
            dayWindow.Show();

        }

        public void DayWindowClosed(object sender, System.EventArgs e)
        {   
            UpdateDays();
        }

    }
}
