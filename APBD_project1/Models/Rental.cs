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

    public void Return(DateTime returnDate)
    {
        ReturnDate = returnDate;
    }

    public decimal CalculatePenalty()
    {
        if (ReturnDate == null)
        {
            return 0;
        }

        if (ReturnDate.Value <= DueDate)
        {
            return 0;
        }

        int daysLate = (ReturnDate.Value.Date - DueDate.Date).Days;
        return daysLate * 10;
    }
    
    public bool IsActive
    {
        get { return ReturnDate == null; }
    }
    
    public override string ToString()
    {
        string returnInfo;

        if (ReturnDate == null)
        {
            returnInfo = "Nieoddane";
        }
        else
        {
            returnInfo = ReturnDate.Value.ToString("g");
        }

        return $"Użytkownik: {User.FirstName} {User.LastName}, " +
               $"Sprzęt: {Device.Name}, " +
               $"Data wypożyczenia: {RentDate:g}, " +
               $"Termin zwrotu: {DueDate:g}, " +
               $"Data zwrotu: {returnInfo}";
    }
    
}