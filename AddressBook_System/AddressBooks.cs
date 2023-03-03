using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBooks
    {
        Dictionary<string, List<Contacts>> addressbook = new Dictionary<string, List<Contacts>>();
        public Dictionary<string, List<Contacts>> cityContacts = new Dictionary<string, List<Contacts>>();
        public Dictionary<string, List<Contacts>> stateContacts = new Dictionary<string, List<Contacts>>();


        public void AddToAddressBook(string name, AddressBook contact)
        {
            addressbook.Add(name, contact.contacts);
            contact.contacts.Clear();

        }

        public void DisplayAddressBooks()
        {
            foreach(var contacts in addressbook)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine("---------------------");
                foreach (Contacts contact in contacts.Value)
                {
                    Console.WriteLine("firstName: " + contact.firstname);
                    Console.WriteLine("lastName: " + contact.lastname);
                    Console.WriteLine("address: " + contact.address);
                    Console.WriteLine("city: " + contact.city);
                    Console.WriteLine("state: " + contact.state);
                    Console.WriteLine("zip: " + contact.zip);
                    Console.WriteLine("phone number: " + contact.phoneno);
                    Console.WriteLine("email: " + contact.email);
                    Console.WriteLine("\n");
                }
            }
        }

        public void SearchbyCityorState(string placename)
        {
            foreach(var contacts in addressbook.Values)
            {
                foreach(Contacts contact in contacts)
                {
                    if(contact.city==placename || contact.state == placename)
                    {
                        Console.WriteLine("firstName: " + contact.firstname);
                        Console.WriteLine("lastName: " + contact.lastname);
                        Console.WriteLine("address: " + contact.address);
                        Console.WriteLine("city: " + contact.city);
                        Console.WriteLine("state: " + contact.state);
                        Console.WriteLine("zip: " + contact.zip);
                        Console.WriteLine("phone number: " + contact.phoneno);
                        Console.WriteLine("email: " + contact.email);
                        Console.WriteLine("\n");
                    }
                }
            }
        }

        public void DisplayByCity()
        {
            foreach(var contacts in cityContacts)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine("---------------------");
                foreach (Contacts contact in contacts.Value)
                {
                    Console.WriteLine("firstName: " + contact.firstname);
                    Console.WriteLine("lastName: " + contact.lastname);
                    Console.WriteLine("address: " + contact.address);
                    Console.WriteLine("city: " + contact.city);
                    Console.WriteLine("state: " + contact.state);
                    Console.WriteLine("zip: " + contact.zip);
                    Console.WriteLine("phone number: " + contact.phoneno);
                    Console.WriteLine("email: " + contact.email);
                    Console.WriteLine("\n");
                }
            }
        }

        public void DisplayByState()
        {
            foreach (var contacts in stateContacts)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine("---------------------");
                foreach (Contacts contact in contacts.Value)
                {
                    Console.WriteLine("firstName: " + contact.firstname);
                    Console.WriteLine("lastName: " + contact.lastname);
                    Console.WriteLine("address: " + contact.address);
                    Console.WriteLine("city: " + contact.city);
                    Console.WriteLine("state: " + contact.state);
                    Console.WriteLine("zip: " + contact.zip);
                    Console.WriteLine("phone number: " + contact.phoneno);
                    Console.WriteLine("email: " + contact.email);
                    Console.WriteLine("\n");
                }
            }
        }

        public void CountbyCity()
        {
            Console.WriteLine("Count by city: ");
            foreach (var contacts in cityContacts)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine(contacts.Value.Count);
            }
        }

        public void CountbyState()
        {
            Console.WriteLine("Count by state: ");
            foreach (var contacts in stateContacts)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine(contacts.Value.Count);
            }
        }
    }
}
