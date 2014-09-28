using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------Problem.1");
        Location home = new Location(18.037986, 28.870097, Planet.Earth);
        Console.WriteLine(home);
        Console.WriteLine("---------Problem.2");
        Fraction f = new Fraction(2, 1);
        Fraction fraction1 = new Fraction(22, 7);
        Fraction fraction2 = new Fraction(40, 4);
        Console.WriteLine(fraction1.ToString());
        Fraction result = fraction1 + fraction2;
        Console.WriteLine(result.Numerator);
        Console.WriteLine(result.Denominator);
        Console.WriteLine(result);
        Fraction res = fraction1 - fraction2;
        Console.WriteLine(res);

        Console.WriteLine("---------Problem.3 and Problem.4");
        GenericList<int> myList = new GenericList<int>();

        Console.WriteLine();

        myList.Add(123);
        myList.Add(1293);
        myList.Add(11);
        myList.Add(12314);
        myList.Add(111111);

        Console.WriteLine(myList);
        myList.Remove(0);
        myList.InsertAt(11, 2);
        myList.InsertAt(666, 0);
        Console.WriteLine(myList);
        Console.WriteLine("index of 11: "+myList.IndexOf(11));
        Console.WriteLine("does contain 11121: "+myList.Contains(11121));
        myList.Add(-1001);
        Console.WriteLine("min = "+myList.Min());

        var customAttributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), true);
        Console.WriteLine("This GenericList<T> class's version is {0}", customAttributes);
    }
}