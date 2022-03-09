﻿using EntityLayer;
using MaterialDesignThemes.Wpf;
using PlayGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlayGround.Commands
{
    public class RedirectViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel viewModel { get; set; }
        public RedirectViewCommand(MainViewModel MainviewModel)
        {
            this.viewModel = MainviewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "UserDashboard")
            {
                viewModel.SelectedViewModel = new UserDashboardViewModel();
            }
            else if (parameter.ToString() == "UserSettings")
            {
                UsersModel usersModel = new UsersModel();
                usersModel.UserId = 3;
                viewModel.SelectedViewModel = new UserSettingsViewModels(usersModel);
            }
            else if (parameter.ToString() == "UserTurfBooking")
            {
                BookingModel bookingModel = new BookingModel();
                bookingModel.UserID = 2;
                viewModel.SelectedViewModel = new UserTurfBookingViewModel(bookingModel);
            }
            else if (parameter.ToString() == "IsDarkMode")
            {
                 PaletteHelper paletteHelper = new PaletteHelper();
                 ITheme theme = paletteHelper.GetTheme();
                if (viewModel.IsDarknLightMode = theme.GetBaseTheme() == BaseTheme.Dark)
                {
                    viewModel.IsDarknLightMode = false;
                    theme.SetBaseTheme(Theme.Light);
                }
                else
                {
                    viewModel.IsDarknLightMode = true;
                    theme.SetBaseTheme(Theme.Dark);
                }
                paletteHelper.SetTheme(theme);
            } else if (parameter.ToString() == "SignOut")
            {
                viewModel.SelectedViewModel = new UserLogoutViewModel();
            }
            else if (parameter.ToString() == "AdminSettings")
            {
                viewModel.SelectedViewModel = new AdminTurfBookingHistoryViewModel();
            }
            else if (parameter.ToString() == "AdminAddNewTurf")
            {
                viewModel.SelectedViewModel = new UserNewTurfBookingViewModel();
            }

        }
    }
}
