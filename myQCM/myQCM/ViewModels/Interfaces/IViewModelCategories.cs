using MVVM.Interfaces;
using MVVM.ViewModels;
using myQCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.ViewModels.Interfaces
{
   public interface IViewModelCategories : IViewModelList<Category>
   {
        User User { get; set; }
    }
}
