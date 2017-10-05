using System;
using BDSA2015.Lecture11.Universal.Models;
using BDSA2015.Lecture11.Universal.ViewModels;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BDSA2015.Lecture11.Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly DucksViewModel _viewModel;

        public MainPage()
        {
            this.InitializeComponent();

            _viewModel = new DucksViewModel();
            DataContext = _viewModel;
        }

        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var duck = (sender as ListView).SelectedItem as Duck;

            var message = $"You have selected duck no. {duck.Id} with name {duck.Name}";

            var dialog = new MessageDialog(message);

            await dialog.ShowAsync();
        }
    }
}
