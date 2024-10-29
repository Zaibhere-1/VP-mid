using System;
using System.Collections.Generic;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Role { get; set; }

    public Student(int studentId, string name, int age, string role = "Member")
    {
        StudentId = studentId;
        Name = name;
        Age = age;
        Role = role;
    }

    public override string ToString()
    {
        return $"ID: {StudentId}, Name: {Name}, Age: {Age}, Role: {Role}";
    }
}

class Club
{
    public string Name { get; set; }
    private List<Student> Members { get; set; }

    public Club(string name)
    {
        Name = name;
        Members = new List<Student>();
    }

    public void AddMember(Student student)
    {
        Members.Add(student);
        Console.WriteLine($"{student.Name} has been added to {Name}.");
    }

    public void RemoveMember(int studentId)
    {
        var student = Members.Find(m => m.StudentId == studentId);
        if (student != null)
        {
            Members.Remove(student);
            Console.WriteLine($"{student.Name} has been removed from {Name}.");
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }

    public void DisplayMembers()
    {
        if (Members.Count == 0)
        {
            Console.WriteLine("No members in the club.");
        }
        else
        {
            foreach (var member in Members)
            {
                Console.WriteLine(member);
            }
        }
    }

    public void AssignRole(int studentId, string newRole)
    {
        var student = Members.Find(m => m.StudentId == studentId);
        if (student != null)
        {
            student.Role = newRole;
            Console.WriteLine($"{student.Name}'s role has been updated to {newRole}.");
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }

    public void FindMember(int studentId)
    {
        var student = Members.Find(m => m.StudentId == studentId);
        if (student != null)
        {
            Console.WriteLine(student);
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Club club = new Club("Student Club");

        while (true)
        {
            Console.WriteLine("\nStudent Club Management System");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Remove Member");
            Console.WriteLine("3. Display All Members");
            Console.WriteLine("4. Assign Role");
            Console.WriteLine("5. Find Member by ID");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option     : ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter Student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    club.AddMember(new Student(id, name, age));
                    break;

                case 2:
                    Console.Write("Enter Student ID to remove: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    club.RemoveMember(id);
                    break;

                case 3:
                    club.DisplayMembers();
                    break;

                case 4:
                    Console.Write("Enter Student ID to assign role: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter New Role: ");
                    string role = Console.ReadLine();
                    club.AssignRole(id, role);
                    break;

                case 5:
                    Console.Write("Enter Student ID to find: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    club.FindMember(id);
                    break;

                case 6:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}