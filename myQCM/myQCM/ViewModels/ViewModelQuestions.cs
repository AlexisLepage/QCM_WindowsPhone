using MVVM.Interfaces;
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
    public class ViewModelQuestions : ViewModelList<Question>, IViewModelQuestions
    {
        #region Fields

        private Qcm _Qcm;

        #endregion

        #region Properties

        public Qcm Qcm
        {
            get { return _Qcm; }
            set { SetProperty(nameof(Qcm), ref _Qcm, value); }
        }

        #endregion


        #region Constructors

        public ViewModelQuestions()
        {

        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            ObservableCollection<Question> questions = new ObservableCollection<Question>();

            this.ItemsSource = questions;
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
