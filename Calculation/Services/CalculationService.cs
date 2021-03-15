using Calculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculation.Services
{
    public class CalculationService : ICalculationService
    {
        public Task<CalculationResult> CalculateAverageValueAndSum(IEnumerable<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            double sum = values.Sum();
            double average = 0.0;

            if (values.Any())
            {
                average = sum / values.Count();
            }

            var result = new CalculationResult { Avg = average, Sum = sum };
            return Task.FromResult(result);
        }
    }
}
