using System;

class SystemAPI
{
    static void Main()
    {
        // Variables for storing data
        string[] products = new string[0];
        int[] amount = new int[0];
        double[] prices = new double[0];

        // Control variables
        string? readresult;
        string menuSelection = "";
        bool exit = false;

        do
        {
            // Display menu
            Console.Clear();
            Console.WriteLine(" --- Stock ---");
            Console.WriteLine();
            Console.WriteLine("1. View products and inventory");
            Console.WriteLine("2. Add Products");
            Console.WriteLine("3. Exit");

            readresult = Console.ReadLine();
            if (readresult != null)
            {
                menuSelection = readresult.ToLower();
            }

            switch (menuSelection)
            {
                case "1":
                    Console.Clear();
                    if (products.Length == 0)
                    {
                        Console.WriteLine("No products registered yet.");
                    }
                    else
                    {
                        for (int i = 0; i < products.Length; i++)
                        {
                            Console.WriteLine($"{products[i]}\t| Amount: {amount[i]}\t| Price: {prices[i]:c}");
                        }
                    }
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.Write("Add product: ");
                    string? name = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Add amount: ");
                    string? amountInput = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Enter the price: ");
                    string? priceInput = Console.ReadLine();

                    // Simple validation
                    if (int.TryParse(amountInput, out int numAmount) && double.TryParse(priceInput, out double numPrice) && !string.IsNullOrWhiteSpace(name))
                    {
                        // 1. Resize all arrays to add space for 1 new item.
                        int newLength = products.Length + 1;
                        Array.Resize(ref products, newLength);
                        Array.Resize(ref amount, newLength);
                        Array.Resize(ref prices, newLength);

                        // 2.Save the data at the last position (index Length - 1)
                        int index = newLength - 1;
                        products[index] = name;
                        amount[index] = numAmount;
                        prices[index] = numPrice;

                        Console.WriteLine("\nProduct added successfully! Press Enter to continue.");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please try again. Press Enter to continue.");
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    exit = true;
                    break;
            }

        } while (!exit);
    }
}
