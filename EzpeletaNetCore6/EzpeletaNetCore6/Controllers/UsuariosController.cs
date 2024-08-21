using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EzpeletaNetCore6.Data;
using EzpeletaNetCore6.Models;

namespace EzpeletaNetCore6.Controllers;

public class UsuariosController : Controller
{
    private readonly RoleManager<IdentityRole> _rolManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;
    public UsuariosController(RoleManager<IdentityRole> rolManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        _rolManager = rolManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task<JsonResult> GuardarRol(string rol)
    {
        bool resultado = false;
        var rolSuperusuarioExiste = _context.Roles.Where(r => r.Name == rol).SingleOrDefault();
        if (rolSuperusuarioExiste == null)
        {
            var roleResult = await _rolManager.CreateAsync(new IdentityRole(rol));
            resultado = roleResult.Succeeded;
        }

        return Json(resultado);
    }

    public async Task<JsonResult> GuardarUsuario(string username, string email, string password, string rol)
    {
        //CREAR LA VARIABLE USUARIO CON TODOS LOS DATOS
        var user = new IdentityUser { UserName = username, Email = email };

        //EJECUTAR EL METODO CREAR USUARIO PASANDO COMO PARAMETRO EL OBJETO CREADO ANTERIORMENTE Y LA CONTRASEÑA DE INGRESO
        var result = await _userManager.CreateAsync(user, password);

        //BUSCAR POR MEDIO DE CORREO ELECTRONICO ESE USUARIO CREADO PARA BUSCAR EL ID
        var usuario = _context.Users.Where(u => u.Email == email).SingleOrDefault();

        await _userManager.AddToRoleAsync(usuario, "Socio");

        return Json(result.Succeeded);
    }

}