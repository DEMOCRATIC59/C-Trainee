namespace Trainee.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty; // Марка (например, "Toyota")
        public string Model { get; set; } = string.Empty; // Модель (например, "Camry")
        public int Year { get; set; } // Год выпуска
        public string Color { get; set; } = string.Empty; // Цвет
        public decimal Price { get; set; } // Цена
        public VehicleType Type { get; set; } // Тип транспортного средства

        public enum VehicleType
        {
            Sedan,
            SUV,
            Truck,
            Coupe,
            Hatchback,
            Convertible,
            Van,
            Motorcycle
        }
    }
}
