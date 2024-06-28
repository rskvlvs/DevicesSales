using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevicesSales.Features.DtoModels
{
    public class ClientDto
    {
        [Required, MaxLength(255)]
        public string? Name { get; set; }

        [Required, MaxLength(255)]
        public string? Surname { get; set; }

        [Required, MaxLength(255), EmailAddress]
        public string? Email { get; set; }

    }
}
