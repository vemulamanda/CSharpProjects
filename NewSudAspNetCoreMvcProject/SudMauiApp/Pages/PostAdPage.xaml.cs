using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls;
using SudMauiApp.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
//using static Android.Graphics.ImageDecoder;

namespace SudMauiApp.Pages;

//This is coming from edit Ad page to edit the Ad.
[QueryProperty(nameof(EditSingleFD), "EditSingleFD")]

//This is coming from edit Ad page to Delete the Ad.
[QueryProperty(nameof(DeleteSingleFD), "DeleteSingleFD")]
public partial class PostAdPage : ContentPage
{
    public FishData EditSingleFD { get; set; }
    public FishData DeleteSingleFD { get; set; }

    public Grid image_grid;

    //public ImageButton imgbtn;

    public Button btn_Cancel;

    private List<ImageButton> imageButtons = new();

    private List<Button> cancelBtnList = new();

    public ObservableCollection<UploadImagesStoreModel> uploadedImageslist = new();

    public string res_msg;

    public string responseMessage;

    bool IsEditMode => EditSingleFD != null;
    bool IsDeleteMode => DeleteSingleFD != null;

    public PostAdPage()
    {
        InitializeComponent();

        District.ItemsSource = new List<string>
        {
            "Srikakulam", "Vizianagaram", "Visakhapatnam", "Anakapalli", "Alluri Sitharama Raju", "Parvathipuram Manyam",
            "East Godavari", "Kakinada", "Dr. B.R. Ambedkar Konaseema", "West Godavari", "Eluru", "Krishna", "NTR", "Guntur", "Palnadu", "Bapatla", "Prakasam", "Sri Potti Sriramulu Nellore",
            "Kurnool", "Nandyal", "Anantapuramu", "Sri Sathya Sai", "Chittoor", "Tirupati", "Annamayya", "YSR (Kadapa)", "Madanapalle",
            "Markapuram", "Polavaram"
        };

        BindingContext = this;
        ImgBorderCreation();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        FirstBreed.ItemsSource = new List<string>
        {
            "Seelavathi", "Katla", "Koramenu", "Catfish", "Pariga"
        };

        SecondBreed.ItemsSource = new List<string>
        {
            "none", "Seelavathi", "Katla", "Koramenu", "Catfish", "Pariga"
        };

        ThirdBreed.ItemsSource = new List<string>
        {
            "none", "Seelavathi", "Katla", "Koramenu", "Catfish", "Pariga"
        };


        if (IsEditMode)
        {
            Btn_SubmitForm.Text = "Update Ad";
            Btn_SubmitForm.TextColor = Colors.White;
        }
        else if (IsDeleteMode) 
        {
            Btn_SubmitForm.Text = "Delete Ad";
            Btn_SubmitForm.TextColor = Colors.White;
        }
        else
        { 
            Btn_SubmitForm.Text = "Post Ad";
            Btn_SubmitForm.TextColor = Colors.White;
        }


        if (IsEditMode)
        {
            FirstBreed.SelectedItem = EditSingleFD.firstBreed;
            FB_Price.Text = EditSingleFD.fB_Price.ToString();
            FB_Pieces.Text = EditSingleFD.fB_Pieces.ToString();
            SecondBreed.SelectedItem = EditSingleFD?.secondBreed;
            SB_Price.Text = EditSingleFD?.sB_Price.ToString();
            SB_Pieces.Text = EditSingleFD?.sB_Pieces.ToString();
            ThirdBreed.SelectedItem = EditSingleFD?.thirdBreed;
            TB_Price.Text = EditSingleFD?.tB_Price.ToString();
            TB_Pieces.Text = EditSingleFD?.tB_Pieces.ToString();
            Address.Text = EditSingleFD.address;

            District.SelectedItem = EditSingleFD.district;

            foreach (var imgUrl in EditSingleFD.imagePath)
            {
                uploadedImageslist.Add(new UploadImagesStoreModel
                {
                    uploadedImages = ImageSource.FromUri(new Uri(imgUrl)),
                    imageBytes = null, // Important
                    name = Path.GetFileName(imgUrl)
                });
            }

            RefreshImageButtons();

        }
        //////////////////////////////////////////////////////////////////////////////////////

        if (IsDeleteMode)
        {
            FirstBreed.SelectedItem = DeleteSingleFD.firstBreed;
            FB_Price.Text = DeleteSingleFD.fB_Price.ToString();
            FB_Pieces.Text = DeleteSingleFD.fB_Pieces.ToString();
            SecondBreed.SelectedItem = DeleteSingleFD?.secondBreed;
            SB_Price.Text = DeleteSingleFD?.sB_Price.ToString();
            SB_Pieces.Text = DeleteSingleFD?.sB_Pieces.ToString();
            ThirdBreed.SelectedItem = DeleteSingleFD?.thirdBreed;
            TB_Price.Text = DeleteSingleFD?.tB_Price.ToString();
            TB_Pieces.Text = DeleteSingleFD?.tB_Pieces.ToString();
            Address.Text = DeleteSingleFD.address;
            District.SelectedItem = DeleteSingleFD.district;



            foreach (var imgUrl in DeleteSingleFD.imagePath)
            {
                uploadedImageslist.Add(new UploadImagesStoreModel
                {
                    uploadedImages = ImageSource.FromUri(new Uri(imgUrl)),
                    imageBytes = null, // Important
                    name = Path.GetFileName(imgUrl)
                });
            }

            RefreshImageButtons();

            FirstBreed.IsEnabled = false;
            FB_Price.IsEnabled = false;
            FB_Pieces.IsEnabled = false;
            SecondBreed.IsEnabled = false;
            SB_Price.IsEnabled = false;
            SB_Pieces.IsEnabled = false;
            ThirdBreed.IsEnabled = false;
            TB_Price.IsEnabled = false;
            TB_Pieces.IsEnabled = false;
            Address.IsEnabled = false;
            District.IsEnabled = false;

            foreach (var btns in imageButtons)
            {
                btns.IsEnabled = false;
            }

            foreach (var btns in cancelBtnList)
            {
                btns.IsEnabled = false;
            }
        }
    }

    public void ImgBorderCreation()
    {
        for (int i = 0; i < 10; i++) 
        {
            var image_grid = new Grid();

            var imgbtn = new ImageButton
            {                
                WidthRequest = 120,
                HeightRequest = 120,
                BackgroundColor = Colors.Transparent           
            };

            /*if(i == 0)
            {
                imgbtn.Source = "uploadimage.jpg";
            }*/

            image_grid.Children.Add(imgbtn);

            btn_Cancel = new Button
            {
                Text = "X",
                BackgroundColor = Colors.White,
                TextColor = Colors.Black,
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 30,
                IsVisible = false
                
            };

            image_grid.Children.Add(btn_Cancel);
            image_grid.SetRow(btn_Cancel, 0);
            image_grid.SetColumn(btn_Cancel, 1);
            btn_Cancel.HorizontalOptions = LayoutOptions.End;
            btn_Cancel.VerticalOptions = LayoutOptions.Start;
            btn_Cancel.Margin = new Thickness(0, -5, -5, 0); 

            var border = new Border
            {
                Stroke = Color.FromArgb("#e6e6e6"),
                StrokeThickness = 3,
                Margin = 2,
                HeightRequest = 120,
                WidthRequest = 120,
                Content = image_grid
            };

            int index = i; // capture index for use in lambda

            imgbtn.Clicked += async (s, e) =>
            {
                await Btn_ImageUpload_Clicked(index); 
            };

            btn_Cancel.Clicked += async (s, e) =>
            {
                await Btn_Cancel_Clicked(index);
            };

            if (i < 3)
            {
                ImgUploadBorderLayout01.Children.Add(border);
            }
            else if (i < 6)
            {
                ImgUploadBorderLayout02.Children.Add(border);
            }
            else if (i < 9)
            {
               ImgUploadBorderLayout03.Children.Add(border);
            }
            else
            {
                ImgUploadBorderLayout04.Children.Add(border);
            }
                imageButtons.Add(imgbtn);
                cancelBtnList.Add(btn_Cancel);
        }

    }

    private async Task Btn_ImageUpload_Clicked(int buttonIndex)
    {
        try
        {
            if (imageButtons[buttonIndex].Source == null)
            {
                var results = await FilePicker.PickMultipleAsync(new PickOptions
                {
                    PickerTitle = "Select up to 10 images",
                    FileTypes = FilePickerFileType.Images
                });

                if (results == null || !results.Any())
                    return;

                foreach (var file in results)
                {
                    if (uploadedImageslist.Count >= 10)
                    {
                        break;
                    }
                    else
                    {
                        using var originalStream = await file.OpenReadAsync();
                        using var memoryStream = new MemoryStream();
                        await originalStream.CopyToAsync(memoryStream);
                        memoryStream.Position = 0;

                        var imageSource = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));

                        {
                            uploadedImageslist.Add(new UploadImagesStoreModel
                            {
                                name = file.FileName,
                                uploadedImages = imageSource,
                                imageBytes = memoryStream.ToArray()
                            });
                        }
                    }
                }
            
            for (int i = 0; i < imageButtons.Count; i++)
            {                
               if(i < uploadedImageslist.Count)
                {
                    imageButtons[i].Source = uploadedImageslist[i].uploadedImages;

                    imageButtons[i].Aspect = Aspect.Fill;

                    cancelBtnList[i].IsVisible = true;
                }
                else
                {
                    imageButtons[i].Source = null; // reset unused buttons
                }
            }  
        }
        else
        {
            await Navigation.PushAsync(new DisplaySingleImage(imageButtons[buttonIndex].Source));
        }
    }

        catch (Exception ex)
        {
            await DisplayAlert("Info", "Something went wrong. Unable to upload image.", "Cancel");
        }
    }

    public async Task Btn_Cancel_Clicked(int CancelBtnIndex)
    {
        try
        {
            //await DisplayAlert("Info", uploadedImageslist.Count.ToString(), "OK");

            for (int i = 0; i < uploadedImageslist.Count; i++)
            {
                imageButtons[i].Source = null;
                cancelBtnList[i].IsVisible = false;
            }

            uploadedImageslist.RemoveAt(CancelBtnIndex);

            RefreshImageButtons();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void RefreshImageButtons()
    {
        for (int i = 0; i < imageButtons.Count; i++)
        {
            if (i < uploadedImageslist.Count)
            {
                imageButtons[i].Source = uploadedImageslist[i].uploadedImages;
                imageButtons[i].Aspect = Aspect.Fill;
                cancelBtnList[i].IsVisible = true;
            }
            else
            {
                imageButtons[i].Source = null;
                cancelBtnList[i].IsVisible = false;
            }
        }
    }
     

    private async void Btn_SubmitForm_Clicked(object sender, EventArgs e)
    {
        if (FirstBreed.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please select First Breed Name", "OK");
            FirstBreed.Focus();
            return;
        }
        if (FB_Pieces.Text == null || FB_Pieces.Text == "")
        {
            await DisplayAlert("Error", "Please enter number of piecesfor First Breed", "OK");
            FB_Pieces.Focus();
            return;
        }
        if (FB_Price.Text == null || FB_Price.Text == "")
        {
            await DisplayAlert("Error", "Please enter price of First Breed(per each piece)", "OK");
            FB_Price.Focus();
            return;
        }
        if (Address.Text == null || Address.Text == "")
        {
            await DisplayAlert("Error", "Please enter Farm Address", "OK");
            Address.Focus();
            return;
        }
        if (District.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please select District", "OK");
            District.Focus();
            return;
        }
        if (uploadedImageslist.Count == 0)
        {
            await DisplayAlert("Error", "Please Upload atleast one image", "OK");
            return;
        }

        if (SecondBreed.SelectedItem?.ToString() == "none")
        {
            SecondBreed.SelectedItem = -1;
            SB_Price.Text = "0";
            SB_Pieces.Text = "0";
        }

        if (ThirdBreed.SelectedItem?.ToString() == "none")
        {
            ThirdBreed.SelectedItem = -1;
            TB_Price.Text = "0";
            TB_Pieces.Text = "0";
        }


        var UserIdentity = await SecureStorage.GetAsync("user_identity");
        var UserGuid = await SecureStorage.GetAsync("user_guid");

        if (UserIdentity == null || UserIdentity == "" || UserGuid == null || UserGuid =="")
        {
            await DisplayAlert("Error", "User identity or User guid not found. Please LOGIN.", "OK");

            await Navigation.PushModalAsync(new LoginPage());
        }
        else
        {
            var content = new MultipartFormDataContent();

            // If Posting AD, Don't send Custid — database handles it
            //If Edit Ad, you need to send cust id.

            if (IsEditMode)
            {
                content.Add(new StringContent(EditSingleFD.custid.ToString()), "Custid");
            }
                       

            content.Add(new StringContent(UserIdentity), "Name");
            content.Add(new StringContent(FirstBreed.SelectedItem.ToString() ?? ""), "FirstBreed");
            content.Add(new StringContent(FB_Price.Text ?? "0"), "FB_Price");
            content.Add(new StringContent(FB_Pieces.Text ?? "0"), "FB_Pieces");
            content.Add(new StringContent(SecondBreed.SelectedItem?.ToString() ?? ""), "SecondBreed");
            content.Add(new StringContent(SB_Price.Text ?? "0"), "SB_Price");
            content.Add(new StringContent(SB_Pieces.Text ?? "0"), "SB_Pieces");
            content.Add(new StringContent(ThirdBreed.SelectedItem?.ToString() ?? ""), "ThirdBreed");
            content.Add(new StringContent(TB_Price.Text ?? "0"), "TB_Price");
            content.Add(new StringContent(TB_Pieces.Text ?? "0"), "TB_Pieces");
            content.Add(new StringContent(Address.Text ?? ""), "Address");
            content.Add(new StringContent(District.SelectedItem?.ToString() ?? ""), "District");
            content.Add(new StringContent(UserGuid), "UserGuid");

            foreach (var img in uploadedImageslist)
            {
                var imgBytes = img.imageBytes;
                
                if (imgBytes != null)
                {
                    var byteContent = new ByteArrayContent(imgBytes);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

                    content.Add(byteContent, "CustImages", img.name);
                }
                else
                {
                    content.Add(new StringContent(img.name), "ImagePath");
                }
            }

            try
            {
                Btn_SubmitForm.IsEnabled = false;

                LoadingOverlay.IsVisible = true;

                var apiservice = new FarmApiService();

                    if (Btn_SubmitForm.Text == "Update Ad")
                    {
                        // UPDATE existing ad
                        responseMessage = await apiservice.UpdateCustAd(content);
                    }
                    else if (Btn_SubmitForm.Text == "Delete Ad")
                    {
                        bool res = await DisplayAlert("Warning", "Do you want to delete this AD", "Delete", "Cancel");

                        if (!res)
                        {
                            return;                       
                        }
                        else
                        {
                            int C_Id = DeleteSingleFD.custid;
                            responseMessage = await apiservice.DeleteCustAd(C_Id);
                        }
                    }
                    else
                    {
                        // CREATE new ad
                        responseMessage = await apiservice.PostCustAd(content);
                    }

                    if (responseMessage != null)
                    {
                        res_msg = responseMessage;
                        await Navigation.PushModalAsync(new Res_Out_Page(res_msg));
                    }
                    else
                    {
                        res_msg = "Response message not received.";
                        await Navigation.PushModalAsync(new Res_Out_Page(res_msg));
                    }
            }
            catch (Exception ex)
            {                
                await DisplayAlert("Error", ex.Message, "OK");

                //await DisplayAlert("Error", "Your login has expired. Please login to post Ad", "OK");

                await Navigation.PushAsync(new FormUpload());
            }
            finally
            {
                Btn_SubmitForm.IsEnabled = true;
                LoadingOverlay.IsVisible = false;
            }
        }
    }
}