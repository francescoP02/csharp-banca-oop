// See https://aka.ms/new-console-template for more information


public class Loan
{
    public Customer Customer { get; set; }
    public string Id { get; set; }
    public double Total { get; set; }
    public int Installment { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public Loan(Customer customer, double total, int installment, string startDate, string endDate)
    {
        Customer = customer;
        Id = new Random().Next(1, 99999999).ToString().PadLeft(8, '0');
        Total = total;
        Installment = installment;
        StartDate = startDate;
        EndDate = endDate;
    }
}
