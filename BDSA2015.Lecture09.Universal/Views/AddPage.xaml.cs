using BDSA2015.Lecture09.Universal.ViewModels;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BDSA2015.Lecture09.Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        private readonly CustomerViewModel _viewModel;

        public AddPage()
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) => Frame.Navigate(typeof(MainPage));

            _viewModel = new CustomerViewModel();
            DataContext = _viewModel;

            this.InitializeComponent();
        }
    }
}
