// See https://aka.ms/new-console-template for more information


public class Bank
{
    public string Name { get; set; }
    public List<Customer> customers;
    public List<Loan> loans;

    public Bank(string name)
    {
        Name = name;
        this.customers = new List<Customer>();
        this.loans = new List<Loan>();
    }
}
