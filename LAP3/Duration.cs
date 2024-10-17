using System;

public class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }
    public Duration(int hours, int minutes, int seconds)
    {
        this.Hours = hours;
        this.Minutes = minutes;
        this.Seconds = seconds;
        Normalize();
    }
    public override string ToString()
    {
        return $"{Hours}H:{Minutes}M:{Seconds}";
    }
    public override bool Equals(object obj)
    {
        if (obj is Duration)
        {
            var other = (Duration)obj;
            return this.Hours == other.Hours &&
                   this.Minutes == other.Minutes &&
                   this.Seconds == other.Seconds;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }
    private void Normalize()
    {
        if (Seconds >= 60)
        {
            Minutes += Seconds / 60;
            Seconds %= 60;
        }
        if (Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes %= 60;
        }
    }
    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
    }
    public static Duration operator +(int seconds, Duration d)
    {
        return new Duration(d.Hours, d.Minutes, d.Seconds + seconds);
    }
    public static Duration operator ++(Duration d)
    {
        return new Duration(d.Hours, d.Minutes + 1, d.Seconds);
    }
    public static Duration operator --(Duration d)
    {
        return new Duration(d.Hours, d.Minutes - 1, d.Seconds);
    }  
    public static Duration operator -(Duration d1, Duration d2)
    {
        int totalSeconds1 = d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds;
        int totalSeconds2 = d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds;
        int resultSeconds = totalSeconds1 - totalSeconds2;

        if (resultSeconds < 0) resultSeconds = 0;

        int hours = resultSeconds / 3600;
        int minutes = (resultSeconds % 3600) / 60;
        int seconds = resultSeconds % 60;

        return new Duration(hours, minutes, seconds);
    }   
    public static bool operator <=(Duration d1, Duration d2)
    {
        return (d1.Hours < d2.Hours) ||
               (d1.Hours == d2.Hours && d1.Minutes < d2.Minutes) ||
               (d1.Hours == d2.Hours && d1.Minutes == d2.Minutes && d1.Seconds <= d2.Seconds);
    }
    public static bool operator >=(Duration d1, Duration d2)
    {
        return (d1.Hours > d2.Hours) ||
               (d1.Hours == d2.Hours && d1.Minutes > d2.Minutes) ||
               (d1.Hours == d2.Hours && d1.Minutes == d2.Minutes && d1.Seconds >= d2.Seconds);
    }

}
