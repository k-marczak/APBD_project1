namespace APBD_project1.Models;

public abstract class User
{
    private static int _idCounter = 1;

    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected User(string firstName, string lastName)
    {
        Id = _idCounter++;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract int MaxLoans { get; }

    public override string ToString()
    {
        return $"{Id}: {FirstName} {LastName}";
    }
}