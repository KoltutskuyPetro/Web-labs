using System;

public interface IDeliveryStrategy
{
    void Deliver(string package);
}

public class TruckDelivery : IDeliveryStrategy
{
    public void Deliver(string package)
    {
        Console.WriteLine($"Delivering '{package}' by truck");
    }
}

public class TrainDelivery : IDeliveryStrategy
{
    public void Deliver(string package)
    {
        Console.WriteLine($"Delivering '{package}' by train");
    }
}

public class AirDelivery : IDeliveryStrategy
{
    public void Deliver(string package)
    {
        Console.WriteLine($"Delivering '{package}' by airplane");
    }
}

public class DeliveryService
{
    private IDeliveryStrategy _strategy;

    public void SetStrategy(IDeliveryStrategy strategy)
    {
        _strategy = strategy;
    }

    public void DeliverPackage(string package)
    {
        if (_strategy == null)
        {
            Console.WriteLine("Error: No delivery strategy set!");
            return;
        }

        _strategy.Deliver(package);
    }
}

class Program
{
    static void Main()
    {
        DeliveryService deliveryService = new DeliveryService();

        deliveryService.SetStrategy(new TruckDelivery());
        deliveryService.DeliverPackage("Laptop");

        deliveryService.SetStrategy(new TrainDelivery());
        deliveryService.DeliverPackage("Car tires");

        deliveryService.SetStrategy(new AirDelivery());
        deliveryService.DeliverPackage("Medical supplies");

        Console.ReadLine();
    }
}
