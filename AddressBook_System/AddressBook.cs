using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBook
    {
        public List<Contacts> contacts = new List<Contacts>();
        public void AddContact(AddressBooks addressbooks)
        {
            Console.WriteLine("Enter the firstName: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the lastName: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the city: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the state: ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter the zip: ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the phone number: ");
            long phoneno = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the email: ");
            string email = Console.ReadLine();

            Contacts contact = new Contacts(firstName, lastName, address, city, state,zip, phoneno,email);

            if (CheckDuplicate(contact))
            {
                Console.WriteLine("Name already exists!");
            }
            else
            {
                contacts.Add(contact);
                if(addressbooks.cityContacts.ContainsKey(city))
                {
                    addressbooks.cityContacts[city].Add(contact);
                }
                else
                {
                    addressbooks.cityContacts.Add(city, new List<Contacts>{ contact});
                }

                if (addressbooks.stateContacts.ContainsKey(state))
                {
                    addressbooks.stateContacts[state].Add(contact);
                }
                else
                {
                    addressbooks.stateContacts.Add(state, new List<Contacts> { contact });
                }

                
            }
            
        }

        public void EditContact(string firstname)
        {
            foreach(Contacts contact in contacts)
            {
                if(contact.firstname==firstname)
                {
                    Console.WriteLine("Enter the firstName: ");
                    contact.firstname = Console.ReadLine();
                    Console.WriteLine("Enter the lastName: ");
                    contact.lastname = Console.ReadLine();
                    Console.WriteLine("Enter the address: ");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter the city: ");
                    contact.city = Console.ReadLine();
                    Console.WriteLine("Enter the state: ");
                    contact.state = Console.ReadLine();
                    Console.WriteLine("Enter the zip: ");
                    contact.zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the phone number: ");
                    contact.phoneno = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter the email: ");
                    contact.email = Console.ReadLine();

                    break;
                }
            }

            Console.WriteLine("The name was not found");
        }

        public void DeleteContact(string firstname)
        {
            foreach (Contacts contact in contacts)
            {
                if (contact.firstname == firstname)
                {
                    contacts.Remove(contact);
                    break;
                }
            }
            //Console.WriteLine("The name was not found");
        }


        public void DisplayContact()
        {
            int id = 1;
            foreach(Contacts contact in contacts)
            {
                Console.WriteLine("Contact {0}", id);
                Console.WriteLine(contact.ToString());
                id++;
            }
            
        }

        bool CheckDuplicate(Contacts newcontact)
        {
            foreach(Contacts contact in contacts)
            {
                if(contact.Equals(newcontact))
                {
                    return true;
                }
            }
            return false;
        }

        public void SortContacts()
        {
            contacts = contacts.OrderBy(contact => contact.firstname).ToList();
            DisplayContact();
        }

        public void SortContactsbyPlace()
        {
            Console.WriteLine("Sort by: \n1.City \n2.State \n3.Zip");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    contacts = contacts.OrderBy(contact => contact.city).ToList();
                    break;
                case 2:
                    contacts = contacts.OrderBy(contact => contact.state).ToList();
                    break;
                case 3:
                    contacts = contacts.OrderBy(contact => contact.zip).ToList();
                    break;
            }
            
            DisplayContact();
        }
    }
}
