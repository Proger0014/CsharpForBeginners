using System;
using System.Collections.Generic;
using System.Linq;

namespace Game21
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Contact> contacts = new Dictionary<string, Contact>();

            contacts.Add("Игорь", new Contact("Игорь", "Игоревич", "+71232281337"));
            contacts.Add("Игорь2", new Contact("Игорь", "Игоревич", "+71232283337"));
            contacts.Add("Игорь3", new Contact("Игорь", "Игоревич", "+78934281337"));
            contacts.Add("Игорь4", new Contact("Игорь", "Игоревич", "8 965 348 1337"));

            contacts["Игорь4"].GetInfo();
        }
    }
}
