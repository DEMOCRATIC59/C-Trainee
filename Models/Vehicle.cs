using System.ComponentModel.DataAnnotations;

namespace Trainee.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Make is required")]
        [StringLength(50, ErrorMessage = "Make cannot be longer than 50 characters")]
        public string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters")]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public VehicleType Type { get; set; }

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