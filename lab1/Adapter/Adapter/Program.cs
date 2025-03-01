using System;

public interface IPrinter
{
    void Print(string text);
}

public class OldPrinter
{
    public void PrintOld(string text)
    {
        Console.WriteLine($"Old Printer: {text}");
    }
}

public class PrinterAdapter : IPrinter
{
    private readonly OldPrinter _oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        _oldPrinter = oldPrinter;
    }

    public void Print(string text)
    {
        _oldPrinter.PrintOld(text);
    }
}

public class NewPrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine($"New Printer: {text}");
    }
}

class Program
{
    static void Main()
    {
        IPrinter newPrinter = new NewPrinter();
        newPrinter.Print("Printing from the new printer!");

        IPrinter oldPrinterAdapter = new PrinterAdapter(new OldPrinter());
        oldPrinterAdapter.Print("Printing from the adapted old printer!");
    }
}
