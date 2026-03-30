namespace APBD_project1.Models;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName) {}

    public override int MaxLoans => 5;
}