using Application.Common;
using Application.Vehicles.Enums;

namespace Application.Vehicles
{
    public class VehicleDTO : IDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = null!;
        public int Mileage { get; set; }
        public VehicleColorEnumDTO Color { get; set; }
        public VehicleBrandsEnumDTO Brand { get; set; }
        public VehicleTypesEnumDTO Type { get; set; }
        public VehicleConditionsEnumDTO Condition { get; set; }
    }
}
