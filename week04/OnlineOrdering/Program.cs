using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Product pro1 = new Product("Tablet", "AP01", 1000, 2);
        Product pro2 = new Product("Cellphone", "AP02", 600, 3);
        Product pro3 = new Product("DVD", "AP03", 540, 1);

        Product pro4 = new Product("Lipstick", "BP01", 100, 3);
        Product pro5 = new Product("Hand Bag", "BPO2", 1000, 2);
        Product pro6 = new Product("Running Shoes", "BPO3", 300, 5);

        List<Product> products1 = new List<Product>();
        products1.Add(pro1);
        products1.Add(pro2);
        products1.Add(pro3);

        List<Product> products2 = new List<Product>();
        products2.Add(pro4);
        products2.Add(pro5);
        products2.Add(pro6);

        Address address1 = new Address("San Roque", "Calabanga", "Camarines Sur", "Philippines");
        Address address2 = new Address("123 Main Street", "Idaho Falls", "ID", "USA");

        Customer customer1 = new Customer("Enoch Palayar", address1);
        Customer customer2 = new Customer("Alliah Belle Mago", address2);

        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);


        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Cost: ${order1.GetTotalPrice()}");
        Console.WriteLine();


        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Cost: ${order2.GetTotalPrice()}");
        Console.WriteLine();


    }
}