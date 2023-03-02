using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class Contacts
    {
        public string firstname, lastname, email, address, city, state;
        public int zip;
        public long phoneno;

        public Contacts(string firstname, string lastname, string address, string city, string state, int zip, long phoneno, string email)
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
