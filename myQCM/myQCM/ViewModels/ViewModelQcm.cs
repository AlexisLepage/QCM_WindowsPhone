using MVVM.ViewModels;
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

        private ViewModelQuestion _ViewModelQuestion;

        #endregion

        #region Properties

        public IViewModelQuestion ViewModelQuestion => _ViewModelQuestion;

        #endregion

        #region Constructors

        public ViewModelQcm()
        {
            _ViewModelQuestion = new ViewModelQuestion();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            _ViewModelQuestion.Qcm = Item;
            _ViewModelQuestion.LoadData();
        }

        #endregion
    }
}
