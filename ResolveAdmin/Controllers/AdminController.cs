using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolveAdmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Sudev Rao", "Sheela Rao", "Rashmi S"
        };

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Admin> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new Admin
            {
                EmployeeNumber = rng.Next(100, 110),
                EmployeeName = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
