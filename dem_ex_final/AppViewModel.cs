using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;

namespace dem_ex_final
{
    public class AppViewModel : INotifyPropertyChanged
    {

        private zayavka selectedZayavka;

        public ObservableCollection<string> Statuses { get; set; }

        public ObservableCollection<zayavka> zayavkaList {  get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    zayavka zayavka = new zayavka(0, "", "", DateTime.UtcNow, "", "", "", "", "");
                    zayavkaList.Insert(0,zayavka);
                    SelectedZayavka = zayavka;
                }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    zayavka zayavka = obj as zayavka;
                    if (zayavka != null)
                    {
                        zayavkaList.Remove(zayavka);
                    }
                },
                (obj) => SelectedZayavka != null
                ));
            }
        }

        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
                FilterZayavkaList();
            }
        }

        public zayavka SelectedZayavka
        {
            get { return selectedZayavka; }
            set
            {
                selectedZayavka = value;
                OnPropertyChanged("SelectedZayavka");
            }
        }
        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                DateZayavkaList();
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        private ObservableCollection<DateTime> availableDates;
        public ObservableCollection<DateTime> AvailableDates
        {
            get { return availableDates; }
            set
            {
                availableDates = value;
                OnPropertyChanged(nameof(AvailableDates));
            }
        }

        public AppViewModel()
        {
            Statuses = new ObservableCollection<string> {"В ожидании", "В работе", "Выполнено"};
            zayavkaList = new ObservableCollection<zayavka>
            {
                new zayavka(213, "часы", "не работают", DateTime.UtcNow, "Влад", "89746541532", "Сломалась часовая стрелка",Statuses[0],"Серебряков В.А"),
                new zayavka(4356, "принтер", "не печатает", DateTime.UtcNow, "Иван", "89873584350", "-",Statuses[1],"Серебряков В.А"),
                new zayavka(63, "компьютер", "не включается", DateTime.UtcNow, "Алиса", "89775351562", "-",Statuses[2],"Серебряков В.А")
            };

            AvailableDates = new ObservableCollection<DateTime>(zayavkaList.Select(z => z.Date.Date).Distinct());
            SelectedDate = AvailableDates.FirstOrDefault();
        }

        private void DateZayavkaList()
        {
            if (SelectedDate == default)
        {
            foreach (var item in zayavkaList)
            {
                item.IsVisible = true;
            }
        }
        else
        {
            foreach (var item in zayavkaList)
            {
                item.IsVisible = item.Date.Date == SelectedDate.Date;
            }
        }
        OnPropertyChanged(nameof(zayavkaList));
        }

        private void FilterZayavkaList()
        {

            if (string.IsNullOrEmpty(SearchText))
            {
                foreach(var item in zayavkaList)
                {
                    item.IsVisible = true;
                }
            }
            else
            {
                foreach(var item in zayavkaList)
                {
                    if (item.Name.Contains(SearchText))
                    {
                        item.IsVisible = true;
                    }
                    else
                    {
                        item.IsVisible = false;
                    }
                }
            }
            OnPropertyChanged(nameof(zayavkaList));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}