using System.ComponentModel.DataAnnotations;

namespace DevicesSales.Features.DtoModels
{
    public class LoginDto
    {
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
    }
}
