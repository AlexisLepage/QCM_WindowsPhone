using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class Category : ObservableObject
    {

        #region Fields

        private int _IdServer;
        private string _Name;
        private DateTime _CreatedAt;
        private DateTime _UpdatedAt;

        #endregion

        #region Properties

        /// <summary>
        /// IdServer Category.
        /// Getter and Setter for IdServer.
        /// </summary>
        public int IdServer
        {
            get { return _IdServer; }
            set { SetProperty(nameof(IdServer), ref _IdServer, value); }
        }

        /// <summary>
        /// Name Category.
        /// Getter and Setter for Name.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty(nameof(Name), ref _Name, value); }
        }

        /// <summary>
        /// CreatedAt Category.
        /// Getter and Setter for CreatedAt.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { SetProperty(nameof(_CreatedAt), ref _CreatedAt, value); }
        }

        /// <summary>
        /// UpdatedAt Category.
        /// Getter and Setter for UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { SetProperty(nameof(_UpdatedAt), ref _UpdatedAt, value); }
        }

        #endregion

        #region Constructors

        public Category(int id_server, string name, DateTime created_at, DateTime updated_at)
        {
            Name = name;
            IdServer = id_server;
            CreatedAt = created_at;
            UpdatedAt = updated_at;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion


    }
}
