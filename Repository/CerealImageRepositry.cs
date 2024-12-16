using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.Dtos;
using Test.Dtos.Cereal;
using Test.Interfaces;
using Test.Models;

namespace Test.Repository;

public class CerealImageRepositry : IImageRepository
{
    private readonly ApplicationDBContext _dataContext;

    public CerealImageRepositry(ApplicationDBContext context)
    {
        _dataContext = context;
    }
    
    public async Task<string> GetImageByIdAsync(int id)
    {
        var image = await _dataContext.Images.FirstOrDefaultAsync(i => i.CerealId == id);
        return image.ImageBase64String;
    }
}