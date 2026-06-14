using Domain.Entities.Base;
using Domain.Entities.Concrete.Vehicles.Enums;
using Domain.Entities.Concrete.Vehicles.ValueObjects;

namespace Domain.Entities.Concrete.Vehicles
{
    public class Vehicle : EntityBase
    {
        public VehicleNameVO Name { get; private set; } = null!;
        public VehicleDescriptionVO Description { get; private set; } = null!;
        public VehicleModelVO Model { get; private set; } = null!;
        public VehicleYearVO Year { get; private set; } = null!;
        public VehicleLicensePlateVO LicensePlate { get; private set; } = null!;
        public VehicleMileageVO Mileage { get; private set; } = null!;
        public VehicleColorEnum Color { get; private set; }
        public VehicleBrandsEnum Brand { get; private set; }
        public VehicleTypesEnum Type { get; private set; }
        public VehicleConditionsEnum Condition { get; private set; }

             
        //Constructor privado. Sí o sí se pasa por las Factories estáticas garantizando integridad de datos
        private Vehicle() { }


        // Factory para usuario NUEVO
        public static Vehicle Create
        (
            //string id => De esto se encarga EntityBase
            string name,
            string description,
            string model,
            int year,
            string licensePlate,
            int mileage,
            VehicleColorEnum color,
            VehicleBrandsEnum brand,
            VehicleTypesEnum type,
            VehicleConditionsEnum condition
        )
        {
            return new Vehicle
            {
                //Id = Guid.NewGuid() => De esto se encarga EntityBase
                Name = VehicleNameVO.Create(name),
                Description = VehicleDescriptionVO.Create(description),
                Model = VehicleModelVO.Create(model),
                Year = VehicleYearVO.Create(year),
                LicensePlate = VehicleLicensePlateVO.Create(licensePlate),
                Mileage = VehicleMileageVO.Create(mileage),
                Color = color,
                Brand = brand,
                Type = type,
                Condition = condition
            };
        }


        // Factory para usuario proveniente de Base de Datos
        public static Vehicle Reconstitute
        (
            Guid id,
            string name,
            string description,
            string model,
            int year,
            string licensePlate,
            int mileage,
            VehicleColorEnum color,
            VehicleBrandsEnum brand,
            VehicleTypesEnum type,
            VehicleConditionsEnum condition
        )
        {
            var newVehicle = new Vehicle()
            {
                Name = VehicleNameVO.Create(name),
                Description = VehicleDescriptionVO.Create(description),
                Model = VehicleModelVO.Create(model),
                Year = VehicleYearVO.Create(year),
                LicensePlate = VehicleLicensePlateVO.Create(licensePlate),
                Mileage = VehicleMileageVO.Create(mileage),
                Color = color,
                Brand = brand,
                Type = type,
                Condition = condition
            };
            
            newVehicle.UpdateId(id);
            return newVehicle;
        }

        public void UpdateMileage(int kilometers) => Mileage = VehicleMileageVO.Create(kilometers);

    }


}





