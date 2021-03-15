using Calculation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculation.Services
{
    public interface ICalculationService
    {
        Task<CalculationResult> CalculateAverageValueAndSum(IEnumerable<double> values);
    }
}
