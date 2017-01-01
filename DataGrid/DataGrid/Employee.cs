using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;
        private string _title;
        private bool _wasReelected;
        private Party _affilation;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
    
        public bool WasReelected
        {
            get
            {
                return _wasReelected;
            }

            set
            {
                _wasReelected = value;
                RaisePropertyChanged();
            }
        }

        public Party Affilation
        {
            get
            {
                return _affilation;
            }

            set
            {
                _affilation = value;
                RaisePropertyChanged();
            }
        }

        //method to pull list of employees. Observable Collection allows application to know when list is updated
        public static ObservableCollection<Employee> GetEmployees()
        {
            ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
            emp.Add(new Employee {Name = "Washington" , Title = "President", WasReelected = true , Affilation = Party.Indepenent });
            emp.Add(new Employee { Name = "Dubya", Title = "President", WasReelected = true, Affilation = Party.Republican });
            emp.Add(new Employee { Name = "Obama", Title = "President", WasReelected = true, Affilation = Party.Democrat });
            return emp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }

    public enum Party
    {
        Indepenent,
        Republican,
        Democrat
    }
}
