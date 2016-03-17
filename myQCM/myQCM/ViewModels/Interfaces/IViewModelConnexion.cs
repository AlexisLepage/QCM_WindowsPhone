using MVVM;
using MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQCM.ViewModels.Interfaces
{
    public interface IViewModelConnexion : IViewModel
    {
        DelegateCommand ConnectCommand { get; }
    }
}
