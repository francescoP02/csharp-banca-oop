// See https://aka.ms/new-console-template for more information


public class Customer
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FiscalCode { get; set; }
    public int Salary { get; set; }

    public Customer(string name, string surname, string fiscalCode, int salary)
    {
        Name = name;
        Surname = surname;
        FiscalCode = fiscalCode;
        Salary = salary;
    }
}
