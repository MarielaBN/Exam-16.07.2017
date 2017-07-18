using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var manager = new DraftManager();
        string inputLine = String.Empty;
        while ((inputLine = Console.ReadLine()) != "Shutdown")
        {
            var tokens = inputLine.Split(' ');
            var cmd = tokens[0];
            var arguments = tokens.Skip(1).ToList();
           
            switch (cmd)
            {
                case "RegisterHarvester":
                    {
                        Console.WriteLine(manager.RegisterHarvester(arguments));
                    }
                    break;
                case "RegisterProvider":
                    {
                        Console.WriteLine(manager.RegisterProvider(arguments));
                    }
                    break;
                case "Day":
                    {
                        Console.WriteLine(manager.Day());
                    }
                    break;
                case "Mode":
                    {
                        Console.WriteLine(manager.Mode(arguments));
                    }
                    break;
                case "Check":
                    {
                        Console.WriteLine(manager.Check(arguments));
                    }
                    break;
            }
        }
        Console.WriteLine(manager.ShutDown());
        
    }
}