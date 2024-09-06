using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public abstract class Product
{
    public abstract string Name { get; }
    public virtual double Price { get; protected set; }

    public Product(double price)
    {
        Price = price;
    }
    public abstract string GetInformation();
}
//Создал структуру для Классов Meat и Vegetable чтоб рзнообразить свойства
public struct Date
{
    public int Day { get; }
    public int Month { get; }
    public int Year { get; }

    public Date(int day, int month, int year)
    {

        if (day < 1 || day > 31)
           day = 0;
        if (month < 1 || month > 12)
            month = 0;
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day:D2}-{Month:D2}-{Year}";
    }
}

public class Toy : Product
{
    public string Material { get; }
    public bool For_kids {get; }
    public string Size { get; }

    public Toy(string name,bool for_kids, string size, double price, string material) : base(price)
    {
        Name = name;
        For_kids = for_kids;
        Material = material;
        Size = size;
        
    }

    public override string Name { get; }

    public override string GetInformation()
    {
        string kids_status = "NO";
        if (For_kids) kids_status = "YES";
        return $"Toy: {Name},For kids: {kids_status}, Size: {Size}, Material: {Material}, Price: {Price.ToString("F2")}";
    }
}

 public class Meat : Product
{
    public double Weight { get; }
    public Date DataZamorozki { get; }

    public Meat(string name, double price, double weight, Date dataZamorozki) : base(price)
    {
        Name = name;
        Weight = weight;
        DataZamorozki = dataZamorozki;
    }

    public override string Name { get; }

    public override string GetInformation()
    {
        return $"Meat: {Name}, Weight: {Weight} kg, Price: {Price.ToString("F2")}, Freezing Date: {DataZamorozki}";
    }
}

public class Drink : Product
{
    public string Flavor { get; }
    public int Volume { get; }
    public bool Ice { get; }

    public Drink(string name,int volume,bool ice, double price, string flavor) : base(price)
    {
        Name = name;
        Flavor = flavor;
        Volume = volume;
        Ice = ice;
    }

    public override string Name { get; }

    public override string GetInformation()
    {
        string _ice = "NO";
        if (Ice) _ice = "YES";
        return $"Drink: {Name},Volume ml: {Volume},With ice?: {_ice}, Flavor: {Flavor}, Price: {Price.ToString("F2")}";
    }
}

public class Fruit : Product
{
    public string Type { get; }
    public string Color { get; }

    public Fruit(string name, double price, string type, string color) : base(price)
    {
        Name = name;
        Type = type;
        Color = color;
    }

    public override string Name { get; }

    public override string GetInformation()
    {
        return $"Fruit: {Name}, Type: {Type}, Color: {Color}, Price: {Price.ToString("F2")}";
    }
}

public class Vegetable : Product
{
    public string Color { get; }
    public Date Harvest_date { get; }

    public Vegetable(string name,Date harvest_date, double price, string color) : base(price)
    {
        Name = name;
        Color = color;
        Harvest_date = harvest_date;
    }

    public override string Name { get; }

    public override string GetInformation()
    {
        return $"Vegetable: {Name}, Color: {Color}, Harvest_date: {Harvest_date}, Price: {Price.ToString("F2")}";
    }
}
public class Lamp : Product
{
    public string Color_light { get; }
    public Date Harvest_date { get; }
    public float Power_light { get; }

    public Lamp(string name, float power_light, double price, string color_light) : base(price)
    {
        Name = name;
        Color_light = color_light;
        Power_light = power_light;


    }

    public override string Name { get; }

    public override string GetInformation()
    {
        return $"Vegetable: {Name}, Power_light: {Power_light}, Color_light: {Color_light}, Price: {Price.ToString("F2")}";
    }
}
public class Store
{
    private List<Product> products;

    public Store()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void ShowProducts(double discountPercentage)
    {
        Console.WriteLine($"Products with {discountPercentage}% discount:");
        foreach (var product in products)
        {
            double discountedPrice = product.Price * (1 - discountPercentage / 100);
            Console.WriteLine($"{product.GetInformation()} -> Discounted Price: {discountedPrice.ToString("F2")}");
        }
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store();

        
        store.AddProduct(new Toy("Carrot jmakalka",false,"Small", 25.19, "Silikon"));
        var freezingDate = new Date(6, 9, 2024);
        
        store.AddProduct(new Meat("Beef", 10.50, 1.5, freezingDate));
        store.AddProduct(new Drink("Moxito",350,true, 1.50, "Lime Flavor"));
        store.AddProduct(new Fruit("Apple", 0.99 ,"Fermerskie", "red"));
        var Data_sbora = new Date(1, 8, 2024);
        store.AddProduct(new Vegetable("Carrot", Data_sbora, 0.59, "Orange"));
        store.AddProduct(new Lamp("Solnce",0.5f,122,"red"));

        store.ShowProducts(14);
    }
}
