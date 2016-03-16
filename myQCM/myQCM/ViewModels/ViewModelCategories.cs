using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.ViewModels
{
    class ViewModelCategories : ViewModelList<Category>, IViewModelCategories
    {

        #region Constructors

        public ViewModelCategories()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            DateTime date = new DateTime();
            this.ItemsSource.Add(new Category(1, "Windows Phone", date, date));
            this.ItemsSource.Add(new Category(2, "IOS", date, date));
            this.ItemsSource.Add(new Category(3, "Android", date, date));
            this.ItemsSource.Add(new Category(4, "Sécurité", date, date));
            this.ItemsSource.Add(new Category(5, "UML", date, date));
            this.ItemsSource.Add(new Category(6, "Veille technologique", date, date));
        }

        #endregion
    }
}
