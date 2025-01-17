﻿using BusinessLayer;
using EntityLayer;
using PlayGround.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayGround.ViewModel
{
    public class AdminAddNewTurfViewModel : BaseViewModel
    {
        AdminAddNewTurfBusinessModel adminAddNewTurfBusinessModel = new AdminAddNewTurfBusinessModel();

        private string _turfID;
        private string _turfname;
        private string _turfcity;
        private string _turfstate;
        private string _turfzip;
        private string _turfprice;
        private int _searchTerm;
        public int SearchTerm { get => _searchTerm; set { _searchTerm = value; onPropertyChanged("Search box"); } }
        private TimeSloteModel _timeSlotStartTime;
        public TimeSloteModel TimeSlotStartTime { get => _timeSlotStartTime; set { _timeSlotStartTime = value; onPropertyChanged("Starting Time"); } }
        
        private TimeSloteModel _timeSlotEndTime;
        public TimeSloteModel TimeSlotEndTime { get => _timeSlotEndTime; set { _timeSlotEndTime = value; onPropertyChanged("End Time"); } }

        private ObservableCollection<TimeSloteModel> _turfStartingTime;
        public ObservableCollection<TimeSloteModel> TurfStartingTime { get { return _turfStartingTime; } 
            set { if (_turfStartingTime == value) return; _turfStartingTime = value; onPropertyChanged(nameof(TurfStartingTime)); } }
        private ObservableCollection<TimeSloteModel> _startingTime;
        public ObservableCollection<TimeSloteModel> StartingTime { get { return _startingTime; } set {_startingTime = value; onPropertyChanged("StartingTime");}}

        private ObservableCollection<TimeSloteModel> _turfEndingTime;
        public ObservableCollection<TimeSloteModel> TurfEndingTime { get { return _turfEndingTime; }
            set { if (_turfEndingTime == value) return; _turfEndingTime = value; onPropertyChanged(nameof(TurfEndingTime)); } }

        private TurfCategoryModel _turfCategoryValue;
        public TurfCategoryModel TurfCategoryValue { get => _turfCategoryValue; set { _turfCategoryValue = value; onPropertyChanged("Turf Category"); } }

        private ObservableCollection<TurfCategoryModel> _turfCategoryType;
        public ObservableCollection<TurfCategoryModel> TurfCategoryType { get { return _turfCategoryType; }
            set { if (_turfCategoryType == value) return; _turfCategoryType = value; onPropertyChanged(nameof(TurfCategoryType)); } }
        public ICommand AddNewTurfCommands { get; set; }
        public string TurfID { get => _turfID; set { _turfID = value; onPropertyChanged("TurfID"); } }
        public string TurfName { get => _turfname; set { _turfname = value; onPropertyChanged("turf name"); } }
        public string TurfCity { get => _turfcity; set { _turfcity = value; onPropertyChanged("turf city"); } }
        public string TurfState { get => _turfstate; set { _turfstate = value; onPropertyChanged("turf state"); } }
        public string TurfZip { get => _turfzip; set { _turfzip = value; onPropertyChanged("turf zip"); } }
        public string TurfPrice { get => _turfprice; set { _turfprice = value; onPropertyChanged("turf price"); } }

        public AdminAddNewTurfViewModel()
        {
            TurfStartingTime = new ObservableCollection<TimeSloteModel>(); 
            TurfEndingTime = new ObservableCollection<TimeSloteModel>();
            TurfCategoryType = new ObservableCollection<TurfCategoryModel>();
            StartingTime = new ObservableCollection<TimeSloteModel>();
            AddNewTurfCommands = new AddNewTurfCommand(this);
            GetAllComboValues();
        }

        public void GetAllComboValues()
        {
            var startTimeCombo = adminAddNewTurfBusinessModel.GetStartingTime();
            foreach (var item in startTimeCombo)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeID = item.TimeID;
                timeModels.TimeSlots = item.TimeSlots;
                TurfStartingTime.Add(timeModels);
                StartingTime.Add(timeModels);

            }
            var EndTimeCombo = adminAddNewTurfBusinessModel.GetEndingTime();
            foreach (var item in EndTimeCombo)
            {
                TimeSloteModel timeModels = new TimeSloteModel();
                timeModels.TimeID = item.TimeID;
                timeModels.TimeSlots = item.TimeSlots;
                TurfEndingTime.Add(timeModels);
            }
            var GetTurfCombo = adminAddNewTurfBusinessModel.GetTurfType();
            foreach (var item in GetTurfCombo)
            {
                TurfCategoryModel turfModels = new TurfCategoryModel();
                turfModels.TurfType = item.TurfType;
                turfModels.TurfID = item.TurfID;
                TurfCategoryType.Add(turfModels);
            }
        }
        public void GetEditTurfValues(TurfModel turfModels)
        {
            AdminAddNewTurfBusinessModel adminAddNewTurfBusinessModels = new AdminAddNewTurfBusinessModel();
            var query = adminAddNewTurfBusinessModels.GetTurfDetails(turfModels);
            MessageBox.Show("Please Wait......");
            foreach (var item in query)
            {
                TurfName = item.TurfName;
                TurfCity = item.TurfCity;
            }
        }
    }
}
