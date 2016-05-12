﻿using MVVM.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.Models
{
    public class Question : ObservableObject
    {

        #region Fields

        [JsonProperty(PropertyName = "id")]
        private int _IdServer;

        private string _Title;

        private int _Value;

        private DateTime _CreatedAt;

        private DateTime _UpdatedAt;

        private Qcm _Qcm;

        private List<Answer> answers;

        #endregion

        #region Properties

        /// <summary>
        /// IdServer Question.
        /// Getter and Setter for IdServer.
        /// </summary>
        public int IdServer
        {
            get { return _IdServer; }
            set { SetProperty(nameof(IdServer), ref _IdServer, value); }
        }

        /// <summary>
        /// Title Question.
        /// Getter and Setter for Title.
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { SetProperty(nameof(Title), ref _Title, value); }
        }

        /// <summary>
        /// Value Question.
        /// Getter and Setter for Value.
        /// </summary>
        public int Value
        {
            get { return _Value; }
            set { SetProperty(nameof(Value), ref _Value, value); }
        }

        /// <summary>
        /// CreatedAt Question.
        /// Getter and Setter for CreatedAt.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { SetProperty(nameof(CreatedAt), ref _CreatedAt, value); }
        }

        /// <summary>
        /// UpdatedAt Question.
        /// Getter and Setter for UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { SetProperty(nameof(UpdatedAt), ref _UpdatedAt, value); }
        }

        /// <summary>
        /// Qcm Question.
        /// Getter and Setter for Qcm.
        /// </summary>
        public Qcm Qcm
        {
            get { return _Qcm; }
            set { SetProperty(nameof(Qcm), ref _Qcm, value); }
        }

        /// <summary>
        /// Answers Question
        /// Getter and Setter for Answers
        /// </summary>
        public List<Answer> Answers
        {
            get { return answers; }
            set { answers = value; }
        }


        #endregion

        #region Constructors

        /// <summary>
        /// Constructor Question
        /// </summary>
        /// <param name="id_server"></param>
        /// <param name="title"></param>
        /// <param name="value"></param>
        /// <param name="created_at"></param>
        /// <param name="updated_at"></param>
        /// <param name="qcm"></param>
        public Question(int id_server, string title, int value, DateTime created_at, DateTime updated_at, Qcm qcm)
        {
            IdServer = id_server;
            Title = title;
            Value = value;
            CreatedAt = created_at;
            UpdatedAt = updated_at;
            Qcm = qcm;
            Answers = new List<Answer>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method Tostring for return Title Question.
        /// </summary>
        /// <returns>Title</returns>
        public override string ToString()
        {
            return Title;
        }

        #endregion
    }
}
