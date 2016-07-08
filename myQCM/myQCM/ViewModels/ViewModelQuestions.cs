using MVVM.Interfaces;
using MVVM.Service;
using MVVM.ViewModels;
using myQCM.Models;
using myQCM.ViewModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace myQCM.ViewModels
{
    public class ViewModelQuestions : ViewModelList<Answer>, IViewModelQuestions
    {
        #region Fields

        private Qcm _Qcm;

        private Question _Question;

        ObservableCollection<Question> questions = new ObservableCollection<Question>();

        public int index = 0;

        public bool isFirst = true;

        public bool questionsOk = false;

        #endregion

        #region Properties

        /// <summary>
        /// Getter and Setter Qcm field.
        /// </summary>
        public Qcm Qcm
        {
            get { return _Qcm; }
            set { SetProperty(nameof(Qcm), ref _Qcm, value); }
        }

        /// <summary>
        /// Getter and Setter Question field.
        /// </summary>
        public Question Question
        {
            get { return _Question; }
            set { SetProperty(nameof(Question), ref _Question, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load data questions to ItemSource and First question.
        /// </summary>
        public override void LoadData()
        {
            if (isFirst == false)
            {

                if (!questionsOk)
                {
                    foreach (Question question in this.Qcm.Questions)
                    {
                        questions.Add(question);
                        questionsOk = true;
                    }
                }

                this.Question = questions.ElementAt(index);

                this.ItemsSource = this.Question.Answers;
            }
            
        }

        /// <summary>
        /// Tracker property.
        /// </summary>
        protected override void InitializePropertyTrackers()
        {
            base.InitializePropertyTrackers();

            this.AddPropertyTrackerAction(nameof(SelectedItem), (sender, args) =>
            {
                if (SelectedItem != null)
                {
                    ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/QuestionsPage.xaml", UriKind.Relative));
                }
            });
        }

        #endregion

        #region Navigation

        /// <summary>
        /// On navigated to ViewModel.
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedTo(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);
        }

        /// <summary>
        /// On navigated from ViewModel.
        /// </summary>
        /// <param name="viewModel"></param>
        //public override void OnNavigatedFrom(IViewModel viewModel)
        //{
        //    base.OnNavigatedFrom(viewModel);

        //    if (viewModel is IViewModelQuestion)
        //    {
        //        ((IViewModelQuestion)viewModel).Item = this.ItemsSource.First();
        //        ((IViewModelQuestion)viewModel).LoadData();
        //        SelectedItem = null;
        //    }
        //}
        #endregion

        protected override void ExecuteAddItem(object parameter)
        {
            base.ExecuteAddItem(parameter);
        }
        protected override bool CanExecuteAddItem(object parameter)
        {
            if(this.questions.Count != 0)
            {
                if (this.index == this.questions.IndexOf(this.questions.Last()))
                {
                    Encoding encoding = new UTF8Encoding();
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                    var idUser = localSettings.Values["id"];
                    int idQcm = Qcm.IdServer;
                    float note = calculateNote(this.questions);

                    string data = "id_qcm=" + idQcm + "&id_user=" + idUser + "&note=" + note;

                    WebClient web = new WebClient();
                    web.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    web.UploadStringCompleted += new UploadStringCompletedEventHandler(UploadStringCallback2);
                    web.UploadStringAsync((new Uri("http://172.20.10.4/Qcm/web/app_dev.php/api/update_qcm")), "POST", data);

                    ServiceResolver.GetService<INavigationService>().Navigate(new Uri("/Views/EndPage.xaml", UriKind.Relative));

                    return false;
                }

                if (isFirst == false)
                {
                    this.index = this.index + 1;
                }
                
            }
                        
            this.LoadData();

            isFirst = false;

            return true;
        }

        protected override void ExecutePreviousItem(object parameter)
        {
            base.ExecutePreviousItem(parameter);
        }

        protected override bool CanExecutePreviousItem(object parameter)
        {
            if (this.questions.Count != 0)
            {
                if (this.index == this.questions.IndexOf(this.questions.First()))
                {
                    return false;
                }
            }

            if (isFirst == false)
            {
                this.index = this.index - 1;
            }

            this.LoadData();

            return true;
        }


        protected float calculateNote(ObservableCollection<Question> questions)
        {
            float note = 0;
            float noteMax = 0;

            foreach(Question question in questions)
            {
                noteMax = noteMax + question.Value;
                if(question.Answers != null)
                {
             
                    bool goodAnswer = true;

                    foreach (Answer answer in question.Answers)
                    {
                        if((answer.IsValid && !answer.IsSelected) || (!answer.IsValid && answer.IsSelected))
                        {
                            goodAnswer = false;
                        }
                    }

                    if (goodAnswer)
                    {
                        note = note + question.Value;
                    }
                }
            }

            note = (note * 20) / noteMax;

            return note;

        }

        private static void UploadStringCallback2(Object sender, UploadStringCompletedEventArgs e)
        {
            string reply = (string)e.Result;
            Console.WriteLine(reply);
        }
    }
}
