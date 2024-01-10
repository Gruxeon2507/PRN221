using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("Candidate")]
public class Person
{
    [XmlElement("FirstName")]
    public string Name { get; set; }
    [XmlElement("RoughAge")]
    public int Age { get; set; }
}//end class
class Program
{
    static void Main(string[] args)
    {
        // Create object Person
        Person p1 = new Person() { Name = "David", Age = 30 };
        var xs = new XmlSerializer(typeof(Person));
        //Serialize object Person into the file
        using Stream s1 = File.Create("person.xml");
        xs.Serialize(s1, p1);
        s1.Close();

        //Deserialize
        using Stream s2 = File.OpenRead("person.xml"); // read the file in Stream
        var p2 = (Person)xs.Deserialize(s2);           // Deserialize back in to object
        Console.WriteLine("****Person Info****");
        Console.WriteLine($"Name: {p2.Name}, Age: {p2.Age}");
        Console.WriteLine("****Person.xml****");
        string xmlData = File.ReadAllText("person.xml");
        Console.WriteLine(xmlData);
        s2.Close();
        Console.ReadLine();
    }//end Main
}//end Program
// Khởi tạo 1 file XML chứa sẵn 2 student. Sau đó thêm vào database 2 student đó
//Ghi toàn bỗ dữ liệu vào DB