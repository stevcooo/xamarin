using ClassesScheduler.Models;
using ClassesScheduler.Pages;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClassesScheduler.ViewModels
{
    public class YearOfStudyViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public YearOfStudyViewModel(INavigation navigation)
        {
            Navigation = navigation;

            KeyValue kv = new KeyValue();
            kv.Key = "1";
            kv.Value = 1;
            kv.Description = "First year";
            Items.Add(kv);

            kv = new KeyValue();
            kv.Key = "2";
            kv.Value = 2;
            kv.Description = "Second year";
            Items.Add(kv);

            kv = new KeyValue();
            kv.Key = "3";
            kv.Value = 3;
            kv.Description = "Third year";
            Items.Add(kv);

            kv = new KeyValue();
            kv.Key = "4";
            kv.Value = 4;
            kv.Description = "Fourth year";
            Items.Add(kv);

            OnItemTapped = new Command(x =>
            {
                var val = x as KeyValue;
                if (val != null)
                {
                    App.ScheduleParametars.YearOfStudy = val.Value;                    
                    Navigation.PushAsync(new SchedulePage());
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
