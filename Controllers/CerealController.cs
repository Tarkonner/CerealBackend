using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.Dtos;
using Test.Dtos.Cereal;
using Test.Interfaces;
using Test.Mappers;

namespace Test.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController] // Indicates that this is an API controller
public class CerealController : ControllerBase
{
    private readonly ApplicationDBContext _context; // The database context for interacting with the database
    private readonly ICerealRepository _cerealRepo; // Repository for handling cereal-specific database operations
    
    public CerealController(ApplicationDBContext context, ICerealRepository cerealRepository)
    {
        _context = context; // Injected database context
        _cerealRepo = cerealRepository; // Injected cereal repository
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCereals()
    {
        // Retrieves all cereals and sorts them by their rating
        var cereals = await _cerealRepo.GetAllAsync();
        var sortedCereal = cereals.OrderBy(c => c.Rating);
        return Ok(sortedCereal); // Returns the sorted list of cereals
    }
    
    [HttpGet("product_info")]
    [ProducesResponseType(200, Type = typeof(ICollection<CerealPackageInfo>))] // Specifies the expected response type and status code
    public async Task<IActionResult> GetCerealsProductInfoAsync()
    {
        try
        {
            // Retrieves all cereals and maps them to package information DTOs
            var cereals = await _cerealRepo.GetAllAsync();
            var collectedPackageInfo = cereals.Select(c => c.ToCerealPackageinfo()).ToList();
            var sortedCereal = collectedPackageInfo.OrderBy(c => c.Rating);

            return Ok(sortedCereal); // Returns sorted cereal package information
        }
        catch (Exception e)
        {
            // Returns a 500 error if something goes wrong
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching cereals.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCerealById([FromRoute] int id)
    {
        // Retrieves a cereal by its unique ID
        var cereal = await _cerealRepo.GetByIdAsync(id);
        
        if (cereal == null)
            return NotFound(); // Returns 404 if the cereal is not found
        
        return Ok(cereal); // Returns the cereal data
    }

    [HttpPost]
    public async Task<IActionResult> CreateCereal([FromBody] CreateCerealDTO cereal)
    {
        // Maps the DTO to the model and creates a new cereal entry
        var cerealModel = cereal.ToCerealFromCreateDTO();
        await _cerealRepo.CreateAsync(cerealModel);

        // Returns 201 Created response with the newly created cereal's details
        return CreatedAtAction(nameof(GetCerealById), new { id = cerealModel.Id }, cerealModel);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCerealRequestDTO updatedDto)
    {
        // Updates an existing cereal based on its ID and the provided DTO
        var cerealModel = await _cerealRepo.UpdateAsync(id, updatedDto);

        if (cerealModel == null)
            return NotFound(); // Returns 404 if the cereal does not exist

        // Maps the updated model to a DTO and returns it
        return Ok(cerealModel.ToCerealDTO());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Deletes a cereal by its ID
        var cerealModel = await _cerealRepo.DeleteAsync(id);
        
        if (cerealModel == null)
            return NotFound(); // Returns 404 if the cereal does not exist
        
        return NoContent(); // Returns 204 No Content if deletion is successful
    }
}
