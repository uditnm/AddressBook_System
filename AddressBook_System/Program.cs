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
                    "\n5.Add new AddressBook \n6.View Address books \n7.Search for people in a city or state \n8.View persons by city " +
                    "\n9.View persons by state \n10.Display count by city \n11.Display count by state \n12.Sort " +
                    "person details by name \n13.Sort person details by place \n14.Write Address Book to file \n15.Read Address " +
                    "Book from file \n16.Write Address Book to CSV File \n17.Write Address Book to JSON file \n18.Read Address from JSON file " +
                    "\n19.Read from Database \n20.Retrieve Addresses by Date \n21.Get Adddress Count for a city \n22.Get Address Count for a state " +
                    "\n23.Exit");
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
                        string lastName = Console.ReadLine();
                        addressbook.EditContact(firstName,lastName);
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
                        addressbook.contacts.Clear();
                        break;
                    case 6:
                        addressbooks.DisplayAddressBooks();
                        break;
                    case 7:
                        Console.WriteLine("Enter the city or state name: ");
                        string place = Console.ReadLine();
                        addressbooks.SearchbyCityorState(place);
                        break;
                    case 8:
                        addressbooks.DisplayByCity();
                        break;
                    case 9:
                        addressbooks.DisplayByState();
                        break;
                    case 10:
                        addressbooks.CountbyCity();
                        break;
                    case 11:
                        addressbooks.CountbyState();
                        break;
                    case 12:
                        addressbook.SortContacts();
                        break;
                    case 13:
                        addressbook.SortContactsbyPlace();
                        break;
                    case 14:
                        addressbooks.WriteToFile();
                        break;
                    case 15:
                        addressbooks.ReadFromFile();
                        break;
                    case 16:
                        addressbooks.WriteToCSVFile();
                        break;
                    case 17:
                        addressbooks.WriteToJSONFile();
                        break;
                    case 18:
                        addressbooks.ReadFromJSONFile();
                        break;
                    case 19:
                        addressbook.ReadContactFromDB();
                        break;
                    case 20:
                        addressbook.RetrieveByDate();
                        break;
                    case 21:
                        addressbook.GetCountByCity();
                        break;
                    case 22:
                        addressbook.GetCountByState();
                        break;
                    case 23:
                        t = false;
                        break;

                }
            }
        }
    }
}
