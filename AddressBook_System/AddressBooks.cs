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
        public void AddToAddressBook(string name, List<Contacts> contacts)
        {
            addressbook.Add(name, contacts);
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
    }
}
