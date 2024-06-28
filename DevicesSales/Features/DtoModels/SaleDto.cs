using System.ComponentModel.DataAnnotations;

namespace DevicesSales.Features.DtoModels
{
    public class SaleDto
    {
        public Guid? SaleId { get; set; }

        [Required, MaxLength(255)]
        public string? ProductName { get; set; }

        public uint? Price { get; set; }
    }
}
