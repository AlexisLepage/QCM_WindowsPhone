using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class Group: ObservableObject
    {
        #region Fields

        private int _IdServer;

        private string _Name;

        private DateTime _CreatedAt;

        private DateTime _UpdatedAt;

    #endregion

        #region Properties

        public int IdServer
        {
            get { return _IdServer; }
            set { _IdServer = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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

        public Group()
        {

        }

        #endregion

    }
}
