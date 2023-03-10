using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    public class Contacts
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

        public override bool Equals(object? obj)
        {
            if(obj==null)
                return false;

            if(!(obj is Contacts)) return false;

            return (this.firstname == ((Contacts)obj).firstname) && (this.lastname == ((Contacts)obj).lastname);
        }

        public override string ToString()
        {
            return "firstName: " + firstname + "\n" + "lastName: " + lastname + "\n" +
                "address: " + address + "\n" + "city: " + city + "\n" + "state: " + state + "\n" +
                "zip: " + zip + "\n" + "phone number: " + phoneno + "\n" + "email: " + email;
            
        }
    }
}
