using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Models;
using UsuarioApi.Service;

namespace UsuarioApi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[Controller]")]
public class UsuarioController:ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastroUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastra(dto);
        return Ok("Usuário cadastrado!");

    }
    [HttpPost("login")]
    public async Task<IActionResult> Loginasync(LoginDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }
}
