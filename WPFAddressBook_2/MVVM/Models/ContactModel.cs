using System;

namespace WPFAddressBook_2.MVVM.Models;

public class ContactModel 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!; 
    public string StreetName { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string DisplayName => $"{FirstName} {LastName}";
}
