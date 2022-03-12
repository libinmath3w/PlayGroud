﻿using BusinessLayer;
using EntityLayer;
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

namespace PlayGround.View
{
    /// <summary>
    /// Interaction logic for UserNewTurfBookingView.xaml
    /// </summary>
    public partial class UserNewTurfBookingView : UserControl
    {
        public int turfId;
        public UserNewTurfBookingView()
        {
            InitializeComponent();
            dpBookingDates.DisplayDateStart = DateTime.Now;
        }
        private void dpBookingDates_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            DateTime SelectedDate = (DateTime)dpBookingDates.SelectedDate;
            DateTime CurrentDate = DateTime.Now;
            string selected_date = SelectedDate.Date.ToString();
            string current_date = CurrentDate.Date.ToString();
            string current_date_hour = GetCurrentHour(CurrentDate);
 
            if(selected_date == current_date)
            {
                UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
                TimeSloteModel timeSlote = new TimeSloteModel();
                timeSlote.CurrentDateHour = current_date_hour;
                timeSlote.TurfID = turfId;
                timeSlote.BookingTime = SelectedDate;
                var query = userTurfBookingBusinessModel.GetCurrentTimeDetails(timeSlote);
                
                foreach(var t in query)
                {
                    cbStartTime.Items.Add(t.TimeSlots);
                }
                var result = userTurfBookingBusinessModel.GetCurrentEndTimeDetails(timeSlote);

                foreach (var t in result)
                {
                    cbEndTime.Items.Add(t.TimeSlots);
                }
            }
            else
            {
                UserTurfBookingBusinessModel userTurfBookingBusinessModel = new UserTurfBookingBusinessModel();
                TimeSloteModel timeSlote = new TimeSloteModel();
                timeSlote.TurfID = turfId;
                timeSlote.BookingTime = SelectedDate;
                var NonCurrentTime = userTurfBookingBusinessModel.GetNonCurrentTimeDetails(timeSlote);
                foreach (var t in NonCurrentTime)
                {
                    cbStartTime.Items.Add(t.TimeSlots);
                }
                var NonEndCurrentTime = userTurfBookingBusinessModel.GetNonCurrentEndTimeDetails(timeSlote);
                foreach (var t in NonEndCurrentTime)
                {
                    cbEndTime.Items.Add(t.TimeSlots);
                }
            }
        }
        public static String GetCurrentHour(DateTime value)
        {
            string hour = value.ToString("hh");
            string AmPm = value.ToString("tt");
            return hour + ":00 " + AmPm;
        }
        private void Row_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            turfId = (gdTurfdetails.SelectedItem as TurfModel).TurfID;
        }
    }
}
