using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class User
    {
        #region Fields

        private string _Username;

        private string _Name;

        private string _Firstname;

        private string _Email;

        private string _Password;

        private DateTime _CreatedAt;

        private DateTime _UpdatedAt;

        #endregion

        #region Properties

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Firstname
        {
            get { return _Firstname; }
            set { _Firstname = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { _CreatedAt = value; }
        }

        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { _UpdatedAt = value; }
        }
        #endregion

        #region Constructors

        public User()
        {

        }

        #endregion
    }
}
