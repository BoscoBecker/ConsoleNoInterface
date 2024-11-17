using ConsoleInterface.Entities;
namespace ConsoleInterface.Services;

public class RentalService(double pricePerHour, double priceByDay)
{
    public double PricePerHour { get; private set; } = pricePerHour;
    public double PriceByDay { get; private set; } = priceByDay;
    private BrazilTaxService _brazilTaxService = new BrazilTaxService();

    public void ProcessInvoice(CarRental carRental)
    {
        var duration = carRental.Finish.Subtract(carRental.Start);
        var basicPayment = 0.0;
        if (duration.TotalHours <= 12.0)
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        else
            basicPayment = PriceByDay * Math.Ceiling(duration.TotalDays);

        var tax = _brazilTaxService.Tax(basicPayment);
        carRental.Invoice  = new Invoice(basicPayment, tax);
    }
}