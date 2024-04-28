using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }


    }
}
