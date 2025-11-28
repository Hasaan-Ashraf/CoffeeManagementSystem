using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement
{
    class CoffeeShopManagement
    {
        Dictionary<string, double> menu = new Dictionary<string, double>
    {
        { "Espresso", 3.00 },
        { "Americano", 3.50 },
        { "Latte", 4.00 },
        { "Cappuccino", 4.50 },
        { "Mocha", 5.00 }
    };

        List<(string coffee, int qty, double cost)> orders = new List<(string, int, double)>();

        public void ShowMenu()
        {
            Console.WriteLine("\n--- Coffee Menu ---");
            foreach (var item in menu)
                Console.WriteLine($"{item.Key}: ${item.Value:F2}");
        }

        public void AddOrder()
        {
            ShowMenu();
            Console.Write("\nEnter coffee name: ");
            string name = Console.ReadLine().Trim();

            if (menu.ContainsKey(name))
            {
                Console.Write("Enter quantity: ");
                int qty = int.Parse(Console.ReadLine());
                double cost = menu[name] * qty;
                orders.Add((name, qty, cost));
                Console.WriteLine($"{qty}x {name} added.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void ViewOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders.");
                return;
            }

            double total = 0;
            Console.WriteLine("\n--- Orders ---");
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.qty}x {o.coffee} - ${o.cost:F2}");
                total += o.cost;
            }
            Console.WriteLine($"Total: ${total:F2}");
        }

        public void Checkout()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No items.");
                return;
            }

            double total = 0;
            Console.WriteLine("\n--- Receipt ---");
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.qty}x {o.coffee} - ${o.cost:F2}");
                total += o.cost;
            }
            Console.WriteLine($"Total Amount: ${total:F2}");
            orders.Clear();
        }

        public void SearchCoffee()
        {
            Console.Write("\nEnter coffee name to search: ");
            string name = Console.ReadLine().Trim();

            if (menu.ContainsKey(name))
                Console.WriteLine($"{name} is available for ${menu[name]:F2}");
            else
                Console.WriteLine($"{name} is not available.");
        }

        public void RemoveOrder()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders to remove.");
                return;
            }

            Console.Write("\nEnter order name to remove: ");
            string name = Console.ReadLine().Trim();

            int index = orders.FindIndex(o => o.coffee.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (index != -1)
            {
                orders.RemoveAt(index);
                Console.WriteLine($"{name} removed from orders.");
            }
            else
                Console.WriteLine("Order not found.");
        }

        public void ClearOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders to clear.");
                return;
            }

            orders.Clear();
            Console.WriteLine("All orders cleared.");
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nCoffee Shop");
                Console.WriteLine("1. Show Menu");
                Console.WriteLine("2. Add Order");
                Console.WriteLine("3. View Orders");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Search Coffee");
                Console.WriteLine("6. Remove Order");
                Console.WriteLine("7. Clear Orders");
                Console.WriteLine("8. Exit");
                Console.Write("Choose: ");
                string c = Console.ReadLine();

                switch (c)
                {
                    case "1": ShowMenu(); break;
                    case "2": AddOrder(); break;
                    case "3": ViewOrders(); break;
                    case "4": Checkout(); break;
                    case "5": SearchCoffee(); break;
                    case "6": RemoveOrder(); break;
                    case "7": ClearOrders(); break;
                    case "8": return;
                    default: Console.WriteLine("Invalid"); break;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
}
