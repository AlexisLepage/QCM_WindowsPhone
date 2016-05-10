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
    public class ViewModelQcms : ViewModelList<Qcm>, IViewModelQcms
    {
        #region Fields

        private Category _Category;

        #endregion

        #region Properties

        public Category Category
        {
            get { return _Category; }
            set { SetProperty(nameof(Category), ref _Category, value); }
        }

        #endregion

        #region Constructors

        public ViewModelQcms()
        {
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            this.ItemsSource = new System.Collections.ObjectModel.ObservableCollection<Qcm>(this.Category.Qcms);
        }

        #endregion
    }
}
