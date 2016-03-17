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
    public class ViewModelCategory : ViewModelItem<Category>, IViewModelCategory
    {
        #region Fields

        private ViewModelQcms _ViewModelQcms;

        #endregion

        #region Properties

        public IViewModelQcms ViewModelQcms => _ViewModelQcms;

        #endregion

        #region Constructors

        public ViewModelCategory()
        {
            _ViewModelQcms = new ViewModelQcms();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            _ViewModelQcms.Category = Item;
            _ViewModelQcms.LoadData();
        }

        #endregion
    }
}
