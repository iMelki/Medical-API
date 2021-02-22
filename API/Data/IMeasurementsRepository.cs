using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public interface IMeasurementsRepository
    {
         Task<Measurement> Register (Measurement measurement);
         Task<List<Measurement>> GetMeasurements();
    }
}