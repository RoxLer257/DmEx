using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dem_ex_final
{
    public class zayavka : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string type_problem;
        private string description_problems;
        private DateTime date;
        private string name_clients;
        private string phone_num_cl;
        private string status;
        private string responsible;

        public zayavka( int id, string name, string description_problems, DateTime date, string name_clients, string phone_num_cl, string type_problem, string status, string responsible)
        {
            this.id = id;
            this.name = name;
            this.description_problems = description_problems;
            this.date = date;
            this.name_clients = name_clients;
            this.phone_num_cl = phone_num_cl;
            this.type_problem = type_problem;
            this.status = status;
            this.responsible = responsible;
        }

        private bool isVisible = true;
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }
        public int ID 
        { 
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description_problems
        {
            get { return description_problems; }
            set
            {
                description_problems = value;
                OnPropertyChanged("Description_problems");
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Name_clients
        {
            get { return name_clients; }
            set
            {
                name_clients = value;
                OnPropertyChanged("Name_clients");
            }
        }
        public string Phone_num_cl
        {
            get { return phone_num_cl; }
            set
            {
                phone_num_cl = value;
                OnPropertyChanged("phone_num_cl");
            }
        }
        public string Type_problem
        {
            get { return type_problem; }
            set
            {
                type_problem = value;
                OnPropertyChanged("Type_problem");
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        public string Responsible
        {
            get { return responsible; }
            set
            {
                responsible = value;
                OnPropertyChanged("Responsible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
