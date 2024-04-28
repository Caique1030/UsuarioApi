using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Data.Dtos
{
    public class LoginDto
    {
        [Required]
        public  string UserName { get; set; }
        [Required]
        public  string Password { get; set; }
    }
}
