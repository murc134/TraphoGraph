using System;

[Serializable]
public struct MyDateTime
{
    public int Year;
    public int Month;
    public int Day;

    public DateTime Date { get { return new DateTime(Year, Month, Day); } }

    public MyDateTime(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }
    public MyDateTime(DateTime date)
    {
        Year = date.Year;
        Month = date.Month;
        Day = date.Day;
    }
    public override string ToString()
    {
        return $"{Day}.{Month}.{Year}";
    }
    public string ToString(bool includeYear = false)
    {
        string year = includeYear ? $".{Year}" : "";
        return $"{Day}.{Month}.{year}";
    }
}