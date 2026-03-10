using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMvvmProject.Models.ViewModels
{
    internal class EmployeeDetailViewModel : INotifyPropertyChanged
    {
        public string employeename;
        public string EmployeeId { get; set; }
        public string EmployeeName
        {
            get {return employeename;}
            set 
            { 
                employeename = value;
                NotifyPropertyChanged(nameof(EmployeeName));
            }
        }
        public string Email { get; set; }
        public bool IsPartTime { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
