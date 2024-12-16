using Test.Dtos;

namespace Test.Interfaces;

public interface IImageRepository
{
    public Task<string> GetImageByIdAsync(int cerealId);
}