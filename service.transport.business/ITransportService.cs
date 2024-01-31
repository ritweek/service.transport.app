using System;
using service.transport.common.Entity;
namespace service.transport.business;

public interface ITransportService
{
    Task<IEnumerable<TransportationOption>> GetTransportationOptionsAsync();
    Task<TransportationOption> GetTransportationOptionAsync(int id);
    Task<TransportationOption> CreateTransportationOptionAsync(TransportationOption transportationOption);
    Task<bool> DeleteTransportationOptionAsync(int id);
    Task<TransportationOption> UpdateTransportationOptionAsync(int id, TransportationOption transportationOption);

}

