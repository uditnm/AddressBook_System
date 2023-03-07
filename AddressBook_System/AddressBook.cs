using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    public class AddressBook
    {
        public List<Contacts> contacts = new List<Contacts>();
        string constring = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
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

            Contacts contact = new Contacts(firstName, lastName, address, city, state, zip, phoneno, email);

            if (CheckDuplicate(contact))
            {
                Console.WriteLine("Name already exists!");
            }
            else
            {
                contacts.Add(contact);
                AddContactToDB(contact);
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

        public void ReadContactFromDB()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constring);
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spViewAddresses";

                con.Open();
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("firstName: " + sdr["firstname"]);
                    Console.WriteLine("lastName: " + sdr["lastname"]);
                    Console.WriteLine("address: " + sdr["address"]);
                    Console.WriteLine("city: " + sdr["city"]);
                    Console.WriteLine("state: " + sdr["state"]);
                    Console.WriteLine("zip: " + sdr["zip"]);
                    Console.WriteLine("phone number: " + sdr["phonenumber"]);
                    Console.WriteLine("email: " + sdr["email"]);
                    Console.WriteLine("date added: " + sdr["add_date"]);
                    Console.WriteLine();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void AddContactToDB(Contacts contact)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constring);

                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spEnterAddress";

               
                SqlParameter firstname = new SqlParameter("@firstname", SqlDbType.VarChar);
                SqlParameter lastname = new SqlParameter("@lastname", SqlDbType.VarChar);
                SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar);
                SqlParameter city = new SqlParameter("@city", SqlDbType.VarChar);
                SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar);
                SqlParameter zip = new SqlParameter("@zip", SqlDbType.BigInt);
                SqlParameter phonenumber = new SqlParameter("@phonenumber", SqlDbType.BigInt);
                SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
                SqlParameter add_date = new SqlParameter("@add_date",SqlDbType.DateTime);
                
                
                comm.Parameters.Add(firstname);
                comm.Parameters.Add(lastname);
                comm.Parameters.Add(address);
                comm.Parameters.Add(city);
                comm.Parameters.Add(state);
                comm.Parameters.Add(zip);
                comm.Parameters.Add(phonenumber);
                comm.Parameters.Add(email);
                comm.Parameters.Add(add_date);
                
                DateTime date = DateTime.Now;

                firstname.Value = contact.firstname;
                lastname.Value = contact.lastname;
                address.Value = contact.address;
                city.Value = contact.city;
                state.Value = contact.state;
                zip.Value = contact.zip;
                phonenumber.Value = contact.phoneno;
                email.Value = contact.email;
                add_date.Value = date;

                con.Open();
                comm.ExecuteNonQuery();

                Console.WriteLine("Contact Added");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();   
            }
        }

        public void UpdateContactInDB(Contacts contact,string oldfirstname, string oldlastname)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constring);

                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spUpdateAddress";

                SqlParameter oldFirstName = new SqlParameter("@oldfirstname", SqlDbType.VarChar);
                SqlParameter oldLastName = new SqlParameter("@oldlastname", SqlDbType.VarChar);
                SqlParameter firstname = new SqlParameter("@firstname", SqlDbType.VarChar);
                SqlParameter lastname = new SqlParameter("@lastname", SqlDbType.VarChar);
                SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar);
                SqlParameter city = new SqlParameter("@city", SqlDbType.VarChar);
                SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar);
                SqlParameter zip = new SqlParameter("@zip", SqlDbType.BigInt);
                SqlParameter phonenumber = new SqlParameter("@phonenumber", SqlDbType.BigInt);
                SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
                SqlParameter add_date = new SqlParameter("@add_date", SqlDbType.DateTime);

                comm.Parameters.Add(oldFirstName);
                comm.Parameters.Add(oldLastName);
                comm.Parameters.Add(firstname);
                comm.Parameters.Add(lastname);
                comm.Parameters.Add(address);
                comm.Parameters.Add(city);
                comm.Parameters.Add(state);
                comm.Parameters.Add(zip);
                comm.Parameters.Add(phonenumber);
                comm.Parameters.Add(email);
                comm.Parameters.Add(add_date);


                DateTime date = DateTime.Now;

                oldFirstName.Value = oldfirstname;
                oldLastName.Value = oldlastname;
                firstname.Value = contact.firstname;
                lastname.Value = contact.lastname;
                address.Value = contact.address;
                city.Value = contact.city;
                state.Value = contact.state;
                zip.Value = contact.zip;
                phonenumber.Value = contact.phoneno;
                email.Value = contact.email;
                add_date.Value = date;

                con.Open();
                comm.ExecuteNonQuery();
                Console.WriteLine("Contact Updated");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();

            }
        }

        public void EditContact(string firstname, string lastname)
        {
            foreach(Contacts contact in contacts)
            {
                if(contact.firstname==firstname && contact.lastname==lastname)
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

                    UpdateContactInDB(contact,firstname,lastname);

                    break;
                }
            }

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
        }


        public void DisplayContact()
        {
            int id = 1;
            foreach(Contacts contact in contacts)
            {
                Console.WriteLine("Contact {0}", id);
                Console.WriteLine(contact.ToString());
                Console.WriteLine("\n");
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

        public void RetrieveByDate()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constring);
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spAddressesByDate";

                SqlParameter period = new SqlParameter("@period", SqlDbType.DateTime);
                comm.Parameters.Add(period);
                DateTime date = PromptDateTime();
                period.Value = date;

                con.Open();
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine("firstName: " + sdr["firstname"]);
                    Console.WriteLine("lastName: " + sdr["lastname"]);
                    Console.WriteLine("address: " + sdr["address"]);
                    Console.WriteLine("city: " + sdr["city"]);
                    Console.WriteLine("state: " + sdr["state"]);
                    Console.WriteLine("zip: " + sdr["zip"]);
                    Console.WriteLine("phone number: " + sdr["phonenumber"]);
                    Console.WriteLine("email: " + sdr["email"]);
                    Console.WriteLine("date added: " + sdr["add_date"]);
                    Console.WriteLine();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public DateTime PromptDateTime()
        {
            Console.WriteLine("Day: ");
            var day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Month: ");
            var month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Year: ");
            var year = Convert.ToInt32(Console.ReadLine());

            return new DateTime(year, month, day);
        }

        public void GetCountByCity()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constring);
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spAddressCountByCity";

                SqlParameter city = new SqlParameter("@city", SqlDbType.VarChar);
                comm.Parameters.Add(city);
                Console.WriteLine("Enter the city ");
                string cityname = Console.ReadLine();
                city.Value = cityname;

                con.Open();
                int addresscount = (int)comm.ExecuteScalar();
                Console.WriteLine(addresscount);
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void GetCountByState()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constring);
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spAddressCountByState";

                SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar);
                comm.Parameters.Add(state);
                Console.WriteLine("Enter the state ");
                string statename = Console.ReadLine();
                state.Value = statename;

                con.Open();
                int addresscount = (int)comm.ExecuteScalar();
                Console.WriteLine(addresscount);
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
