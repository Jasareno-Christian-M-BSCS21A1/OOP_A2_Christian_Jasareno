using System;
using System.Collections.Generic;

class CoffeeShop
{
    static List<(string itemName, double itemPrice)> menu = new List<(string, double)>();
    static List<(string itemName, double itemPrice)> order = new List<(string, double)>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Coffee Shop!");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. View Menu");
            Console.WriteLine("3. Place Order");
            Console.WriteLine("4. View Order");
            Console.WriteLine("5. Calculate Total");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                AddMenuItem();
            }
            else if (option == "2")
            {
                ViewMenu();
            }
            else if (option == "3")
            {
                PlaceOrder();
            }
            else if (option == "4")
            {
                ViewOrder();
            }
            else if (option == "5")
            {
                CalculateTotal();
            }
            else if (option == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option, try again.");
            }

            Console.WriteLine();
        }
    }


    static void AddMenuItem()
    {
        Console.Write("Enter item name: ");
        string itemName = Console.ReadLine();
        Console.Write("Enter item price: ");
        double itemPrice = Convert.ToDouble(Console.ReadLine());

        menu.Add((itemName, itemPrice));
        Console.WriteLine("Item added successfully!");
    }


    static void ViewMenu()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("Menu is empty.");
            return;
        }

        Console.WriteLine("Menu:");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i].itemName} - ${menu[i].itemPrice}");
        }
    }


    static void PlaceOrder()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("No items in the menu to order from.");
            return;
        }

        ViewMenu();
        Console.Write("Enter the item number to order: ");
        int itemNumber = Convert.ToInt32(Console.ReadLine());

        if (itemNumber > 0 && itemNumber <= menu.Count)
        {
            order.Add(menu[itemNumber - 1]);
            Console.WriteLine("Item added to order!");
        }
        else
        {
            Console.WriteLine("Invalid item number.");
        }
    }


    static void ViewOrder()
    {
        if (order.Count == 0)
        {
            Console.WriteLine("Your order is empty.");
            return;
        }

        Console.WriteLine("Your Order:");
        foreach (var item in order)
        {
            Console.WriteLine($"{item.itemName} - ${item.itemPrice}");
        }
    }


    static void CalculateTotal()
    {
        if (order.Count == 0)
        {
            Console.WriteLine("No items in the order to calculate.");
            return;
        }

        double total = 0;
        foreach (var item in order)
        {
            total += item.itemPrice;
        }

        Console.WriteLine($"Total Amount Payable: ${total}");
    }
}
