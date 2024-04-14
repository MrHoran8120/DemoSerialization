using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StudentSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a list of students
            List<Student> students = new List<Student>
            {
                new Student { Name = "Alice", StudentNumber = 1, Age = 20 },
                new Student { Name = "Bob", StudentNumber = 2, Age = 21 },
                new Student { Name = "Charlie", StudentNumber = 3, Age = 22 }
            };

            // Serializing the list and writing to a file
            string filePath = "students.json";
            SerializeListToFile(students, filePath);
            Console.WriteLine($"Serialized List written to file: {filePath}");

            // Deserializing the list from the file
            List<Student> deserializedList = DeserializeListFromFile(filePath);
            Console.WriteLine("\nDeserialized List:");
            foreach (var student in deserializedList)
            {
                Console.WriteLine($"Name: {student.Name}, StudentNumber: {student.StudentNumber}, Age: {student.Age}");
            }

            Console.ReadLine();
        }

        static void SerializeListToFile(List<Student> students, string filePath)
        {
            string serializedList = JsonSerializer.Serialize(students);
            File.WriteAllText(filePath, serializedList);
        }

        static List<Student> DeserializeListFromFile(string filePath)
        {
            string serializedList = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Student>>(serializedList);
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int StudentNumber { get; set; }
        public int Age { get; set; }
    }
}
