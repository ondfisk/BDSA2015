using System.Windows;
using System.Windows.Controls;
using BDSA2015.Lecture08.AsyncUI.Models;
using System;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using BDSA2015.Lecture07.AsyncUI.ViewModels;

namespace BDSA2015.Lecture08.AsyncUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CurrencyViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new CurrencyViewModel();
            DataContext = _viewModel;
        }

        private async void Calculate_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.Calculate();
        }
    }
}
