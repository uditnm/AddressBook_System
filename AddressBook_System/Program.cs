using System;

namespace AddressBook_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook addressbook = new AddressBook();
            AddressBooks addressbooks = new AddressBooks();

            bool t = true;
            while (t)
            {
                Console.WriteLine("\n1.Add Contact \n2.View Contacts \n3.Edit Contacts \n4.Delete Contact " +
                    "\n5.Add new AddressBook \n6.Search for people in a city or state \n7.View persons by city " +
                    "\n8.View persons by state \n9.Display count by city \n10.Display count by state \n11.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        addressbook.AddContact(addressbooks);
                        break;
                    case 2:
                        addressbook.DisplayContact();
                        break;
                    case 3:
                        Console.WriteLine("Enter the firstname to edit ");
                        string firstName = Console.ReadLine();
                        addressbook.EditContact(firstName);
                        break;
                    case 4:
                        Console.WriteLine("Enter the firstname to delete ");
                        string name = Console.ReadLine();
                        addressbook.DeleteContact(name);
                        break;
                    case 5:
                        Console.WriteLine("Enter name for address book");
                        string addressbookname = Console.ReadLine();
                        addressbooks.AddToAddressBook(addressbookname, addressbook.contacts);
                        break;
                    case 6:
                        Console.WriteLine("Enter the city or state name: ");
                        string place = Console.ReadLine();
                        addressbooks.SearchbyCityorState(place);
                        break;
                    case 7:
                        addressbooks.DisplayByCity();
                        break;
                    case 8:
                        addressbooks.DisplayByState();
                        break;
                    case 9:
                        addressbooks.CountbyCity();
                        break;
                    case 10:
                        addressbooks.CountbyState();
                        break;
                    case 11:
                        t = false;
                        break;

                }
            }
            
            
        }
    }
}
