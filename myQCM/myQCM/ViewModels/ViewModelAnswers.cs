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
    public class ViewModelAnswers : ViewModelList<Answer>, IViewModelAnswers
    {
        #region Fields

        private Question _Question;

        #endregion

        #region Properties

        public Question Question
        {
            get { return _Question; }
            set { _Question = value; }
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            ObservableCollection<Answer> answers = new ObservableCollection<Answer>();

            this.ItemsSource = answers;
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

            if (viewModel is IViewModelAnswer)
            {
                ((IViewModelAnswer)viewModel).Item = this.SelectedItem;
                ((IViewModelAnswer)viewModel).LoadData();
                SelectedItem = null;
            }
        }


        #endregion

        #endregion
    }
}
