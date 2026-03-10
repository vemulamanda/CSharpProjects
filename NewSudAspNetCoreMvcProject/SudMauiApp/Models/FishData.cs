using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SudMauiApp.Models
{
    public partial class FishData
    {
        public int custid { get; set; }
        public string name { get; set; }
        public string firstBreed { get; set; }
        public double fB_Price { get; set; }
        public double fB_Pieces { get; set; }
        public string secondBreed { get; set; }
        public double sB_Price { get; set; }
        public double sB_Pieces { get; set; }
        public string thirdBreed { get; set; }
        public double tB_Price { get; set; }
        public double tB_Pieces { get; set; } 
        public string address { get; set; }
        public string district { get; set; }
        public string[] imagePath { get; set; }
        public string userGuid { get; set; }

        //[ObservableProperty]
        //public ObservableCollection<string> imgPath = new();
    }
}
