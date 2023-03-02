using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class Contacts
    {
        string firstname, lastname, email, address, city, state;
        int phoneno, zip;

        public Contacts(string firstname, string lastname, string address, string city, string state, int zip, int phoneno, string email)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneno = phoneno;
            this.email = email;
        }
    }
}
