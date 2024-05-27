﻿using Microsoft.VisualBasic.ApplicationServices;
using Supermarket.Core;
using Supermarket.Services;

namespace Supermarket.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateLoginCommand { get; set; }

        public RelayCommand NavigateUserCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateLoginCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>(); }, o => true);
            NavigateUserCommand = new RelayCommand(o => { Navigation.NavigateTo<UserViewModel>(); }, o => true);

            Navigation.NavigateTo<LoginViewModel>();
        }
    }
}