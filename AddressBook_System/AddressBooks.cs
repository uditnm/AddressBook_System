using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
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


        public void AddToAddressBook(string name, List<Contacts> contact)
        {
            List<Contacts> contacts = new List<Contacts>(contact);
            addressbook.Add(name, contacts);
        }

        public void DisplayAddressBooks()
        {
            foreach(var contacts in addressbook)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine("---------------------");
                foreach (var contact in contacts.Value)
                {
                    Console.WriteLine(contact.ToString());
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
                        contact.ToString();
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
                    Console.WriteLine(contact.ToString());
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
                    Console.WriteLine(contact.ToString());
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

        public void WriteToFile()
        {
            string filename = @"D:\bridgelabz\AddressBook_System\AddressBook_System\Addresses.txt";
            StreamWriter sw = new StreamWriter(filename);
            foreach (var contacts in addressbook)
            {
                sw.WriteLine(contacts.Key);
                sw.WriteLine("---------------------");
                foreach (Contacts contact in contacts.Value)
                {
                    sw.WriteLine(contact.ToString());
                    sw.WriteLine("\n");
                }
            }
            sw.Close();
        }

        public void ReadFromFile()
        {
            string filename = @"D:\bridgelabz\AddressBook_System\AddressBook_System\Addresses.txt";
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
                Console.WriteLine(line);
        }

        public void WriteToCSVFile()
        {
            string filename = @"D:\bridgelabz\AddressBook_System\AddressBook_System\Addresses.csv";
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var headings = new List<string>(addressbook.Keys);

                foreach (var heading in headings)
                {
                    csv.WriteField(heading);
                }

                csv.NextRecord();

                foreach (var item in addressbook)
                {
                    csv.WriteField(item.Value);
                }
                    

                    csv.NextRecord();
                
            }
        }

        public void WriteToJSONFile()
        {
            string jsonfile = @"D:\bridgelabz\AddressBook_System\AddressBook_System\Addresses.json";
            var json = JsonConvert.SerializeObject(addressbook);
            File.WriteAllText(jsonfile, json);
        }

        public void ReadFromJSONFile()
        {
            string jsonfile = @"D:\bridgelabz\AddressBook_System\AddressBook_System\Addresses.json";
            JObject jsoncontacts = JObject.Parse(File.ReadAllText(jsonfile));

            foreach (var contacts in jsoncontacts)
            {
                Console.WriteLine(contacts.Key);
                Console.WriteLine("---------------------");
                foreach (var contact in contacts.Value)
                {
                    foreach(var item in contact)
                    {
                        Console.WriteLine(item);
                    }
                    
                    Console.WriteLine("\n");
                }
            }

            
        }

        
    }
}
