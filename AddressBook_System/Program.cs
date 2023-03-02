﻿using System;

namespace AddressBook_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook ab = new AddressBook();
            bool t = true;
            while (t)
            {
                Console.WriteLine("1.Add Contact \n2.View Contacts \n3.Edit Contacts \n4.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        ab.AddContact();
                        break;
                    case 2:
                        ab.DisplayContact();
                        break;
                    case 3:
                        Console.WriteLine("Enter the firstname to edit ");
                        string firstName = Console.ReadLine();
                        ab.EditContact(firstName);
                        break;

                }
            }
            
            
        }
    }
}
