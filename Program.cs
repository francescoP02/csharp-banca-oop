// See https://aka.ms/new-console-template for more information


//Esercizio
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una
//banca concede ai propri clienti.
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

List<Customer> customers = new List<Customer>();
List<Loan> loans = new List<Loan>();

string userInput;

do
{
    Console.WriteLine("****Welcome****");

    Console.WriteLine("Insert 'add' for add a user");
    Console.WriteLine("Insert 'search' for search a user");
    Console.WriteLine("Insert 'modify' for modify user data");
    Console.WriteLine("Insert 'loan' for create a new loan");
    Console.WriteLine("Insert 'stop' for terminate the process");
    userInput = Console.ReadLine();

    if (userInput == "add")
    {
        CreateNewCustomer();
    }

    else if (userInput == "search")
    {
        SearchClient();
    }

    else if (userInput == "modify")
    {
        ModifyCustomer();
    }

    else if (userInput == "loan")
    {
        AddLoan();
    }

} while (userInput != "stop");


//FUNCTIONS

//Funzione per aggiungere customer

void CreateNewCustomer()
{
    Console.Clear();

    Console.WriteLine("****Register a new client****");

    Console.Write("Client Name: ");
    string inputName = Console.ReadLine();

    Console.Write("Client Surname: ");
    string inputSurname = Console.ReadLine();

    Console.Write("Fiscal Code: ");
    string inputTaxCode = Console.ReadLine();

    Console.Write("Salary: ");
    int inputSalary = Int32.Parse(Console.ReadLine());

    Customer newCustomer = new Customer(inputName, inputSurname, inputTaxCode, inputSalary);
    customers.Add(newCustomer);
}


//Funzione per cercare un customer e i suoi prestiti

void SearchClient()
{
    Console.Clear();

    bool found = false;

    double total = 0;

    Console.WriteLine("****Enter customer's fiscal code****");

    string fiscalCode = Console.ReadLine();

    // searching for a loan having the client Id entered
    foreach (Loan loan in loans)
    {
        if (loan.Customer.FiscalCode == fiscalCode)
        {
            found = true;

            total = total + loan.Total;

            Console.WriteLine($"****The customer {loan.Customer.Surname} has a loan of {loan.Total} euro started in {loan.StartDate} ****");
        }
    }

    if (found == false)
    {
        Console.WriteLine("****No Loan found****");
    }

    else
    {
        Console.WriteLine($"****Customer {fiscalCode} has a total ammount of {total} euro to pay****");
    }

}


//Funzione per aggiungere un prestito ad un customer

void AddLoan()
{
    Console.Clear();

    bool found = false;

    Console.WriteLine("****Insert customer's fiscal code****");

    string fiscalCode = Console.ReadLine();

    foreach (Customer customer in customers)
    {
        if (customer.FiscalCode == fiscalCode)
        {
            found = true;

            Console.WriteLine("****Insert ammount****");
            double ammount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("****Insert installment number****");
            int installment = Convert.ToInt32(Console.ReadLine());

            Loan loan = new Loan(customer, ammount, installment, "21/09/2022", "31/12/2022");

            loans.Add(loan);

            Console.WriteLine("Loan registered successfully");
        }
    }
    if (found == false)
    {
        Console.WriteLine("Client don't found, try register new client first");
    }

}

//Funzione per modificare i dati relativi ad un customer

void ModifyCustomer()
{

    Console.Clear();


    bool found = false;

    Console.WriteLine("****Enter customer's fiscal code****");

    string fiscalCode = Console.ReadLine();

    foreach (Customer customer in customers)
    {
        if(customer.FiscalCode == fiscalCode)
        {
            Console.Clear();

            found = true;

            string informationInput;

            do
            {
                Console.Clear();

                Console.WriteLine($"****Customer's name: {customer.Name}****");
                Console.WriteLine($"****Customer's surname: {customer.Surname}****");
                Console.WriteLine($"****Customer's fiscal code: {customer.FiscalCode}****");
                Console.WriteLine($"****Customer's salary: {customer.Salary}****");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("****What do you want to modify?****");
                Console.WriteLine("Insert 'name' for modify customer's name");
                Console.WriteLine("Insert 'surname' for modify customer's surname");
                Console.WriteLine("Insert 'fiscalcode' for modify customer's fiscal code");
                Console.WriteLine("Insert 'salary' for modify customer's salary");
                Console.WriteLine("Insert 'stop' for terminate the modify process");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(Environment.NewLine);

                informationInput = Console.ReadLine();

                if (informationInput == "name")
                {
                    Console.WriteLine("Enter customer's name");
                    string name = Console.ReadLine();
                    customer.Name = name;
                }
                else if (informationInput == "surname")
                {
                    Console.WriteLine("Enter customer's surname");
                    string surname = Console.ReadLine();
                    customer.Surname = surname;
                }
                else if (informationInput == "fiscalcode")
                {
                    Console.WriteLine("Enter customer's fiscal code");
                    string fiscalcode = Console.ReadLine();
                    customer.FiscalCode = fiscalcode;
                }
                else if (informationInput == "salary")
                {
                    Console.WriteLine("Enter customer's salary");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    customer.Salary = salary;
                }
            } while (informationInput != "stop");

            Console.Clear();
        }
    }

    if (found == false)
    {
        Console.Clear();

        Console.WriteLine("****Client don't found, try register new client first****");
    }
}
