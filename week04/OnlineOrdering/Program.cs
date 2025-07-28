using System;
using System.Collections.Generic;
class Program
{
    
    static void Main()
    {
        // First Order
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Product product1 = new Product("Book", "B001", 12.99, 2);
        Product product2 = new Product("Pen", "P002", 1.49, 5);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Price: ${order1.CalculateTotalPrice():F2}");
        Console.WriteLine();

        // Second Order
        Address address2 = new Address("456 King St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);

        Product product3 = new Product("Notebook", "N003", 5.99, 3);
        Product product4 = new Product("Backpack", "BP004", 35.99, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}

    