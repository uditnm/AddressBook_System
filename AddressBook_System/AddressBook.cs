﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBook
    {
        List<Contacts> contacts = new List<Contacts>();
        public void AddContact()
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
            contacts.Add(contact);
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

            Console.WriteLine("The name wasn't found");
        }


        public void DisplayContact()
        {
            int id = 1;
            foreach(Contacts contact in contacts)
            {
                Console.WriteLine("Contact {0}", id);
                Console.WriteLine("firstName: "+contact.firstname);
                Console.WriteLine("lastName: "+contact.lastname);
                Console.WriteLine("address: "+contact.address);
                Console.WriteLine("city: "+contact.city);
                Console.WriteLine("state: "+contact.state);
                Console.WriteLine("zip: "+contact.zip);
                Console.WriteLine("phone number: "+contact.phoneno);
                Console.WriteLine("email: "+contact.email);
                Console.WriteLine("\n");
                id++;
            }
            
        }

    }
}