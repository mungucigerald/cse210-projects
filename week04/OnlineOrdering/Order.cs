using System;
using System.Text;
using System.Collections.Generic;

// Connects the Customer and Products.
// Performs math operation on for the money and produces labels
public class Order
{
    // Shipping FEes declared as constants for easy access.
    private const decimal DomesticShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;
    private List<Product> _products;
    private Customer _customer;

    // Constructor for an empty order for a given customer.
    // Items added to list individually with AddProduct method.
    public Order(Customer customer)
    {
        this._products = new();
        this._customer = customer;
    }

    // Contructor for an order with a filled product list available.
    public Order(Customer customer, List<Product> products)
    {
        this._customer = customer;
        this._products = products;
    }

    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public List<Product> Products
    {
        get { return _products; }
        set { _products = value; }
    }

    // Method to add a product to the order list.
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Returns the shipping fee for this order.
    // Customer's country inspected to determine the right shipping cost ie Domestic V International.
    private decimal GetShippingCost()
    {
        return _customer.IsInUSA() ? DomesticShippingCost : InternationalShippingCost;
    }

    // Returns the full price of the order: products are added to the shipping cost
    private decimal GetTotalCost()
    {
        decimal total = 0m;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        total += GetShippingCost();
        return total;
    }

    // Method to build the text for the packing label.
    private string GetPackingLabel()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("=== Pack Label ===");
        foreach (Product product in _products)
        {
            stringBuilder.AppendLine(product.ProductName + " (ID: " + product.ProductId + ") x" + product.Quantity);
        }
        return stringBuilder.ToString().TrimEnd();
    }

    // Method to build the text for the shipping label.
    private string GetShippingLabel()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("=== For Shipping ===");
        stringBuilder.AppendLine(_customer.Name);
        stringBuilder.AppendLine(_customer.Address.ShowFullAddress());
        return stringBuilder.ToString().TrimEnd();
    }

    // Method that prints one full order as summary. 
    public void PrintOrderSummary(string label, Order order)
    {
        Console.WriteLine("##########" + label + "##########");
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine("Shipping Fare:" + order.GetShippingCost().ToString("C"));
        Console.WriteLine("Total:" + order.GetTotalCost().ToString("C"));
        Console.WriteLine();
    }
}
