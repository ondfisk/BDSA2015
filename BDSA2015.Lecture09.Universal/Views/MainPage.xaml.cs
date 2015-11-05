using System;
using BDSA2015.Lecture09.Universal.Models;
using BDSA2015.Lecture09.Universal.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BDSA2015.Lecture09.Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly CustomersViewModel _viewModel;

        public MainPage()
        {
            _viewModel = new CustomersViewModel();
            _viewModel.Initialize();
            
            DataContext = _viewModel;

            Add = new RelayCommand(c => Frame.Navigate(typeof(AddPage)));
            Edit = new RelayCommand(c =>
            {
                var customer = customerGrid.SelectedItem as Customer;
                Frame.Navigate(typeof(EditPage), customer);
            }, c => customerGrid.SelectedIndex != -1);
            Delete = new RelayCommand(async c => {
                var customer = customerGrid.SelectedItem as Customer;
                if (await Confirm($"Are you sure you want to delete the customer{Environment.NewLine}\"{customer.CompanyName}\"?"))
                {
                    await _viewModel.Delete(customer);
                }
            }, c => customerGrid.SelectedIndex != -1);

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _viewModel.SelectedCustomer = e.Parameter as Customer;
        }

        public ICommand Add { get; private set; }
        public RelayCommand Edit { get; private set; }
        public RelayCommand Delete { get; private set; }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedCustomer = customerGrid.SelectedItem as Customer;
            
            Edit.OnCanExecuteChanged(sender);
            Delete.OnCanExecuteChanged(sender);
        }

        private async Task<bool> Confirm(string message)
        {
            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("Yes", null, true));
            dialog.Commands.Add(new UICommand("No", null, false));
            var op = await dialog.ShowAsync();

            return (bool)op.Id;
        }
    }
}
