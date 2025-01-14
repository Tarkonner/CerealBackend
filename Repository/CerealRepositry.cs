using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.Dtos.Cereal;
using Test.Interfaces;
using Test.Models;

namespace Test.Repository;

public class CerealRepositry : ICerealRepository
{
    private readonly ApplicationDBContext _context;
    public CerealRepositry(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Cereal>> GetAllAsync()
    {
        return await _context.Cereals.ToListAsync();
    }

    public async Task<Cereal?> GetByIdAsync(int id)
    {
        var cerealModel = await _context.Cereals.FindAsync(id);
        return cerealModel ?? null;
    }

    public async Task<Cereal> CreateAsync(Cereal cereal)
    {
        await _context.Cereals.AddAsync(cereal);
        await _context.SaveChangesAsync();
        return cereal;
    }

    public async Task<Cereal?> UpdateAsync(int id, UpdateCerealRequestDTO cerealDto)
    {
        var cerealModel = await _context.Cereals.FirstOrDefaultAsync(c => c.Id == id);
        if(cerealModel == null)
            return null;
        
        cerealModel.Name = cerealDto.Name;
        cerealModel.Manufacturer = cerealDto.Manufacturer;
        cerealModel.Type = cerealDto.Type;
        cerealModel.Rating = cerealDto.Rating;
        //Food info
        cerealModel.Calories = cerealDto.Calories;
        cerealModel.Protein = cerealDto.Protein;
        cerealModel.Fat = cerealDto.Fat;
        cerealModel.Sodium = cerealDto.Sodium;
        cerealModel.Fiber = cerealDto.Fiber;
        cerealModel.Carbohydrates = cerealDto.Carbohydrates;
        cerealModel.Sugars = cerealDto.Sugars;
        cerealModel.Potassium = cerealDto.Potassium;
        cerealModel.Vitamins = cerealDto.Vitamins;
        cerealModel.Shelf = cerealDto.Shelf;
        cerealModel.Weight = cerealDto.Weight;
        cerealModel.Cups = cerealDto.Cups;
        
        await _context.SaveChangesAsync();
        
        return cerealModel;
    }

    public async Task<Cereal?> DeleteAsync(int id)
    {
        var cereal = await _context.Cereals.FirstOrDefaultAsync(x => x.Id == id);
        if(cereal == null)
            return null;
        
        _context.Cereals.Remove(cereal);
        await _context.SaveChangesAsync();
        return cereal;
    }
}