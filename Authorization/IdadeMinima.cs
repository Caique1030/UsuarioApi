using Microsoft.AspNetCore.Authorization;

namespace UsuarioApi.Authorization
{
    public class IdadeMinima : IAuthorizationRequirement
    {
        public int Idade { get; }

        public IdadeMinima(int idade)
        {
            Idade = idade;
        }
    }

}
