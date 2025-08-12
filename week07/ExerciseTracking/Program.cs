using System;
using System.Collections.Generic;

// Base Activity class
public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public int LengthMinutes => _lengthMinutes;

    // Methods to be overridden
    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();    // mph
    public abstract double GetPace();     // min/mile

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_lengthMinutes} min) - " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.00} min per mile";
    }
}

// Running class
public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance() => _distanceMiles;
    public override double GetSpeed() => (GetDistance() / LengthMinutes) * 60;
    public override double GetPace() => LengthMinutes / GetDistance();
}

// Cycling class
public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int lengthMinutes, double speedMph)
        : base(date, lengthMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance() => (_speedMph * LengthMinutes) / 60;
    public override double GetSpeed() => _speedMph;
    public override double GetPace() => 60 / _speedMph;
}

// Swimming class
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceKm = (_laps * 50) / 1000.0;
        return distanceKm * 0.62; // convert to miles
    }

    public override double GetSpeed() => (GetDistance() / LengthMinutes) * 60;
    public override double GetPace() => LengthMinutes / GetDistance();
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 3), 25, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
