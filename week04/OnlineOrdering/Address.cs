using System;

// I
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        this._street = street;
        this._city = city;
        this._state = state;
        this._country = country;
    }

    public string Street
    {
        get { return _street; }
        set { _street = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public bool IsInUSA()
    {
        return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase)
         || _country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase)
         || _country.Trim().Equals("United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string ShowFullAddress()
    {
        return _street + "\n" + _city + "\n" + _state + "\n" + _country;
    }
}