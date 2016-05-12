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

        /// <summary>
        /// Getter and Setter Question field
        /// </summary>
        public Question Question
        {
            get { return _Question; }
            set { _Question = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load data answers in ItemSource.
        /// </summary>
        public override void LoadData()
        {
            ObservableCollection<Answer> answers = new ObservableCollection<Answer>();

            this.ItemsSource = answers;
        }

        /// <summary>
        /// Tracker property.
        /// </summary>
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

        /// <summary>
        /// On navigated to ViewModel.
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedTo(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);
            LoadData();
        }

        /// <summary>
        /// On navigated from ViewModel.
        /// </summary>
        /// <param name="viewModel"></param>
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
