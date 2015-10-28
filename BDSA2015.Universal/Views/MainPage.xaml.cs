using BDSA2015.Universal.Model;
using BDSA2015.Universal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BDSA2015.Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public AlbumViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = new AlbumViewModel();
            ViewModel.Initialize();

            DataContext = ViewModel;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectAlbum((Album) List.SelectedItem);
        }
    }
}
