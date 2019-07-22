namespace VehiclesExtension.Interface
{
    public interface IVehicle
    {
        double Fuel {get; }
        double CostNorm {get; }
        double TankCapacity {get; }

        void Drive(double distance);

        void Refuel(double liters);
    }
}
