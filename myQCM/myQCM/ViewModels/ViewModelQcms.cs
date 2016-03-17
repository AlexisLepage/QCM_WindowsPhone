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
    public class ViewModelQcms : ViewModelList<Qcm>, IViewModelQcms
    {
        #region Constructors

        public ViewModelQcms()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            //DateTime date = new DateTime();
            //Category category1 = new Category(1, "Windows Phone", date, date);
            //Category category2 = new Category(2, "Android", date, date);
            //this.ItemsSource.Add(new Qcm(1, "Le Binding", date, date, 30, date, date, category1));
            //this.ItemsSource.Add(new Qcm(2, "Le XAML", date, date, 60, date, date, category1));
            //this.ItemsSource.Add(new Qcm(3, "La navigation au sein des views", date, date, 20, date, date, category2));
            //this.ItemsSource.Add(new Qcm(4, "Test ", date, date, 45, date, date, category2));
        }

        #endregion
    }
}
