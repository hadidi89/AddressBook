using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFAddressBook_2.MVVM.Models;
using WPFAddressBook_2.Services;

namespace WPFAddressBook_2.MVVM.ViewModels;

public partial class EditContactViewModel : ObservableObject
{
    private ContactModel outdatedContacts;

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

    public EditContactViewModel()
    {

    }

    public EditContactViewModel(ContactModel contact)
    {
        firstName = contact.FirstName;
        lastName = contact.LastName;
        phoneNumber = contact.PhoneNumber;
        email = contact.Email;
        streetName = contact.StreetName;
        country = contact.Country;

        outdatedContacts = new ContactModel
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber,
            Email = contact.Email,
            StreetName = contact.StreetName,
            Country = contact.Country
        };
    }

    [RelayCommand]
    private void SaveEdits()
    {
        ContactModel updatedContact = new()
        {
            Id = outdatedContacts.Id,
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            Email = Email,
            StreetName = StreetName,
            Country = Country
        };

        ContactService.Edit(updatedContact);
    }
}
