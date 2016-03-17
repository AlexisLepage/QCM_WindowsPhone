using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MVVM.Interfaces;
using MVVM.Service;
using System.Collections.ObjectModel;

namespace myQCM.ViewModels
{
   public class ViewModelCategories : ViewModelList<Category>, IViewModelCategories
   {
        #region Methods

        public override void LoadData()
        {
            DateTime date = new DateTime();
            Category catAndroid = new Category(3, "Android", date, date);
            Qcm qcm = new Qcm(1, "Les fragments", date, date, 30, date, date, catAndroid);
            catAndroid.Qcms.Add(qcm);
            this.ItemsSource.Add(catAndroid);
            //this.ItemsSource.Add(new Category(2, "IOS", date, date));
            //this.ItemsSource.Add(catAndroid);
            //this.ItemsSource.Add(new Category(4, "Sécurité", date, date));
            //this.ItemsSource.Add(new Category(5, "UML", date, date));
            //this.ItemsSource.Add(new Category(6, "Veille technologique", date, date));
        }

        protected override void InitializePropertyTrackers()
        {
            base.InitializePropertyTrackers();

            this.AddPropertyTrackerAction(nameof(SelectedItem), (sender, args) =>
            { 
                if (SelectedItem != null)
                {
                    ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/QcmsPage.xaml", UriKind.Relative));
                }
            });
        }

        #region Navigation

        public override void OnNavigatedTo(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);

            //Chargement des données
            LoadData();
        }

        public override void OnNavigatedFrom(IViewModel viewModel)
        {
            base.OnNavigatedFrom(viewModel);

            if (viewModel is IViewModelCategory)
            {
                ((IViewModelCategory)viewModel).Item = this.SelectedItem;
                ((IViewModelCategory)viewModel).LoadData();
                SelectedItem = null;
            }
        }

        
        #endregion

        #endregion
    }
}
