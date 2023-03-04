using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Shape
{
    public int Area() { return 0; }
}

public class Circle : Shape
{
    public int Radius { get; set; }
    public new int Area()
    {
        return (int)(Math.PI * Math.Pow(Radius, 2));
    }
}

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Length { get; set; }
    public new int Area()
    {
        return Width*Length;
    }
}


//multi level inheritance

public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Eat()
    {
        Console.WriteLine("Eating...");
    }

}

public class Mammal : Animal
{
    public void Nurse()
    {
        Console.WriteLine("Nursing...");
    }
}

public class Dog : Mammal
{
    public void Bark()
    {
        Console.WriteLine("Barking...");
    }
}



//Multiple inheritance
public interface Car
{
    public string Model { get; set; }
    public int Year { get; set; }
    public string Country { get; set; }
    public void Milage();
}

public interface AdvancedCar
{
    public Boolean HasRoofTop { get; set; }
    public Boolean ParkingAssist { get; set; }

    void AutoPilot();
}

public class Tesla:Car, AdvancedCar
{
    public string Model { get; set; }
    public int Year { get; set; }

    public string Country { get; set; }

    public Boolean HasRoofTop { get; set; }
    public Boolean ParkingAssist { get; set;}


    public Tesla(string model, int year, string country, bool hasRoofTop, bool parkingAssist)
    {
        Model = model;
        Year = year;
        Country = country;
        this.HasRoofTop = hasRoofTop;
        this.ParkingAssist = parkingAssist;
    }
    public void Milage()
    {
        Console.WriteLine("50 KM per hour...");
    }

    public void AutoPilot()
    {
        Console.WriteLine("I can drive my self..");
    }
}

