using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class User: ObservableObject
    {
        #region Fields

        private int _Id;

        private string _Username;

        private string _Name;

        private string _Firstname;

        private string _Email;

        private string _Password;

        private DateTime _CreatedAt;

        private DateTime _UpdatedAt;

        #endregion

        #region Properties

        public int Id
        {
            get { return _Id; }
            set { SetProperty(nameof(Id), ref _Id, value); }
        }

        public string Username
        {
            get { return _Username; }
            set { SetProperty(nameof(Username), ref _Username, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { SetProperty(nameof(Name), ref _Name, value); }
        }

        public string Firstname
        {
            get { return _Firstname; }
            set { SetProperty(nameof(Firstname), ref _Firstname, value); }
        }

        public string Email
        {
            get { return _Email; }
            set { SetProperty(nameof(Email), ref _Email, value); }
        }

        public string Password
        {
            get { return _Password; }
            set { SetProperty(nameof(Password), ref _Password, value); }
        }

        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { SetProperty(nameof(CreatedAt), ref _CreatedAt, value); }
        }

        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { SetProperty(nameof(UpdatedAt), ref _UpdatedAt, value); }
        }
        #endregion

        #region Constructors

        public User()
        {

        }

        #endregion
    }
}
