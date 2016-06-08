using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MVVM.Service;

namespace myQCM.Views
{
    public partial class EndPage : PhoneApplicationPage
    {
        public EndPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/CategoriesPage.xaml", UriKind.Relative));
        }
    }
}