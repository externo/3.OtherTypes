using System;
struct Location
{
    //fields
    private double latitude;
    private double longitude;
    private Planet planet;

    //constructors
    public Location(double latitude, double longitude, Planet planet) : this()
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
        this.Planet = planet;
    }

    //properties
    public double Latitude 
    {
        get
        {
            return this.latitude;
        }
        set
        {
            this.latitude = value;
        }
    }

    public double Longitude
    {
        get
        {
            return this.longitude;
        }
        set
        {
            this.longitude = value;
        }
    }

    public Planet Planet
    {
        get
        {
            return this.planet;
        }
        set
        {
            this.planet = value;
        }
    }

    //methods
    public override string ToString()
    {
        string result = string.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
        return result;
    }
}

enum Planet
{
    Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
}