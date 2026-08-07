// <Snippet1>
using System;

public class CityInfo
{
    string cityName;
    string countryName;
    int pop2010;

    public CityInfo(string name, string country, int pop2010)
    {
        this.cityName = name;
        this.countryName = country;
        this.pop2010 = pop2010;
    }

    public string City => this.cityName;

    public string Country => this.countryName;

    public int Population => this.pop2010;

    public static int CompareByName(CityInfo city1, CityInfo city2) => string.Compare(city1.City, city2.City);

    public static int CompareByPopulation(CityInfo city1, CityInfo city2) => city1.Population.CompareTo(city2.Population);

    public static int CompareByNames(CityInfo city1, CityInfo city2) => string.Compare(city1.Country + city1.City, city2.Country + city2.City);
}

public class Example
{
    public static void Main()
    {
        CityInfo NYC = new("New York City", "United States of America", 8175133);
        CityInfo Det = new("Detroit", "United States of America", 713777);
        CityInfo Paris = new("Paris", "France", 2193031);
        CityInfo[] cities = { NYC, Det, Paris };
        // Display ordered array.
        DisplayArray(cities);

        // Sort array by city name.
        Array.Sort(cities, CityInfo.CompareByName);
        DisplayArray(cities);

        // Sort array by population.
        Array.Sort(cities, CityInfo.CompareByPopulation);
        DisplayArray(cities);

        // Sort array by country + city name.
        Array.Sort(cities, CityInfo.CompareByNames);
        DisplayArray(cities);
    }

    private static void DisplayArray(CityInfo[] cities)
    {
        Console.WriteLine($"{"City",-20} {"Country",-25} {"Population",10}");
        foreach (var city in cities)
            Console.WriteLine($"{city.City,-20} {city.Country,-25} {city.Population,10:N0}");

        Console.WriteLine();
    }
}
// The example displays the following output:
//     City                 Country                   Population
//     New York City        United States of America   8,175,133
//     Detroit              United States of America     713,777
//     Paris                France                     2,193,031
//
//     City                 Country                   Population
//     Detroit              United States of America     713,777
//     New York City        United States of America   8,175,133
//     Paris                France                     2,193,031
//
//     City                 Country                   Population
//     Detroit              United States of America     713,777
//     Paris                France                     2,193,031
//     New York City        United States of America   8,175,133
//
//     City                 Country                   Population
//     Paris                France                     2,193,031
//     Detroit              United States of America     713,777
//     New York City        United States of America   8,175,133
// </Snippet1>
