using MauiAppExample.Models;
using Contact = MauiAppExample.Models.Contact;

namespace MauiAppExample.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

        List<Contact> contacts = ContactRepository.GetContacts();

        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            //DisplayAlert("Information", "Navigating to edit contact page", "OK");
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
        //logic
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}

//private void Btn_GetContact_Clicked(object sender, EventArgs e)
//{
//    Shell.Current.GoToAsync(nameof(ContactsPage));
//}

//private void Btn_AddContact_Clicked(object sender, EventArgs e)
//{
//    Shell.Current.GoToAsync(nameof(AddContactPage));
//}

//private void Btn_EditContact_Clicked(object sender, EventArgs e)
//{
//    Shell.Current.GoToAsync(nameof(EditContactPage));
//}
//}