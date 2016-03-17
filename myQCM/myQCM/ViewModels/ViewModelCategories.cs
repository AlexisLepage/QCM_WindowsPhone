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

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri("http://169.254.80.80/Qcm/web/app_dev.php/api/users"));

            DateTime date = new DateTime();
            this.ItemsSource.Add(new Category(1, "Windows Phone", date, date));
            this.ItemsSource.Add(new Category(2, "IOS", date, date));
            this.ItemsSource.Add(new Category(3, "Android", date, date));
            this.ItemsSource.Add(new Category(4, "Sécurité", date, date));
            this.ItemsSource.Add(new Category(5, "UML", date, date));
            this.ItemsSource.Add(new Category(6, "Veille technologique", date, date));
        }

        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;

            User[] user = JsonConvert.DeserializeObject<User[]>(jsonstream);

            System.Threading.Thread.Sleep(5000);

            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                IsBusy = false;
            });
        }

        #endregion
    }
}
