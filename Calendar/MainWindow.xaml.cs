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

        private DateTime myDate;
        private int daysInMonth;
        private DayOfWeek firstDayOfWeek;

        public MainWindow()
        {
            InitializeComponent();
            this.appControler = AppControler.getInstance();
            CreateMonth();
            HighlightCurrentDay();
        }

        public void GetTime()
        {
            myDate = DateTime.Today;
            daysInMonth = DateTime.DaysInMonth(myDate.Year, myDate.Month);
            DateTime firstDay = new DateTime(myDate.Year, myDate.Month, 1);
            // sun - 0 sat - 6
            firstDayOfWeek = firstDay.DayOfWeek;
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
                        Button btn = new Button
                        {
                            FontSize = 20,
                            FontWeight = FontWeights.Light,
                            Background = Brushes.White,
                            Foreground = Brushes.Purple,
                            Name = "Button" + (row + 1) + (col + 1),
                            Content = day,
                            Margin = new Thickness (1,1,1,1)
                        };
                        btn.Click += CalendarClick;
                        Grid.SetRow(btn, row+1);
                        Grid.SetColumn(btn, col+1);
                        calendarGrid.Children.Add(btn);
                        dayList.Add(btn);
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
                    //b.Background = Brushes.Lavender;
                    b.BorderBrush = Brushes.MediumPurple;
                    b.BorderThickness = new Thickness(5,5,5,5);
                }
            }
        }

        private void CalendarClick(object sender, RoutedEventArgs e)
        {
            string day;
            Button button = sender as Button;
            day = button.Content.ToString();

            //int row = (int)button.GetValue(Grid.RowProperty);
            //int column = (int)button.GetValue(Grid.ColumnProperty);
            DayWindow dayWindow = new DayWindow(day, this);
            dayWindow.Closed += DayWindowClosed;
            dayWindow.Show();

        }

        public void DayWindowClosed(object sender, System.EventArgs e)
        {
            MessageBox.Show(string.Format("Zamykanie okna dnia"));
            updateDayInMonth();
        }

        public void updateDayInMonth()
        {
            //z appControlera wywołać metode zapytania do bazy danych.
            //odebrane dene przertworzyć tak by zupdatować buttony w kalendarzu miesiąca
            MessageBox.Show(string.Format("Zapytanie do bazy o wszystkie dni"));
        }
    }
}
