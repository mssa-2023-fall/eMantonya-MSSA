using MortgageCalculator2._0;
using Spectre.Console;


string response = "";
List<Customer> customerList = new List<Customer>();
customerList.Add(new Customer("Bob", 30, 7.69, 250000, 7500));
customerList.Add(new Customer("Jane", 15, 7.85, 300000, 5500));
customerList.Add(new Customer("Bill", 30, 7.30, 1750000, 3000));
do
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Home Loans").Centered().Color(Color.Gold3));

    response = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[green]What would you like to do?[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to traverse)[/]")
            .AddChoices(new[]
            {
                "Add New Customer", "Get Customer", "Exit"
            }));

    switch (response)
    {
        case "Add New Customer":
            var newCust = AddNewCustomer();
            customerList.Add(newCust);
            DisplayCustomer(newCust);
            break;
        case "Get Customer":
            var request = GetCustomer(customerList);
            if (request != null)
            {
                QueryCustomer(request);
            }
            break;
    }


} while (response != "Exit");

Customer AddNewCustomer()
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Add Customer").Centered().Color(Color.Gold3));
    string name = AnsiConsole.Ask<string>("Enter the customer's full [green]name[/]: ");
    int duration = AnsiConsole.Ask<int>("Enter the [green]loan term[/]: ");
    double rate = AnsiConsole.Ask<double>("Enter the [green]interest rate[/] - [red]ex.7.85[/]: ");
    double price = AnsiConsole.Ask<double>("Enter the [green]purchase price[/] of the home: ");
    if(AnsiConsole.Confirm("Is the buyer providing a down payment?: "))
    {
        double downPayment = AnsiConsole.Ask<double>("Enter the down payment amount: ");
        return new Customer(name, duration, rate, price, downPayment);
    }
    return new Customer(name, duration, rate, price);
}

void DisplayCustomer(Customer cust)
{
    var table = new Table();
    table.AddColumn("Name").Centered();
    table.AddColumn("Account Number").Centered();
    table.AddColumn("Loan Amount").Centered();
    table.AddColumn("Origination Date").Centered();
    table.AddColumn("Term").Centered();
    table.AddColumn("Rate").Centered();
    table.AddColumn("Down Payment").Centered();
    table.AddColumn("Total Payments").Centered();  
    table.AddColumn("Purchase Price").Centered();
    table.AddColumn("Monthly Payment").Centered();

    table.AddRow($"{cust._accountHolder}",
        $"{cust._accountNum}",
        $"${cust._principal}",
        $"{cust._originationDate}",
        $"{cust._duration}",
        $"{cust._intrestRate}",
        $"${cust._downPayment}",
        $"{cust._totalPayments}",
        $"${cust._purchasePrice}",
        $"${cust._monthlyPayment}");
    table.Border(TableBorder.Rounded);
    table.Expand();

    AnsiConsole.Write(table);

    double totalInterest = Math.Round((cust._principal * cust._intrestRate) / 100, 2);
    AnsiConsole.Write(new BreakdownChart()
    .Width(60)
    .AddItem("Interest", (double)totalInterest, Color.Red)
    .AddItem("Principal", cust._principal, Color.Green));
    

    AnsiConsole.Write("Press any key to continue..");
    Console.ReadKey();
    

}

Customer GetCustomer(List<Customer> customerList)
{
    var name = AnsiConsole.Ask<string>("Enter the [green]name[/] of the customer: ");
    foreach (Customer cust in customerList)
    {
        if (cust._accountHolder.Equals(name))
        {
            return cust;
        }
    }
    AnsiConsole.Write("[red]Customer not found.[/]");
    Console.ReadKey();
    return null;
}

void QueryCustomer(Customer cust)
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Query Customer").Centered().Color(Color.Gold3));

    do
    {
        response = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[green]What would you like to do with {cust._accountHolder}?[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to traverse)[/]")
                .AddChoices(new[]
                {
                    "Display Customer", "Display Amortization Schedule", "Main Menu"
                }));
        switch (response)
        {
            case "Display Customer":
                DisplayCustomer(cust);
                break;
            case "Display Amortization Schedule":
                DisplayAmortizationSchedule(cust);
                break;
        }
    } while (response != "Main Menu");      
}

void DisplayAmortizationSchedule(Customer cust)
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Amortization Schedule").Centered().Color(Color.Gold3));
    var table = new Table();
    table.AddColumn("Month");
    table.AddColumn("Interest Payment").Centered();
    table.AddColumn("Principal Payment").Centered();
    table.AddColumn("Remaining Balance").Centered();
    decimal remainingBalance = (decimal)cust._principal;
    double monthlyRate = (cust._intrestRate / 12) / 100;
    for (int month = 1; month <= cust._totalPayments; month++)
    {
        decimal interestPayment = remainingBalance * (decimal)monthlyRate;
        decimal principalPayment = cust._monthlyPayment - interestPayment;
        remainingBalance -= principalPayment;
        table.AddRow($"{month}",
            $"{Math.Round(interestPayment, 2)}",
            $"{Math.Round(principalPayment, 2)}",
            $"{Math.Round(remainingBalance)}");
    }
    table.Border(TableBorder.Rounded);
    table.Expand();

    AnsiConsole.Write(table);
    AnsiConsole.Write("Press any key to continue..");
    Console.ReadKey();
}
