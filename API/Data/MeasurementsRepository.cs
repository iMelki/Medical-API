using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MeasurementsRepository : IMeasurementsRepository
    {
        private readonly DataContext _context;

        public MeasurementsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Measurement> Register(Measurement measurement)
        {
            await _context.Measurements.AddAsync(measurement);
            await _context.SaveChangesAsync();

            return measurement;
        }

        public async Task<List<Measurement>> GetMeasurements()
        {
            List<Measurement> measurements = await _context.Measurements.ToListAsync();

            return measurements;
        }
    }
}