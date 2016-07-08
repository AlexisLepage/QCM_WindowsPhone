using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using System.Net;
using MVVM.Service;
using Newtonsoft.Json;
using MVVM.Interfaces;

namespace myQCM.ViewModels
{
    public class ViewModelEnd : ViewModelItem<User>, IViewModelEnd
    {

        #region Fields

        private DelegateCommand _ConnectCommand;

        private User _User;

        #endregion

        #region Properties

        /// <summary>
        /// On navigated from
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedFrom(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);

            if (viewModel is IViewModelCategories)
            {
                ((IViewModelCategories)viewModel).User = User;
                ((IViewModelCategories)viewModel).LoadData();
                Item = null;
            }
        }

        /// <summary>
        /// Getter and Setter ConnectCommand
        /// </summary>
        public DelegateCommand ConnectCommand
        {
            get { return _ConnectCommand; }
            set { _ConnectCommand = value; }
        }

        /// <summary>
        /// Getter and Setter UserCurrent
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
        public ViewModelEnd()
        {
            LoadData();

            _ConnectCommand = new DelegateCommand(ExecuteConnectCommand, CanExecuteConnectCommand);
        }

        #endregion

        /// <summary>
        /// If can execute command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected bool CanExecuteConnectCommand(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute connect command
        /// </summary>
        /// <param name="parameter"></param>
        protected void ExecuteConnectCommand(object parameter)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var username = localSettings.Values["username"];

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri("http://172.20.10.4/Qcm/web/app_dev.php/api/users/" + username));
        }

        /// <summary>
        /// Load and convert json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;

            User = JsonConvert.DeserializeObject<User>(jsonstream);

            //Redirection vers page catégorie
            if (User != null)
            {
                ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/CategoriesPage.xaml", UriKind.Relative));
            }

        }
    }
}
