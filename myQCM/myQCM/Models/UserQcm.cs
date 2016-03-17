using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class UserQcm : ObservableObject
    {

        #region Fields

        private int _IdServer;

        private bool _IsDone;

        private User _User;

        private Qcm _Qcm;

        #endregion

        #region Properties

        /// <summary>
        /// IdServer UserQcm.
        /// Getter and Setter for IdServer.
        /// </summary>
        public int IdServer
        {
            get { return _IdServer; }
            set { SetProperty(nameof(IdServer), ref _IdServer, value); }
        }

        /// <summary>
        /// IsDone UserQcm.
        /// Getter and Setter for IsDone.
        /// </summary>
        public bool IsDone
        {
            get { return _IsDone; }
            set { SetProperty(nameof(IsDone), ref _IsDone, value); }
        }

        /// <summary>
        /// Qcm UserQcm.
        /// Getter and Setter for Qcm.
        /// </summary>
        public Qcm Qcm
        {
            get { return _Qcm; }
            set { SetProperty(nameof(Qcm), ref _Qcm, value); }
        }

        /// <summary>
        /// User UserQcm.
        /// Getter and Setter for User.
        /// </summary>
        public User User
        {
            get { return _User; }
            set { SetProperty(nameof(User), ref _User, value); }
        }


        #endregion

        #region Constructors

        public UserQcm(int id_server, bool is_done, User user, Qcm qcm)
        {
            IdServer = id_server;
            IsDone = is_done;
            User = user;
            Qcm = qcm;
        }

        #endregion

        #region Methods

        #endregion

    }
}
