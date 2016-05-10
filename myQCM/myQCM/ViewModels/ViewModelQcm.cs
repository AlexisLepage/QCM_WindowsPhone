﻿using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.ViewModels
{
    public class ViewModelQcm : ViewModelItem<Qcm>, IViewModelQcm
    {
        #region Fields

        private ViewModelQuestions _ViewModelQuestions;

        #endregion

        #region Properties

        public IViewModelQuestions ViewModelQuestions => _ViewModelQuestions;

        #endregion

        #region Constructors

        public ViewModelQcm()
        {
            _ViewModelQuestions = new ViewModelQuestions();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            _ViewModelQuestions.Qcm = Item;
            _ViewModelQuestions.LoadData();
        }

        #endregion
    }
}