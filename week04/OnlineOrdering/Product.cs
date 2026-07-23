using System;

public class Product
{
    private string _productName;
    private string _productID;
    private decimal _price;
    private int _quantity;

    public Product(string productName, string productID, decimal price, int quantity)
    {
        this._productName = productName;
        this._productID = productID;
        this._price = price;
        this._quantity = quantity;
    }

    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }
    public string ProductId
    {
        get { return _productID; }
        set { _productID = value; }
    }
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }


}