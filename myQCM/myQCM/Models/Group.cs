using MVVM.Data;
using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "id")]
        private int _IdServer;

        private string _Name;

        private DateTime _CreatedAt;

        private DateTime _UpdatedAt;

        #endregion

        #region Properties

        /// <summary>
        /// IdServer Group.
        /// Getter and Setter for IdServer.
        /// </summary>
        public int IdServer
        {
            get { return _IdServer; }
            set { _IdServer = value; }
        }

        /// <summary>
        /// Name Group.
        /// Getter and Setter for Name.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// CreatedAt Group.
        /// Getter and Setter for CreatedAt.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { _CreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt Group.
        /// Getter and Setter for UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { _UpdatedAt = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor Group
        /// </summary>
        /// <param name="id_server"></param>
        /// <param name="name"></param>
        /// <param name="created_at"></param>
        /// <param name="updated_at"></param>
        public Group(int id_server, string name, DateTime created_at, DateTime updated_at)
        {
            Name = name;
            IdServer = id_server;
            CreatedAt = created_at;
            UpdatedAt = updated_at;
        }

        #endregion

    }
}
