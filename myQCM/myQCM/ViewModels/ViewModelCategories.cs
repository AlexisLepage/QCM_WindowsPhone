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
using MVVM;

namespace myQCM.ViewModels
{
    public class ViewModelCategories : ViewModelList<Category>, IViewModelCategories
    {
        #region Fields

        private DelegateCommand _DeconnectCommand;

        private User _User;

        #endregion

        #region Properties

        /// <summary>
        /// Getter and Setter ConnectCommand
        /// </summary>
        public DelegateCommand DeconnectCommand
        {
            get { return _DeconnectCommand; }
            set { _DeconnectCommand = value; }
        }

        /// <summary>
        /// Getter and setter User field.
        /// </summary>
        public User User
        {
            get { return _User; }
            set { _User = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of ViewModelConnexion
        /// </summary>
        public ViewModelCategories()
        {
            _DeconnectCommand = new DelegateCommand(ExecuteDeconnectCommand, CanExecuteDeconnectCommand);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load data categories in ItemSource.
        /// </summary>
        public override void LoadData()
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>();

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["id"] = User.IdServer;
            localSettings.Values["username"] = User.Username;

            bool exist = false;
            foreach (UserQcm userQcm in this.User.UserQcms)
            {
                Category category = userQcm.Qcm.Category;
                exist = false;
                foreach (Category c in categories)
                {
                    if (c.IdServer.Equals(category.IdServer))
                    {
                        c.Qcms.Add(userQcm.Qcm);
                        exist = true;
                    }
                }
                if (!exist)
                {
                    category.Qcms.Add(userQcm.Qcm);
                    categories.Add(category);
                }
            }
            this.ItemsSource = categories;
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

        #endregion

        #region Navigation

        /// <summary>
        /// On navigated to ViewModel.
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedTo(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);
        }

        /// <summary>
        /// On navigated from ViewModel.
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedFrom(IViewModel viewModel)
        {
            base.OnNavigatedFrom(viewModel);

            if (viewModel is IViewModelQcms)
            {
                ((IViewModelQcms)viewModel).Category = this.SelectedItem;
                ((IViewModelQcms)viewModel).LoadData();
                SelectedItem = null;
            }
        }

        /// <summary>
        /// If can execute command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected bool CanExecuteDeconnectCommand(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute connect command
        /// </summary>
        /// <param name="parameter"></param>
        protected void ExecuteDeconnectCommand(object parameter)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("id");
            ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/ConnexionPage.xaml", UriKind.Relative));
        }

        #endregion

    }
}
