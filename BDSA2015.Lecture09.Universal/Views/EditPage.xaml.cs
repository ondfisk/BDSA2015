﻿using BDSA2015.Lecture09.Universal.Models;
using BDSA2015.Lecture09.Universal.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BDSA2015.Lecture09.Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        private readonly CustomerViewModel _viewModel;

        public EditPage()
        {
            _viewModel = new CustomerViewModel();
            DataContext = _viewModel;

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var customer = e.Parameter as Customer;
            _viewModel.Initialize(customer);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, args) => Frame.Navigate(typeof(MainPage), customer);
        }
    }
}
