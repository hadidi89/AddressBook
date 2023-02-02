using AddressBook_G.Services;

var menu = new MenuManager();
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";


while (true)
{
    Console.Clear();
    menu.WelcomMenuManager();
    Console.ReadLine();
    Console.Clear();
}