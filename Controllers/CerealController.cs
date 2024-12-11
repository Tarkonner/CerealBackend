using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.Dtos.Cereal;
using Test.Mappers;

namespace Test.Controllers;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class CerealController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    
    public CerealController(ApplicationDBContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCereals()
    {
        var cereals = await _context.Cereals.ToListAsync();
        var collectedCereals = cereals.Select(s => s.ToCerealDTO());
        return Ok(collectedCereals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCerealById([FromRoute] int id)
    {
        var cereal = await _context.Cereals.FindAsync(id);
        
        if(cereal == null)
            return NotFound();
        
        return Ok(cereal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCereal([FromBody] CreateCerealDTO cereal)
    {
        var cerealModel = cereal.ToCerealFromCreateDTO();
        await _context.Cereals.AddAsync(cerealModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCerealById), new { id = cerealModel.Id }, cerealModel);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCerealRequestDTO updatedDto)
    {
        var cerealModel = _context.Cereals.FirstOrDefault(x => x.Id == id);
        if (cerealModel == null)
            return NotFound();
        
        cerealModel.Name = updatedDto.Name;
        cerealModel.Manufacturer = updatedDto.Manufacturer;
        cerealModel.Type = updatedDto.Type;
        cerealModel.Rating = updatedDto.Rating;
        //Food info
        cerealModel.Calories = updatedDto.Calories;
        cerealModel.Protein = updatedDto.Protein;
        cerealModel.Fat = updatedDto.Fat;
        cerealModel.Sodium = updatedDto.Sodium;
        cerealModel.Fiber = updatedDto.Fiber;
        cerealModel.Carbohydrates = updatedDto.Carbohydrates;
        cerealModel.Sugars = updatedDto.Sugars;
        cerealModel.Potassium = updatedDto.Potassium;
        cerealModel.Vitamins = updatedDto.Vitamins;
        cerealModel.Shelf = updatedDto.Shelf;
        cerealModel.Weight = updatedDto.Weight;
        cerealModel.Cups = updatedDto.Cups;

        await _context.SaveChangesAsync();

        return Ok(cerealModel.ToCerealDTO());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var cerealModel = _context.Cereals.FirstOrDefault(x => x.Id == id);
        
        if(cerealModel == null)
            return NotFound();
        
        _context.Cereals.Remove(cerealModel);
        
        await _context.SaveChangesAsync();

        return NoContent();
    }
}