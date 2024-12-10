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
    public IActionResult GetAllCereals()
    {
        var cereals = _context.Cereals.ToList()
            .Select(s => s.ToCerealDTO());
        return Ok(cereals);
    }

    [HttpGet("{id}")]
    public IActionResult GetCerealById([FromRoute] int id)
    {
        var cereal = _context.Cereals.Find(id);
        
        if(cereal == null)
            return NotFound();
        
        return Ok(cereal);
    }

    [HttpPost]
    public IActionResult CreateCereal([FromBody] CreateCerealDTO cereal)
    {
        var cerealModel = cereal.ToCerealFromCreateDTO();
        _context.Cereals.Add(cerealModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCerealById), new { id = cerealModel.Id }, cerealModel);
    }
    
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateCerealRequestDTO updatedDto)
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

        _context.SaveChanges();

        return Ok(cerealModel.ToCerealDTO());
    }
}