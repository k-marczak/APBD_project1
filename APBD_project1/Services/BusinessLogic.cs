using APBD_project1.Enums;
using APBD_project1.Models;

namespace APBD_project1.Services;

public class BusinessLogic
{
    private List<Device> _devices = new();
    private List<User> _users = new();
    private List<Rental> _rentals = new();

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<Device> GetAllDevices()             // -> Get All devices. 
    {
        return _devices;
    }

    public void PrintAllDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine(device);
        }
    }
    
    public void PrintAvailableDevices()     // -> Get available devices. 
    {
        foreach (var device in _devices)
        {
            if (device.Status == DeviceStatus.Available)
            {Console.WriteLine(device);}
        }
    }
    
    
    public void MarkDeviceAsUnavailable(int deviceId)
    {
        Device foundDevice = null;
        foreach (var device in _devices)
        {
            if (device.Id == deviceId)
            { foundDevice = device; }
        }
        if (foundDevice == null)
        {
            Console.WriteLine("Nie znaleziono urządzenia o takim Id.");
            return;
        }
        if (foundDevice.Status == DeviceStatus.Rented)
        {
            Console.WriteLine("Urządzenie o takim Id jest w statusie 'Wypożyczony'. ");
            return;
        }

        bool isCurrentlyRented = false;
        foreach (var rental in _rentals)
        {
            if (rental.Device.Id == deviceId && rental.IsActive)
            { isCurrentlyRented = true; }
        }

        if (isCurrentlyRented)
        {
            Console.WriteLine("Nie można oznaczyć jako 'Niedostępne' bo sprzęt jest aktualnie wypożyczony. ");
            return;
        }

        foundDevice.Status = DeviceStatus.Unavailable;
        Console.WriteLine("Sprzęt oznaczono jako niedostępny.");
    }
    
    public void RentDevice(int userId, int deviceId, int days)
    {   
        User foundUser = null;  // -> find user to rent. 
        foreach (var user in _users)
        {
            if (user.Id == userId)
            { foundUser = user; }
        }
        if (foundUser == null)
        {
            Console.WriteLine("Nie znaleziono użytkownika o takim Id.");
            return;
        }
        
        // find device to rent. 
        Device foundDevice = null;
        foreach (var device in _devices)
        {
            if (device.Id == deviceId)
            { foundDevice = device; }
        }
        if (foundDevice == null)
        {
            Console.WriteLine("Błąd: Nie znaleziono urządzenia o takim Id.");
            return;
        }
        if (foundDevice.Status != DeviceStatus.Available)
        {
            Console.WriteLine("Błąd: Urządzenie nie ma statusu 'dostępny'. ");
            return;
        }

        // find how many rentals, our user having. 
        int activeRentalsCount = 0;
        foreach (var rental in _rentals)
        {
            if (rental.User.Id == userId && rental.IsActive)
            { activeRentalsCount++; }
        }
        // If more than should, Error. 
        if (activeRentalsCount >= foundUser.MaxLoans)
        {
            Console.WriteLine("Użytkownik przekroczył limit wypożyczeń.");
            return;
        }
        
        // OK. Make a new Rental. 
        Rental newRental = new Rental(foundUser, foundDevice, days);
        _rentals.Add(newRental);
        foundDevice.Status = DeviceStatus.Rented;
        Console.WriteLine("Ok. Wypożyczono sprzęt pomyślnie.");
    }
    
    public void ReturnDevice(int deviceId, DateTime returnDate)
    {
        Rental activeRental = null;
        foreach (var rental in _rentals)
        {
            if (rental.Device.Id == deviceId && rental.IsActive)
            { activeRental = rental; }
        }
        if (activeRental == null)
        {
            Console.WriteLine("Nie znaleziono aktywnego wypożyczenia dla tego sprzętu.");
            return;
        }
        activeRental.Return(returnDate);
        activeRental.Device.Status = DeviceStatus.Available;
        decimal penalty = activeRental.CalculatePenalty();
        Console.WriteLine("Sprzęt został zwrócony.");
        if (penalty > 0)
        { Console.WriteLine("Kara za spóźnienie: " + penalty + " zł"); }
        else
        { Console.WriteLine("Zwrot był w terminie."); }
    }
    
    public void PrintActiveRentalsByUser(int userId)
    {
        foreach (var rental in _rentals)
        {
            if (rental.User.Id == userId && rental.IsActive)
            { Console.WriteLine(rental); }
        }
    }
    
    public void PrintOverdueRentals()
    {
        foreach (var rental in _rentals)
        {
            if (rental.IsActive && DateTime.Now > rental.DueDate)
            { Console.WriteLine(rental); }
        }
    }

    public void PrintReport()
    {
        Console.WriteLine("All devices:");
        foreach (var e in _devices)
            Console.WriteLine(e);

        Console.WriteLine("\nActive rentals:");
        foreach (var r in _rentals.Where(r => r.ReturnDate == null))
            Console.WriteLine($"{r.User} -> {r.Device}");
    }
}