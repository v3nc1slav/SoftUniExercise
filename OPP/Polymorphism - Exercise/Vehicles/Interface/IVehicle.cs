
namespace Vehicles.Interface
{
    public interface IVehicle
    {
        double Fuel {get; }
        double CostNorm {get; }

        void Drive(double distance);

        void Refuel(double liters);
    }
}
