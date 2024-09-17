using System.Collections.Specialized;
using System.Formats.Asn1;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using ZooManagement.EFPerisistance;
using ZooManagement.EFPerisistance.Sections;
using ZooManagement.EFPerisistance.Zoos;
using ZooManagement.Entities;
using ZooManagement.Migrations;

var context = new EfDataContext();
var zooRepository = new EfZooRepository(context);
var sectionsRepository = new EfSectionRepository(context);

while (true)
{
    try
    {
        Run();

    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

void Run()
{
    Console.WriteLine("1- Add zoo\n" +
                      "2- CreateSections\n" +
                      "3- ViewZoo\n" +
                      "4- ViewAllSections\n" +
                      "5- AddSectionsToZoo\n");

    Console.WriteLine("Please choose an option:");
    var option = Console.ReadLine();
    switch (option)
    {
        case "1" : 
            try
            {
                AddZoo();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            break;
        case "2":
        {
            CreateSections();
        }
            break;
        case "3":
        {
            ViewZoo();
        }
        break;
        case"4" :
        {
            ViewAllSections();
        }
            break;
        case "5":
        {
            AddSectionsToZoo();
        }
            break;
        case "6":
        {
            DeleteSections();
        }
            break;
    }
}

//services

void AddZoo()
{
    Console.WriteLine("Enter Zoo name");
    var ZooName = Console.ReadLine();
    var ZooAddress = Console.ReadLine();
    var Zoo = new Zoo()
    {
        Name = ZooName,
        Address = ZooAddress

    };
    zooRepository.Add(Zoo);
    context.SaveChanges();
    Console.WriteLine(Zoo.Id);
}

void CreateSections()
{
    Console.WriteLine("Enter Area:");
    var area = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(area))
    {
        throw new Exception();
    }
    Console.WriteLine("Enter name of animal:");
    var nameofAnimal = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nameofAnimal))
    {
        throw new Exception();
    }
    
    Console.WriteLine("Enter number of animal:");
    var numberOfAnimal = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(numberOfAnimal))
    {
        throw new Exception();
    }
    
    Console.WriteLine("Enter captions:");
    var captions = Console.ReadLine();
   
    var section = new Section()
    {
       Area = area,
       NameOfAnimal = nameofAnimal,
       NumberOfAnimal = numberOfAnimal,
       Captions = captions
    };
   sectionsRepository.Add(section);
   context.SaveChanges();

}

void ViewZoo()
{
    var zoos = zooRepository.GetAll();
    foreach (var zoo in zoos)
    {
        Console.WriteLine($"{zoo.Id} - {zoo.Name}");
    }
}

object sectionRepository;

void AddSectionsToZoo()
{
    ViewAllSections();
    Console.WriteLine("select sections id");
    int.TryParse(Console.ReadLine(), out int sectionId);
    var section = sectionsRepository.GetById(sectionId);
    if (section is null)
    {
        throw new Exception();
    }
    ViewZoo();
    Console.WriteLine("select zoo id");
    int.TryParse(Console.ReadLine(), out int zooId);
    if (!zooRepository.DoesZooExistById(zooId))
    {
        throw new Exception();
    }
    section.ZooId = zooId;
    context.SaveChanges();
}

void ViewAllSections()
{
    var sections =
        sectionsRepository.GetAll();

    foreach (var section  in sections)
    {
        Console.WriteLine($"{section.SectionId} - {section.Area} {section.NameOfAnimal} " +
                          $"- number of animal: {section.NumberOfAnimal} " +
                          $"- captions: {section.Captions} " +
                          $"- zoo name: {section.ZooName}");
    }

    Console.ReadKey();
}



void DeleteSections()
{
    ViewAllSections();
    Console.WriteLine("select section id");
    int.TryParse(Console.ReadLine(), out int sectionsId);
    var section = sectionsRepository.GetById(sectionsId);
    if (section is null)
    {
        throw new Exception();
    }
    sectionsRepository.Remove(section);
    context.SaveChanges();
}





    