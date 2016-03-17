using Newtonsoft.Json;
﻿using MVVM.Data;
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

        [JsonProperty(PropertyName = "id")]
        private int _IdServer;

        private string _Username;

        private string _Name;

        private string _Firstname;

        private string _Email;

        private string _Password;
        
        [JsonProperty(PropertyName = "created_at")]
        private DateTime _CreatedAt;

        [JsonProperty(PropertyName = "update_at")]
        private DateTime _UpdatedAt;
        
        [JsonProperty(PropertyName = "user_qcms")]
        private List<UserQcm> _UserQcms;

        #endregion

        #region Properties

        /// <summary>
        /// IdServer User.
        /// Getter and Setter for IdServer.
        /// </summary>
        public int IdServer
        {
            get { return _IdServer; }
            set { SetProperty(nameof(IdServer), ref _IdServer, value); }
        }

        /// <summary>
        /// Username User.
        /// Getter and Setter for Username.
        /// </summary>
        public string Username
        {
            get { return _Username; }
            set { SetProperty(nameof(Username), ref _Username, value); }
        }

        /// <summary>
        /// Name User.
        /// Getter and Setter for Name.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty(nameof(Name), ref _Name, value); }
        }

        /// <summary>
        /// Firstname User.
        /// Getter and Setter for Firstname.
        /// </summary>
        public string Firstname
        {
            get { return _Firstname; }
            set { SetProperty(nameof(Firstname), ref _Firstname, value); }
        }

        /// <summary>
        /// Email User.
        /// Getter and Setter for Email.
        /// </summary>
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

        /// <summary>
        /// CreatedAt User.
        /// Getter and Setter for CreatedAt.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { SetProperty(nameof(CreatedAt), ref _CreatedAt, value); }
        }

        /// <summary>
        /// UpdatedAt User.
        /// Getter and Setter for UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { SetProperty(nameof(UpdatedAt), ref _UpdatedAt, value); }
        }

        /// <summary>
        /// UpdatedAt User.
        /// Getter and Setter for UpdatedAt.
        /// </summary>
        public List<UserQcm> UserQcms
        {
            get { return _UserQcms; }
            set { SetProperty(nameof(UserQcms), ref _UserQcms, value); }
        }
        #endregion

        #region Constructors

        public User(string username, string email, string name, string firstname, DateTime created_at, DateTime updated_at, string password, List<UserQcm> user_qcms)
        {
            Username = username;
            Email = email;
            Password = password;
            Name = name;
            Firstname = firstname;
            CreatedAt = created_at;
            UpdatedAt = updated_at;
            UserQcms = user_qcms;
        }

        public User()
        {

        }

        #endregion
    }
}
