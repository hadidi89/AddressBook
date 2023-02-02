using AddressBook_G.InterFaces;
using AddressBook_G.Models;
using AddressBook_G.Services;

namespace AddressBook_G_Tests.cs;

public class AddressBook_G_Tests
{

    private MenuManager menuManager;
    private Contact contact;


    public AddressBook_G_Tests()
    {
        menuManager= new MenuManager();
        contact= new Contact();
    }


    [Fact]
    public void Should_Add_Contact_To_List()
    {
        // act
        menuManager.contacts.Add(contact);

        // assert
        Assert.Single(menuManager.contacts);
    }

    [Fact]
    public void Should_Remove_Contact_From_List()
    {
        // arrange
        menuManager.contacts.Add(contact);
        menuManager.contacts.Add(contact);

        // act
        menuManager.contacts.Remove(contact);

        // assert
        Assert.Single(menuManager.contacts);
    }
}