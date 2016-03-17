using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using myQCM.Resources;
using myQCM.Models;
using MVVM.Views;

namespace myQCM
{
    public partial class MainPage : MVVMPhonePage
    {
        // Constructeur
        public MainPage()
        {

            DateTime date = DateTime.Now;
            User u = new User("Alepage","alexislepage@hotmail.fr", "Lepage", "Alexis", date, date, "admin");
           
            this.ViewModel = new ViewModels.ViewModelConnexion();

            InitializeComponent();
        }
    }
}