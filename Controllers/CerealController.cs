using Test.DataContext;

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
        var cereals = _context.Cereals.ToList();
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
}