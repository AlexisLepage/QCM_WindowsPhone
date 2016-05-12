using MVVM;
using MVVM.Service;
using MVVM.ViewModels;
using myQCM.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Interfaces;
using myQCM.Models;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace myQCM.ViewModels
{
    public class ViewModelConnexion : ViewModelItem<User>, IViewModelConnexion
    {
        #region Fields

        private DelegateCommand _ConnectCommand;

        private User _UserCurrent;

        #endregion

        #region Properties

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
        public User UserCurrent
        {
            get { return _UserCurrent; }
            set { _UserCurrent = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of ViewModelConnexion
        /// </summary>
        public ViewModelConnexion()
        {
            LoadData();

            _ConnectCommand = new DelegateCommand(ExecuteConnectCommand, CanExecuteConnectCommand);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load data user
        /// </summary>
        public override void LoadData()
        {
            base.LoadData();

            Item = new User();
            Item.PropertyChanged += Item_PropertyChanged;
        }

        /// <summary>
        /// On navigated from
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedFrom(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);

            if (viewModel is IViewModelCategories)
            {
                ((IViewModelCategories)viewModel).User = UserCurrent;
                ((IViewModelCategories)viewModel).LoadData();
                Item = null;
            }
        }

        /// <summary>
        /// Item property changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Username":
                case "Password":
                    ConnectCommand.OnCanExecuteChanged();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If can execute command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected bool CanExecuteConnectCommand(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Item.Username) && !string.IsNullOrWhiteSpace(Item.Password);
        }

        /// <summary>
        /// Execute connect command
        /// </summary>
        /// <param name="parameter"></param>
        protected void ExecuteConnectCommand(object parameter)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri("http://192.168.218.11///Qcm/web/app_dev.php/api/users/" + Item.Username));
        }

        /// <summary>
        /// Load and convert json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;

           UserCurrent = JsonConvert.DeserializeObject<User>(jsonstream);

            //Redirection vers page catégorie
            if (UserCurrent != null)
            {
                ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/CategoriesPage.xaml", UriKind.Relative));
            }

        }

        #endregion

    }
}
