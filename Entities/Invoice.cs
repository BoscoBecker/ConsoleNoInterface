using System.Globalization;

namespace ConsoleInterface.Entities;

public class Invoice(double basicPayment, double tax) {
    private double BasicPayment { get; set; } = basicPayment;
    private double Tax { get; set; } = tax;

    public double TotalPyment => BasicPayment + Tax;

    public override string ToString()
    {
        return "=============INVOICE=============" + "\n" +
               "Basic payment:" + BasicPayment.ToString("F2", CultureInfo.InvariantCulture) + "\n" +
               "Tax: " + Tax.ToString("F2", CultureInfo.InvariantCulture) + "\n" +
               "Total payment: " + TotalPyment.ToString("F2", CultureInfo.InvariantCulture) + "\n" +
               "=============INVOICE=============";
    }
}