using ClassesScheduler.Enums;
using ClassesScheduler.Helpers;
using ClassesScheduler.Models;
using ClassesScheduler.Pages;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClassesScheduler.ViewModels
{
    public class StudyFieldsViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public StudyFieldsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Items = EnumToListHelper.Convert<StudyField>();

            OnItemTapped = new Command(x =>
             {
                 var val = x as KeyValue;
                 if (val != null)
                 {
                     App.Instance.ScheduleParametars.StudyField = val;
                     Navigation.PushAsync(new YearOfStudyPage());                     
                 }
            });
        }

        private ObservableCollection<KeyValue> _items;
        public ObservableCollection<KeyValue> Items
        {
            get
            {
                if (_items == null)
                    _items = new ObservableCollection<KeyValue>();

                return _items;
            }
            set
            {
                _items = value;
            }
        }

        private KeyValue _selectedItem;
        public KeyValue SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (_selectedItem == null)
                    return;

                OnItemTapped.Execute(_selectedItem);
                SelectedItem = null;
            }
        }

        private Command _onItemTapped;
        public Command OnItemTapped
        {
            get
            {
                return _onItemTapped;
            }
            set
            {
                _onItemTapped = value;
                NotifyPropertyChanged("OnItemTapped");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
