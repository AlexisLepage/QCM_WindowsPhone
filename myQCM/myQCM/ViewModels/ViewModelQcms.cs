﻿using MVVM.Interfaces;
using MVVM.Service;
using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.ViewModels
{
    public class ViewModelQcms : ViewModelList<Qcm>, IViewModelQcms
    {
        #region Fields

        private Category _Category;

        #endregion

        #region Properties

        public Category Category
        {
            get { return _Category; }
            set { SetProperty(nameof(Category), ref _Category, value); }
        }

        #endregion

        #region Constructors

        public ViewModelQcms()
        {
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

            ObservableCollection<Qcm> qcms = new ObservableCollection<Qcm>();

            foreach (Qcm qcm in this.Category.Qcms)
            {
                qcms.Add(qcm);
            }

            this.ItemsSource = qcms;
        }

        protected override void InitializePropertyTrackers()
        {
            base.InitializePropertyTrackers();

            this.AddPropertyTrackerAction(nameof(SelectedItem), (sender, args) =>
            {
                if (SelectedItem != null)
                {
                    ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/QuestionsPage.xaml", UriKind.Relative));
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

            if (viewModel is IViewModelQuestion)
            {
                ((IViewModelQuestion)viewModel).Item = this.SelectedItem;
                ((IViewModelQuestion)viewModel).LoadData();
                SelectedItem = null;
            }
        }


        #endregion

        #endregion
    }
}
