using CommunityToolkit.Mvvm.ComponentModel;

namespace SudMauiApp.Models
{
    public partial class UploadImagesStoreModel
    {
        public string name;

        public ImageSource uploadedImages;
        public byte[] imageBytes { get; set; }
        //public string? imageUrls { get; set; }

        //public bool IsNew => imageBytes != null;  // <---- VERY IMPORTANT
    }
}

