using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidaTuAbuelo.DataAccess;
using CuidaTuAbuelo.Logic;
using CuidaTuAbuelo.Models;
using CuidaTuAbuelo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuidaTuAbuelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly CuidaTuAbueloContext _context;

        public AuthController(CuidaTuAbueloContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> login(Auth login)
        {
            var user = await _context.Users.Where(w => w.email == login.email).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.password == login.password)
                {
                    if (user.status)
                    {
                        user.password = "****";
                        return Json(new CommandResult<Users>(true, "login correcto", user));
                    }
                    else
                    {
                        return Json(new CommandResult<Auth>(false, "Usuario inactivo", login));
                    }
                }
                else
                {
                    return Json(new CommandResult<Auth>(false, "Contraseña incorrecta", login));
                }
            }
            return Json(new CommandResult<Auth>(false, "Usuario no encontrado", login));
        }
    }
}