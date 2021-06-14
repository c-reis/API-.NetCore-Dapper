using APIDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        [HttpGet]
        public IActionResult GetCargo()
        {
            try
            {
                return Ok(_cargoRepository.GetCargo());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
