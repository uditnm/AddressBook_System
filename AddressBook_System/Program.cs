using System;

namespace AddressBook_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook ab = new AddressBook();

            Console.WriteLine("1.Add Contact \n2.View Contacts");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    ab.AddContact();
                    break;
                /*case 2:
                    ab.DisplayContact();
                    break;
                */
            }


        }
    }
}
