using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WPFAddressBook_2.MVVM.Models;

namespace WPFAddressBook_2.MVVM.ViewModels;

public partial class ContactsViewModel : ObservableObject
{

    [ObservableProperty]
    private string firstName = string.Empty;
    
    [ObservableProperty]
    private string lastName = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;


    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string streetName = string.Empty;


    [ObservableProperty]
    private string country = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ContactModel> contacts = null!;

    public ContactsViewModel()
    {

    }

    public ContactsViewModel(ContactModel selectedContact)
    {
        firstName = selectedContact.FirstName;
        lastName = selectedContact.LastName;
        phoneNumber = selectedContact.PhoneNumber;
        email = selectedContact.Email;
        streetName = selectedContact.StreetName;
        country = selectedContact.Country;
    }

}
