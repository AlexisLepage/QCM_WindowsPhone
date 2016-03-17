using MVVM.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class Answer : ObservableObject
    {
        #region Fields

        [JsonProperty(PropertyName = "id")]
        private int _IdServer;

        private string _Title;

        private bool _IsValid;

        private bool _IsSelected;

        private DateTime _CreatedAt;

        private DateTime _UpdatedAt;

        private Question _Question;

        #endregion

        #region Properties

        /// <summary>
        /// IdServer Answer.
        /// Getter and Setter for IdServer.
        /// </summary>
        public int IdServer
        {
            get { return _IdServer; }
            set { SetProperty(nameof(IdServer), ref _IdServer, value); }
        }

        /// <summary>
        /// Title Answer.
        /// Getter and Setter for Title.
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { SetProperty(nameof(Title), ref _Title, value); }
        }

        /// <summary>
        /// IsValid Answer.
        /// Getter and Setter for IsValid.
        /// </summary>
        public bool IsValid
        {
            get { return _IsValid; }
            set { SetProperty(nameof(IsValid), ref _IsValid, value); }
        }

        /// <summary>
        /// IsSelected Answer.
        /// Getter and Setter for IsSelected.
        /// </summary>
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(nameof(IsSelected), ref _IsSelected, value); }
        }

        /// <summary>
        /// CreatedAt Answer.
        /// Getter and Setter for CreatedAt.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { SetProperty(nameof(CreatedAt), ref _CreatedAt, value); }
        }

        /// <summary>
        /// UpdatedAt Answer.
        /// Getter and Setter for UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { SetProperty(nameof(UpdatedAt), ref _UpdatedAt, value); }
        }

        /// <summary>
        /// Question Answer.
        /// Getter and Setter for Question.
        /// </summary>
        public Question Question
        {
            get { return _Question; }
            set { SetProperty(nameof(Question), ref _Question, value); }
        }

        #endregion

        #region Constructors

        public Answer(int id_server, string title, bool is_valid, bool is_selected, DateTime created_at, DateTime updated_at, Question question)
        {
            IdServer = id_server;
            Title = title;
            IsValid = is_valid;
            IsSelected = is_selected;
            CreatedAt = created_at;
            UpdatedAt = updated_at;
            Question = question;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Title;
        }

        #endregion
    }
}
