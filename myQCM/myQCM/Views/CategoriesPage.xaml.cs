using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace myQCM.Views
{
    public partial class CategoriesPage : PhoneApplicationPage
    {
        public CategoriesPage()
        {
#if DEBUG
            this.DataContext = new ViewModels.ViewModelCategories();
#else

#endif
            InitializeComponent();
        }
    }
}