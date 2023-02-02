using AddressBook_G.InterFaces;

namespace AddressBook_G.Models;

public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string Country { get; set; } = null!;

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} \nEmail: {Email} \nPhone Number: {PhoneNumber} \nAddress: {StreetName}, {Country}";
        }
    

    }

