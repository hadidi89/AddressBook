using AddressBook_G.InterFaces;
using AddressBook_G.Models;
using Newtonsoft.Json;

namespace AddressBook_G.Services
{
    public class MenuManager
    {
        public List<IContact> contacts = new List<IContact>();       // contacts list 
        private FileService file = new FileService();               // creating an instance of the "FileService" class 

        public string FilePath { get; set; } = null!;

        // Welcome menu 
        public void WelcomMenuManager()
        {
            Console.WriteLine("Welcome to the address book");
            Console.WriteLine("1. Create a contact");
            Console.WriteLine("2. View all contacts");
            Console.WriteLine("3. View a specific contact");
            Console.WriteLine("4. Delete a specific contact");
            Console.WriteLine("5. Update a specific contact");
            Console.WriteLine("Choose one of the options above:");
            var option = Console.ReadLine();

            // the options that user can choose
            switch (option)
            {
                case "1": CreateContact(); break;
                case "2": ViewAllContacts(); break;
                case "3": ViewSpecificContact(); break;
                case "4": DeleteSpecificContact(); break;
                case "5": UpdateSpecificContact(); break;
            }

            // This code is using the JsonConvert class from the Newtonsoft.Json library to serialize an object of an anonymous type containing a property called "contacts". 
            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }

        // creat contact 
        private void CreateContact()
        {
            Console.Clear();
            Console.WriteLine("Welcome to create a contact");
            IContact contact = new Contact();
            Console.WriteLine("Enter First name:");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Last name:");
            contact.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Email:");
            contact.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Enter PhoneNumber:");
            contact.PhoneNumber = Console.ReadLine() ?? "";
            Console.WriteLine("Enter streetName:");
            contact.StreetName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Country:");
            contact.Country = Console.ReadLine() ?? "";

            contacts.Add(contact);

        }
        // view all contacts 
        private void ViewAllContacts()
        {


            if (contacts.Count == 0)
            {
                Console.WriteLine("there is no contacts");
                return;
            }
            foreach (IContact contact in contacts)
            {
                Console.WriteLine(contact);
            }
            Console.ReadLine();
        }
        // view spesifc contact 
        private void ViewSpecificContact()
        {
            Console.WriteLine("Enter the name you try to find ");
            string FirstName = Console.ReadLine() ?? "";
            var contactsWithSameFirstName = contacts.Where(x => x.FirstName == FirstName);
            if (contactsWithSameFirstName.Count() == 0)
            {
                Console.WriteLine("There is no contact has this name ");
                return;
            }
            foreach (IContact contact in contactsWithSameFirstName)
            {
                Console.WriteLine(contact);
            }
        }
        // delete contact
        // if we have the several same first name inside address bok the program will delete the first name saved but it more professional to use Id like Guid to solution this problem  
        private void DeleteSpecificContact()
        {
            Console.WriteLine("Enter the name of contacts you want to delete ");
            string FirstName = Console.ReadLine() ?? "";
            var contact = contacts.Find(x => x.FirstName == FirstName);
            if (contact != null)
            {
                Console.WriteLine("Are you sure you want to delete it? Write 'yes' if yes:");
                string anser = Console.ReadLine() ?? "".Trim();
                if (string.Compare(anser, "yes", true) == 0)
                {
                    contacts.Remove((IContact)contact);
                    Console.WriteLine("Contact has been deleted successfully");
                    return;
                }
                else
                {

                    Console.WriteLine("Deletion cancelled");
                    return;
                }

            }

            Console.WriteLine("There is no contact has this name ");
        }

        // the code will delete all contacts have the same first name *******


        //private void DeleteSpecificContact()
        //{
        //    Console.WriteLine("Enter the name of contacts you want to delete ");
        //    string FirstName = Console.ReadLine() ?? "";
        //    var contactsWithSameFirstName = contacts.Where(x => x.FirstName == FirstName);
        //    if (contactsWithSameFirstName.Count() == 0)
        //    {
        //        Console.WriteLine("There is no contact has this name ");
        //        return;
        //    }
        //    Console.WriteLine("Are you sure you want to delete it? Write 'yes' if yes:");
        //    string anser = Console.ReadLine() ?? "".Trim();
        //    if (string.Compare(anser, "yes", true) == 0)
        //    {
        //        for (int i = contacts.Count - 1; i >= 0; i--)
        //        {
        //            if (contacts[i].FirstName == FirstName)
        //            {
        //                contacts.RemoveAt(i);
        //            }
        //        }
        //        Console.WriteLine("Contacts has been deleted successfully");
        //        return;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Deletion cancelled");
        //        return;
        //    }
        //}

        // update contact s
        private void UpdateSpecificContact()
        {
            Console.WriteLine("Enter the name of contacts you want to Update");
            string FirstNane = Console.ReadLine() ?? "";
            var contact = contacts.Find(x => x.FirstName == FirstNane);
            if (contact == null)
            {
                Console.WriteLine("There is no contact has this name");
                return;
            }
            Console.WriteLine("Enter new First Name:");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter new Last Name:");
            contact.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter new Email:");
            contact.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Enter new Phone Number:");
            contact.PhoneNumber = Console.ReadLine() ?? "";
            Console.WriteLine("Enter new streetName:");
            contact.StreetName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter new country:");
            contact.Country = Console.ReadLine() ?? "";

            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
            Console.WriteLine("Contact has been updated successfully.");
        }
    }
}
