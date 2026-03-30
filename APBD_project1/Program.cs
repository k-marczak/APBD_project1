using APBD_project1.Models;
using APBD_project1.Services;

var service = new BusinessLogic();

//                                  1). Scenariusze demonstracyjne. 

Console.WriteLine("Cześć 1. Scenariusze demonstracyjne. ");

// Dodanie kilku egzemplarzy sprzętu różnych typów 
Console.WriteLine("=====Dodanie kilku egzemplarzy sprzętu różnych typów=====");
var laptop1 = new Laptop("Dell XPS", "RTX4070", "i7");
var laptop2 = new Laptop("HP Solid", "RTX5090", "i5");
var camera1 = new Camera("Canon", 24, true);
var camera2 = new Camera("Kodak", 16, false);
var projector1 = new Projector("Epson EB-FH08", 48, false);
var projector2 = new Projector("Samsung Whale Pro", 64, true);

service.AddDevice(laptop1);
service.AddDevice(laptop2);
service.AddDevice(camera1);
service.AddDevice(camera2);
service.AddDevice(projector1);
service.AddDevice(projector2);


// Dodanie kilku użytkowników różnych typów. 
Console.WriteLine("=====Dodanie kilku użytkowników różnych typów=====");
var student1 = new Student("Jan", "Nowak");
var student2 = new Student("Barbara", "Michalska");
var employee1 = new Employee("Michał", "Zdun");
var employee2 = new Employee("Rupert", "Kowalski");

service.AddUser(student1);
service.AddUser(student2);
service.AddUser(employee1);
service.AddUser(employee2);

// Poprawne wypożyczenie sprzętu.
Console.WriteLine("=====Poprawne wypożyczenie sprzętu=====");
service.RentDevice(student1.Id, laptop1.Id, 4);
service.RentDevice(employee1.Id, laptop2.Id, 2);
service.RentDevice(student2.Id, camera1.Id, 8);
service.RentDevice(student1.Id, projector2.Id, 8);


// Próbę wykonania niepoprawnej operacji, np. wypożyczenia sprzętu niedostępnego albo przekroczenia limitu.
//--- Sprzęt niedostępny 
Console.WriteLine("=====Sprzęt niedostępny=====");
service.RentDevice(employee1.Id, laptop1.Id, 8);
service.RentDevice(student2.Id, laptop2.Id, 8);
//---- Przekroczenie limitu 
Console.WriteLine("=====Przekroczenie limitu=====");
service.RentDevice(student1.Id, projector1.Id, 8);
service.RentDevice(student1.Id, camera2.Id, 8);


// Zwrot sprzętu w terminie. 
Console.WriteLine("=====Zwrot sprzętu w terminie=====");
service.ReturnDevice(laptop1.Id, DateTime.Now.AddDays(2));


// Zwrot opóźniony skutkujący naliczeniem kary. 
Console.WriteLine("=====Zwrot opóźniony skutkujący naliczeniem kary=====");
service.ReturnDevice(laptop2.Id, DateTime.Now.AddDays(4));


// Wyświetlenie raportu końcowego o stanie systemu.
Console.WriteLine("=====Wyświetlenie raportu końcowego o stanie systemu=====");
service.PrintReport();
 
 
 
 //                                         2). Wymagania funkcjonalne 

 
// Dodanie nowego użytkownika do systemu. 
Console.WriteLine("=====Dodanie nowego użytkownika do systemu=====");
var student3 = new Student("Maciej", "Nowacki");
service.AddUser(student3);

 
// Dodanie nowego sprzętu danego typu.
Console.WriteLine("=====Dodanie nowego sprzętu danego typu=====");
var laptop3 = new Laptop("Hyperbook", "RTX 2010", "i9");
service.AddDevice(laptop3);
 
// Wyświetlenie listy całego sprzętu z aktualnym statusem.
Console.WriteLine("=====Wyświetlenie listy całego sprzętu z aktualnym statusem=====");
service.PrintAllDevices();


// Wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia.
Console.WriteLine("=====Wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia=====");
service.PrintAvailableDevices();
 
 
// Wypożyczenie sprzętu użytkownikowi.
Console.WriteLine("=====Wypożyczenie sprzętu użytkownikowi=====");
service.RentDevice(student3.Id, laptop3.Id, 3);


 
// Zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie.
Console.WriteLine("=====Zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie=====");
service.ReturnDevice(laptop3.Id, DateTime.Now.AddDays(5));


 
// Oznaczenie sprzętu jako niedostępnego, np. z powodu uszkodzenia lub serwisu.
Console.WriteLine("=====Oznaczenie sprzętu jako niedostępnego, np. z powodu uszkodzenia lub serwisu=====");
service.MarkDeviceAsUnavailable(laptop3.Id);

 
// Wyświetlenie aktywnych wypożyczeń danego użytkownika.
Console.WriteLine("=====Wyświetlenie aktywnych wypożyczeń danego użytkownika=====");
service.PrintActiveRentalsByUser(student1.Id);

 
 
// Wyświetlenie listy przeterminowanych wypożyczeń.
Console.WriteLine("=====Wyświetlenie listy przeterminowanych wypożyczeń=====");
service.RentDevice(student3.Id, laptop1.Id, -3); // -> Minus Days aby zasymulować Overdue
service.PrintOverdueRentals();
service.ReturnDevice(laptop1.Id, DateTime.Now);

 
// Wygenerowanie krótkiego raportu podsumowującego stan wypożyczalni.
Console.WriteLine("=====Wygenerowanie krótkiego raportu podsumowującego stan wypożyczalni=====");
service.PrintReport();