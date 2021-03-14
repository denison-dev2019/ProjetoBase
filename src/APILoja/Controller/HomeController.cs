using Crosscutting.Enuns;
using Dados.Contextos;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios.Base;
using Dominio.Interfaces.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILoja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Bem Vindo! API Iniciada";
    }
}
