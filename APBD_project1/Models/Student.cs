namespace APBD_project1.Models;

public class Student : User
{
    protected Student(string firstName, string lastName) : base(firstName, lastName) {}

    public override int MaxLoans => 2;
}