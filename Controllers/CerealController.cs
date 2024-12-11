﻿using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.Dtos.Cereal;
using Test.Interfaces;
using Test.Mappers;

namespace Test.Controllers;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class CerealController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ICerealRepository _cerealRepo;
    
    public CerealController(ApplicationDBContext context, ICerealRepository cerealRepository)
    {
        _context = context;
        _cerealRepo = cerealRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCereals()
    {
        var cereals = await _cerealRepo.GetAllAsync();
        var collectedCereals = cereals.Select(s => s.ToCerealDTO());
        return Ok(collectedCereals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCerealById([FromRoute] int id)
    {
        var cereal = await _cerealRepo.GetByIdAsync(id);
        
        if(cereal == null)
            return NotFound();
        
        return Ok(cereal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCereal([FromBody] CreateCerealDTO cereal)
    {
        var cerealModel = cereal.ToCerealFromCreateDTO();
        await _cerealRepo.CreateAsync(cerealModel);
        return CreatedAtAction(nameof(GetCerealById), new { id = cerealModel.Id }, cerealModel);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCerealRequestDTO updatedDto)
    {
        var cerealModel = await _cerealRepo.UpdateAsync(id, updatedDto);
        if (cerealModel == null)
            return NotFound();

        return Ok(cerealModel.ToCerealDTO());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var cerealModel = await _cerealRepo.DeleteAsync(id);
        
        if(cerealModel == null)
            return NotFound();
        

        return NoContent();
    }
}