using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiMvvmProject.Models.ViewModels
{
    internal partial class EmployeeDetailViewModel2 : ObservableObject
    {
        [ObservableProperty]
        private string employeeId;

        [ObservableProperty]
        private string employeeName;
        
        [ObservableProperty]
        private string email;
        
        [ObservableProperty]
        private bool isPartTimer;
    }
}
