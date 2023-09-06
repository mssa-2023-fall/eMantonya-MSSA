
Dictionary<string, float[]> Cart = new Dictionary<string, float[]>();

float total = 0;
bool exit = false;
while (exit == false)
{
    Console.WriteLine("Enter product name:");
    string response = Console.ReadLine().ToLower();
    switch (response) {
        case "apple":
            if (!Cart.ContainsKey("Apple")) { Cart["Apple"] = new[] { 1, 1.99f }; }
            else { Cart["Apple"][0]++; }
            total += 1.99f;
            break;
        case "banana":
            if (!Cart.ContainsKey("Banana")) { Cart["Banana"] = new[] { 1, 2.49f }; }
            else { Cart["Banana"][0]++; }
            total += 2.49f;
            break;
        case "orange":
            if (!Cart.ContainsKey("Orange")) { Cart["Orange"] = new[] { 1, 0.99f }; }
            else { Cart["Orange"][0]++; }
            total += 0.99f;
            break;
        case "peach":
            if (!Cart.ContainsKey("Peach")) { Cart["Peach"] = new[] { 1, 1.29f }; }
            else { Cart["Peach"][0]++; }
            total += 1.29f;
            break;
        case "watermelon":
            if (!Cart.ContainsKey("Watermelon")) { Cart["Watermelon"] = new[] { 1, 3.99f }; }
            else { Cart["Watermelon"][0]++; }
            total += 3.99f;
            break;
        case "exit":
            exit = true;
            break;
        default:
            Console.WriteLine("Try again..");
            break;
    }
}
Console.WriteLine("****************Receipt****************");
float totalItems = 0;
foreach (var item in Cart)
{
    Console.WriteLine($"**{item.Key} -- {item.Value[0]}@ {item.Value[1]:c}ea  =  {item.Value[0] * item.Value[1]:c}**");
    totalItems += item.Value[0];
}
Console.WriteLine($"**Total Items: {totalItems}-Total Price: {total:c}**");


