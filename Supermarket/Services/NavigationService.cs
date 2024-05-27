using System;
using Supermarket.Core;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.ViewModel;

namespace Supermarket.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : ViewModel;

        void NavigateTo<T>(User user) where T : ViewModel;
    }
    internal class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        private ViewModel _currentView;
        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }

        public void NavigateTo<TViewModel>(User user) where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            
            if (viewModel is HomeViewModel homeViewModel)
            {
                homeViewModel.User = user;
            }

            CurrentView = viewModel;
        }
    }
}