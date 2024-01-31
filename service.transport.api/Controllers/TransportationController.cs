using Microsoft.AspNetCore.Mvc;
using service.transport.business;
using service.transport.common.Entity;

[Route("api/[controller]")]
[ApiController]
public class TransportationController : ControllerBase
{
    private readonly ITransportService _service;
    private readonly ILogger<TransportationController> _logger;

    public TransportationController(ITransportService service, ILogger<TransportationController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransportationOption>>> GetTransportationOptions()
    {
        var options = await _service.GetTransportationOptionsAsync();
        return Ok(options);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TransportationOption>> GetTransportationOption(int id)
    {
        var option = await _service.GetTransportationOptionAsync(id);

        if (option == null)
        {
            return NotFound();
        }

        return Ok(option);
    }

    [HttpPost]
    public async Task<ActionResult<TransportationOption>> PostTransportationOption([FromBody] TransportationOption transportationOption)
    {
        var createdOption = await _service.CreateTransportationOptionAsync(transportationOption);
        return CreatedAtAction(nameof(GetTransportationOption), new { id = createdOption.Id }, createdOption);
    }

    // DELETE: api/transportation/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransportationOption(int id)
    {
        try
        {
            var success = await _service.DeleteTransportationOptionAsync(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error deleting transportation option with ID {id}: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    // PUT: api/transportation/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransportationOption(int id, [FromBody] TransportationOption transportationOption)
    {
        try
        {
            if (id != transportationOption.Id)
            {
                return BadRequest();
            }

            var updatedOption = await _service.UpdateTransportationOptionAsync(id, transportationOption);

            if (updatedOption != null)
            {
                return Ok(updatedOption);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating transportation option with ID {id}: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
}
