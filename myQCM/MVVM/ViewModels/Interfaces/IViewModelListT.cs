using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public interface IViewModelList<T>
    {
        T SelectedItem { get; set; }

        ObservableCollection<T> ItemsSource { get; set; }


    }
}
