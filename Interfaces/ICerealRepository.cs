using Test.Dtos.Cereal;
using Test.Models;

namespace Test.Interfaces;

public interface ICerealRepository
{
    public Task<List<Cereal>> GetAllAsync();
    public Task<Cereal?> GetByIdAsync(int id);
    public Task<Cereal> CreateAsync(Cereal cereal);
    public Task<Cereal?> UpdateAsync(int id, UpdateCerealRequestDTO cerealDto);
    public Task<Cereal?> DeleteAsync(int id);
}