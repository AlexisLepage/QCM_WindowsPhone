using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public abstract class ViewModelList<T> : ObservableObject, IViewModelList<T>
    {
        #region Fields

        private ObservableCollection<T> _ItemsSource;
        private T _SelectedItem;
        private DelegateCommand _AddItemCommand;

        #endregion

        #region Properties

        public ObservableCollection<T> ItemsSource
        {
            get { return _ItemsSource; }
            set { SetProperty(nameof(ItemsSource), ref _ItemsSource, value); }
        }

        public T SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(nameof(SelectedItem), ref _SelectedItem, value); }
        }


        public DelegateCommand AddItemCommand => _AddItemCommand;

        #endregion

        #region Constructors

        public ViewModelList()
        {
            ItemsSource = new ObservableCollection<T>();

            _AddItemCommand = new DelegateCommand(ExecuteDeviceStatusCommand, CanExecuteDeviceStatusCommand);
        }

        #endregion

        #region Methods

        public abstract void LoadData();

        public virtual bool CanExecuteDeviceStatusCommand(object parameter)
        {
            return false;
        }

        public virtual void ExecuteDeviceStatusCommand(object parameter)
        {

        }

        #endregion
    }
}
