using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidaTuAbuelo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuidaTuAbuelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly CuidaTuAbueloContext _context;

        public AuthController(CuidaTuAbueloContext context)
        {
            _context = context;
        }

    }
}