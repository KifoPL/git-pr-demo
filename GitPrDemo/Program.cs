// See https://aka.ms/new-console-template for more information

using System.Globalization;
using GitPrDemo;

var pesel = new Pesel("24252301243");

CultureInfo.CurrentCulture = new CultureInfo("pl-PL");

Console.WriteLine($"Date of birth: {new DateOnly(pesel.Year, pesel.Month, pesel.Day).ToLongDateString()}");