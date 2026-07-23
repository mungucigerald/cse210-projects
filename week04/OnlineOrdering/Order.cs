using System;
using System.Text;
using System.Collections.Generic;

public class Order
{
    private const decimal DomesticShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        this._products = new ();
        this._customer = customer;
    }

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

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    public decimal GetShippingCost()
    {
        return _customer.IsInUSA() ? DomesticShippingCost : InternationalShippingCost;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        total += GetShippingCost();
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("=== Pack Label ===");
        foreach (Product product in _products)
        {
            stringBuilder.AppendLine(product.ProductName + " (ID: " + product.ProductId + ") x" + product.Quantity);
        }
        return stringBuilder.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("=== For Shipping ===");
        stringBuilder.AppendLine(_customer.Name);
        stringBuilder.AppendLine(_customer.Address.ShowFullAddress());
        return stringBuilder.ToString().TrimEnd();
    }
    
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
