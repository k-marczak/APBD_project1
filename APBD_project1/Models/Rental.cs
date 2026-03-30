namespace APBD_project1.Models;

public class Rental
{
    public User User { get; }
    public Device Device { get; }
    public DateTime RentDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }

    public Rental(User user, Device device, int days)
    {
        User = user;
        Device = device;
        RentDate = DateTime.Now;
        DueDate = RentDate.AddDays(days);
    }

    public void Return()
    {
        ReturnDate = DateTime.Now;
    }

    public bool IsLate()
    {
        return ReturnDate != null && ReturnDate > DueDate;
    }

    public decimal CalculatePenalty()
    {
        if (!IsLate()) return 0;

        var daysLate = (ReturnDate.Value - DueDate).Days;
        return daysLate * 10; // 10 zł za dzień
    }
}