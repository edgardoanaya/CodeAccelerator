using System.ComponentModel.DataAnnotations;

namespace SoftwareOne.BaseLine.EntitiesDto.Request
{
    public class LoginRequest
    {
        [Required]
        public string User { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}