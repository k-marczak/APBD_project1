using APBD_project1.Models;

namespace APBD_project1.Services;

public class BusinessLogic
{
    private List<Device> _device = new();
    private List<User> _users = new();
    private List<Rental> _rentals = new();

    public void AddEquipment(Device device)
    {
        _device.Add(device);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<Device> GetAvailableEquipment()
    {
        return _device.Where(e => e.IsAvailable).ToList();
    }

    
}