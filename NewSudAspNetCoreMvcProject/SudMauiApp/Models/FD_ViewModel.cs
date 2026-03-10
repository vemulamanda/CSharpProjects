using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace SudMauiApp.Models
{
    [QueryProperty(nameof(Single_FDData), "SelectedAd")]
    public partial class FD_ViewModel : ObservableObject
    {
        string baseUrl = "http://10.112.0.165:5000/images";

        public readonly FarmApiService _farmApiService;

        [ObservableProperty]
        public FishData singleAd;   //This is for capturing the data and binding to fishdata.cs after querying single Ad data from API.

        //[ObservableProperty]
        //public FishData singleFDData;
        
        [ObservableProperty]
        public ObservableCollection<FishData> finalfishdata = new();        //This will contain collection of list of items coming from api. it is Ienumerable

        [ObservableProperty]
        public FishData single_FDData;

        [ObservableProperty]
        public bool isLoading;

        public ObservableCollection<FishData> UserSpecificAds { get; set; } = new ObservableCollection<FishData>();


        public FD_ViewModel(FarmApiService farmApiService)
        {
            _farmApiService = farmApiService;
        }

        [RelayCommand]
        public async Task LoadFishData()
        {
            IsLoading = true;

            try
            {
                var api_Response = await _farmApiService.GetFishData();
                Finalfishdata.Clear();

                if (api_Response != null)
                {
                    foreach (var item in api_Response)
                    {
                        //// determine base URL
                        ////string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                        ////  ? "http://10.0.2.2:5202/images" : "http://10.0.2.2:5202/images";

                        //string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                        //? "http://10.112.0.165:5000/images" : "http://10.112.0.165:5000/images";

                        ////string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                        ////? "http://4.198.108.221:80/images" : "http://4.198.108.221:80/images";

                        for (int i = 0; i < item.imagePath.Length; i++)
                        {
                            string path = item.imagePath[i];
                            string fullUrl = $"{baseUrl}/{path}";
                            item.imagePath[i] = fullUrl; // <-- directly updates the list element
                        }

                        //item.ImgPath.Clear();
                        //foreach (var path in item.imagePath)
                        //{
                        //    string fullUrl = $"{baseUrl}/{path}";
                        //    item.ImgPath.Add(fullUrl);
                        //}


                        Finalfishdata.Add(item);
                    }
                }
            }
            finally
            {
                IsLoading = false;
            }
        }


        [RelayCommand]
        public async Task LoadFishDataByDistrict(string district)
        {
            IsLoading = true;

            try
            {
                var api_Response = await _farmApiService.SearchDistrict(district);
                Finalfishdata.Clear();

                if (api_Response != null)
                {
                    // filter by district
                    //var filtered = api_Response.Where(f => f.District == district);

                    foreach (var item in api_Response)
                    {
                        //string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                        //? "http://10.112.0.207:5202/images" : "http://10.112.0.207:5202/images";

                        //string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                         // ? "http://10.0.2.2:5202/images" : "http://10.0.2.2:5202/images";

                        //string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                        //    ? "http://4.198.108.221:80/images" : "http://4.198.108.221:80/images";

                        for (int i = 0; i < item.imagePath.Length; i++)
                        {
                            string path = item.imagePath[i];
                            string fullUrl = $"{baseUrl}/{path}";
                            item.imagePath[i] = fullUrl;
                        }

                        Finalfishdata.Add(item);
                    }
                }
            }
            finally
            {
                IsLoading = false;
            }
        }


        public async Task LoadSingleFishData(int userid)
        {
            IsLoading= true;
            try
            {
                //var response = Finalfishdata.FirstOrDefault(u => u.custid == userid);

                var response = await _farmApiService.GetSingleFishData(userid);

                if (response != null)
                {
                    //string baseUrl = "http://10.112.0.207:5202/images/";
                    //string baseUrl = "http://4.198.108.221:80/images/";
                    //string baseUrl = "http://10.0.2.2:5202/images/";

                    response.imagePath = response.imagePath
                        .Select(url => $"{baseUrl}{url}")
                        .ToArray();


                    SingleAd = response;
                    //Console.WriteLine($"SingleAd loaded: {SingleAd.name}");
                }
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task LoadUserAdsAsync()
        {
            string id = await SecureStorage.GetAsync("user_guid");

            var ads = finalfishdata.Where(ad => ad.userGuid == id).ToList();

            UserSpecificAds.Clear();
            foreach (var ad in ads)
                UserSpecificAds.Add(ad);
        }

    }
}
