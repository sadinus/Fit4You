namespace Fit4You.Core.Services
{
    public interface ICalculatorService
    {
        double CalculateBMI(int weight, int height);
        string GetMeaningOfBMI(double bmi);
    }
}