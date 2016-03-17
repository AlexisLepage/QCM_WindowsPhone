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

namespace myQCM.ViewModels
{
    public class ViewModelConnexion : ViewModelItem<User>, IViewModelConnexion
    {
        #region Fields

        private DelegateCommand _ConnectCommand;

        private User _UserCurrent;

        #endregion

        #region Properties

        public DelegateCommand ConnectCommand
        {
            get { return _ConnectCommand; }
            set { _ConnectCommand = value; }
        }

        public User UserCurrent
        {
            get { return _UserCurrent; }
            set { _UserCurrent = value; }
        }

        #endregion

        #region Constructors

        public ViewModelConnexion()
        {
            LoadData();

            _ConnectCommand = new DelegateCommand(ExecuteConnectCommand, CanExecuteConnectCommand);

            UserCurrent = new User();
            DateTime date = DateTime.Now;
            UserCurrent.Username = "test";
            UserCurrent.Name = "test";
            UserCurrent.Firstname = "test";
            UserCurrent.Password = "passw0rd";
            UserCurrent.Email = "test@hotmail.fr";
            UserCurrent.CreatedAt = date;
            UserCurrent.UpdatedAt = date;
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            base.LoadData();

            Item = new User();
            Item.PropertyChanged += Item_PropertyChanged;
        }

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

        protected bool CanExecuteConnectCommand(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Item.Username) && !string.IsNullOrWhiteSpace(Item.Password);
        }

        protected void ExecuteConnectCommand(object parameter)
        {
            if (Item.Username.Equals(UserCurrent.Username) && Item.Password.Equals(UserCurrent.Password))
            {
                ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/CategoriesPage.xaml", UriKind.Relative));
            }
        }

        #endregion

    }
}
