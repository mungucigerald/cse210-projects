using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new("123 Maple Street", "Springfield", "IL", "USA");
        Customer customer1 = new("Alice Johnson", address1);

        Order order1 = new(customer1);
        order1.AddProduct(new Product("Wirelesss mouse", "SKU1001", 19.25m, 2));
        order1.AddProduct(new Product("Wirelesss keyboard", "SKU1041", 89.50m, 1));
        order1.AddProduct(new Product("Power Bank", "SKU1001", 20.15m, 3));

        order1.PrintOrderSummary("Order 1", order1);

        Address address2 = new("$% Kings Lane", "London", "England", "United Kingdom");
        Customer customer2 = new("Hillary Flemming", address2);

        List<Product> order2lst = new()
        {
            new ("Wireless Headphones", "SKU0093", 145.45m, 1),
            new ("Travel Adapter", "SKU3043", 45.45m, 2)
        };
        Order order2 = new(customer2, order2lst);

        order2.PrintOrderSummary("Order 2", order2);


    }
}