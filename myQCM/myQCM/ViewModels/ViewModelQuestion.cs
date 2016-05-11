using MVVM.Interfaces;
using MVVM.Service;
using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.ViewModels
{
    public class ViewModelQuestion : ViewModelItem<Question>, IViewModelQuestion
    {
        #region Fields

        private ViewModelAnswers _ViewModelAnswers;

        #endregion

        #region Properties

        public IViewModelAnswers ViewModelAnswers => _ViewModelAnswers;

        #endregion

        #region Constructors

        public ViewModelQuestion()
        {
            _ViewModelAnswers = new ViewModelAnswers();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            _ViewModelAnswers.Question = Item;
            _ViewModelAnswers.LoadData();
        }

        #endregion

    }
}
