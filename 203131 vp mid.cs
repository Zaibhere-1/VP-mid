using System;

using System.Collections.Generic;

namespace StudentClubManagementSystem
{
    class Program
    {
        static List<Society> societies = new List<Society>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nStudent Club Management System");
                Console.WriteLine("1. Register New Society");
                Console.WriteLine("2. Allocate Funding");
                Console.WriteLine("3. View All Societies");
                Console.WriteLine("4. Update Society Details");
                Console.WriteLine("5. Event Management");
                Console.WriteLine("6. Report");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterNewSociety();
                        break;
                    case "2":
                        AllocateFunding();
                        break;
                    case "3":
                        ViewAllSocieties();
                        break;
                    case "4":
                        UpdateSocietyDetails();
                        break;
                    case "5":
                        EventManagement();
                        break;
                    case "6":
                        ReportsAndStatistics();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void RegisterNewSociety()
        {
            Console.Write("Enter Society Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Society President: ");
            string president = Console.ReadLine();

            Society newSociety = new Society(name, president);
            societies.Add(newSociety);

            Console.WriteLine("Society registered successfully.");
        }

        static void AllocateFunding()
        {
            Console.Write("Enter Society Name: ");
            string name = Console.ReadLine();

            Society society = societies.Find(s => s.Name == name);

            if (society != null)
            {
                Console.Write("Enter Funding Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    society.Funding += amount;
                    Console.WriteLine("Funding allocated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }

        static void ViewAllSocieties()
        {
            Console.WriteLine("\nList of Registered Societies:");
            foreach (var society in societies)
            {
                Console.WriteLine($"Name: {society.Name}, President: {society.President}, Funding: ${society.Funding}");
            }
        }

        static void UpdateSocietyDetails()
        {
            Console.Write("Enter Society Name to Update: ");
            string name = Console.ReadLine();

            Society society = societies.Find(s => s.Name == name);

            if (society != null)
            {
                Console.Write("Enter New President Name: ");
                society.President = Console.ReadLine();
                Console.WriteLine("Society details updated successfully.");
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }

        static void EventManagement()
        {
            Console.Write("Enter Society Name: ");
            string name = Console.ReadLine();

            Society society = societies.Find(s => s.Name == name);

            if (society != null)
            {
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();
                Console.Write("Enter Event Date (yyyy-mm-dd): ");
                string eventDate = Console.ReadLine();

                society.Events.Add(new Event(eventName, eventDate));
                Console.WriteLine("Event added successfully.");
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }

        static void ReportsAndStatistics()
        {
            Console.WriteLine("\nReports & Statistics:");
            foreach (var society in societies)
            {
                Console.WriteLine($"\nSociety: {society.Name}, Funding: ${society.Funding}");
                Console.WriteLine("Events:");
                foreach (var ev in society.Events)
                {
                    Console.WriteLine($"- {ev.Name} on {ev.Date}");
                }
            }
        }
    }

    class Society
    {
        public string Name { get; set; }
        public string President { get; set; }
        public decimal Funding { get; set; }
        public List<Event> Events { get; set; }

        public Society(string name, string president)
        {
            Name = name;
            President = president;


        }
    }

    class Event
    {
        public string Name { get; set; }
        public string Date { get; set; }

        public Event(string name, string date)
        {
            Name = name;
            Date = date;
        }
    }
}
