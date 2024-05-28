
using Supermarket.Core;
using Supermarket.MVVM.Model;
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

        public RelayCommand NavigateProductCommand { get; set; }

        public RelayCommand NavigateDistributorCommand { get; set; }

        public RelayCommand NavigateCategoryCommand { get; set; }

        public RelayCommand NavigateStockCommand { get; set; }

        public RelayCommand NavigateReceiptCommand { get; set; }

        public RelayCommand NavigateAddReceiptCommand { get; set; }

        public RelayCommand NavigateProductSearchCommand { get; set; }

        public RelayCommand NavigateCategoryValueCommand { get; set; }

        public RelayCommand NavigateEarningsCommand { get; set; }

        public RelayCommand NavigateBigReceiptCommand { get; set; }

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();

                (NavigateUserCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateHomeCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateLoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateDistributorCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateCategoryCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateStockCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateReceiptCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateAddReceiptCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateProductSearchCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateCategoryValueCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateEarningsCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateBigReceiptCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;

            // Commands with CanExecute logic
            NavigateHomeCommand = new RelayCommand(
                o => Navigation.NavigateTo<HomeViewModel>(),
                o => CurrentUser != null);

            NavigateLoginCommand = new RelayCommand(
                o => Navigation.NavigateTo<LoginViewModel>(),
                o => CurrentUser == null); // Only allow navigation to Login when NOT logged in

            NavigateUserCommand = new RelayCommand(
                o => Navigation.NavigateTo<UserViewModel>(),
                o => CurrentUser != null);

            NavigateDistributorCommand = new RelayCommand(
                o => Navigation.NavigateTo<DistributorViewModel>(),
                o => CurrentUser != null);


            NavigateCategoryCommand = new RelayCommand(
                o => Navigation.NavigateTo<CategoryViewModel>(),
                o => CurrentUser != null);
            
            NavigateProductCommand = new RelayCommand(
                o => Navigation.NavigateTo<ProductViewModel>(),
                o => CurrentUser != null);
            /**
            NavigateStockCommand = new RelayCommand(
                o => Navigation.NavigateTo<StockViewModel>(),
                o => CurrentUser != null);

            NavigateReceiptCommand = new RelayCommand(
                o => Navigation.NavigateTo<ReceiptViewModel>(),
                o => CurrentUser != null);

            NavigateAddReceiptCommand = new RelayCommand(
                o => Navigation.NavigateTo<AddReceiptViewModel>(),
                o => CurrentUser != null);

            NavigateProductSearchCommand = new RelayCommand(
                o => Navigation.NavigateTo<ProductSearchViewModel>(),
                o => CurrentUser != null);

            NavigateCategoryValueCommand = new RelayCommand(
                o => Navigation.NavigateTo<CategoryValueViewModel>(),
                o => CurrentUser != null);

            NavigateEarningsCommand = new RelayCommand(
                o => Navigation.NavigateTo<EarningsViewModel>(),
                o => CurrentUser != null);

            NavigateBigReceiptCommand = new RelayCommand(
                o => Navigation.NavigateTo<BigReceiptViewModel>(),
                o => CurrentUser != null);
            **/

            Navigation.NavigateTo<LoginViewModel>();
        }
    }
}