using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MVVM.Interfaces;

namespace myQCM.ViewModels
{
   public class ViewModelCategories : ViewModelList<Category>, IViewModelCategories
   {
        #region Constructors

        public ViewModelCategories()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            
        }

        
        #endregion
    }
}
