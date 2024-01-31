using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using service.transport.common.Entity;

namespace service.transport.data
{
    public class TransportRepo : ITransportRepo
    {
        private readonly TransportDbContext _context;
        private readonly ILogger<TransportRepo> _logger;

        public TransportRepo(TransportDbContext context, ILogger<TransportRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TransportationOption>> GetTransportationOptionsAsync()
        {
            return await _context.TransportationOptions.ToListAsync();
        }

        public async Task<TransportationOption> GetTransportationOptionAsync(int id)
        {
            return await _context.TransportationOptions.FindAsync(id);
        }

        public async Task<TransportationOption> CreateTransportationOptionAsync(TransportationOption transportationOption)
        {
            _context.TransportationOptions.Add(transportationOption);
            await _context.SaveChangesAsync();
            return transportationOption;
        }

        public async Task<bool> DeleteTransportationOptionAsync(int id)
        {
            try
            {
                var option = await _context.TransportationOptions.FindAsync(id);

                if (option == null)
                {
                    return false;
                }

                _context.TransportationOptions.Remove(option);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting transportation option with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<TransportationOption> UpdateTransportationOptionAsync(int id, TransportationOption transportationOption)
        {
            try
            {
                if (id != transportationOption.Id)
                {
                    return null;
                }

                _context.Entry(transportationOption).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationOptionExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }

                return transportationOption;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating transportation option with ID {id}: {ex.Message}");
                throw;
            }
        }

        private bool TransportationOptionExists(int id)
        {
            return _context.TransportationOptions.Any(e => e.Id == id);
        }
    }
}

