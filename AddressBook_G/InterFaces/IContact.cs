namespace AddressBook_G.InterFaces;

public interface IContact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string StreetName { get; set; }
    public string Country { get; set; }

    string DisplayName => $"{FirstName} {LastName}";
    string Enail => $"{FirstName.ToLower()}.{LastName.ToLower()}.{PhoneNumber}.{StreetName}.{Country}@domain.com ";


}