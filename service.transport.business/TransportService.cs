using Microsoft.Extensions.Logging;
using service.transport.common.Entity;
using service.transport.data;

namespace service.transport.business
{
    public class TransportService : ITransportService
    {
        private readonly ITransportRepo _repository;
        private readonly ILogger<TransportService> _logger;

        public TransportService(ITransportRepo repository, ILogger<TransportService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<TransportationOption>> GetTransportationOptionsAsync()
        {
            return await _repository.GetTransportationOptionsAsync();
        }

        public async Task<TransportationOption> GetTransportationOptionAsync(int id)
        {
            return await _repository.GetTransportationOptionAsync(id);
        }

        public async Task<TransportationOption> CreateTransportationOptionAsync(TransportationOption transportationOption)
        {
            return await _repository.CreateTransportationOptionAsync(transportationOption);
        }
        public async Task<bool> DeleteTransportationOptionAsync(int id)
        {
            try
            {
                return await _repository.DeleteTransportationOptionAsync(id);
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
                return await _repository.UpdateTransportationOptionAsync(id, transportationOption);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating transportation option with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}

