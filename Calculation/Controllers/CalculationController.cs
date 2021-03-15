using Calculation.Models;
using Calculation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        /// <summary>
        /// Calculates sum and average value
        /// </summary>
        /// <param name="customers">Customers</param>
        /// <returns>Sum and average value for specified customers</returns>
        [HttpPost]
        public async Task<ActionResult<CalculationResult>> CalculateAverageValueAndSum(IEnumerable<double> values)
        {
            // TODO: Create integration tests, container, move to Azure and make services communicating to each other
            var results = await _calculationService.CalculateAverageValueAndSum(values);
            return Ok(results);
        }
    }
}
