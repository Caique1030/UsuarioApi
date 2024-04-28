using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Models;

namespace UsuarioApi.Service;

public class UsuarioService { 

    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Cadastra(CreateUsuarioDto dto)
{
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

    if (!resultado.Succeeded)
    {
            throw new ApplicationException("Falha ao cadastrar usuário!");
    }
    
}

    public async Task<string> Login(LoginDto dto)
    {
        if (_signInManager != null)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);
            if (resultado != null && resultado.Succeeded)
            {
                // O login foi bem-sucedido, então vamos retornar normalmente

                var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.UserName.ToUpper());
                _tokenService.GenerateToken(usuario);
                var token = _tokenService.GenerateToken(usuario);

                return token;
            }
        }

        // Se chegamos aqui, o login falhou, então vamos lançar uma exceção
        throw new ApplicationException($"Failed to login {dto.UserName}");
    }


}
