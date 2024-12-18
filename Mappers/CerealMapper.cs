using Test.Dtos;
using Test.Dtos.Cereal;
using Test.Models;

namespace Test.Mappers;

public static class CerealMapper
{
    public static CerealDTO ToCerealDTO(this Cereal cere)
    {
        return new CerealDTO
        {
            Id = cere.Id,
            Name = cere.Name,
            Manufacturer = InfoConvertor.ToManufacturersName(cere.Manufacturer),
            Type = InfoConvertor.ToProductType(cere.Type),
            Rating = cere.Rating,
        };
    }

    public static Cereal ToCerealFromCreateDTO(this CreateCerealDTO simpleCereal)
    {
        return new Cereal
        {
            //In Cereal DTO
            Name = simpleCereal.Name,
            Manufacturer = simpleCereal.Manufacturer,
            Type = simpleCereal.Type,
            Rating = simpleCereal.Rating,
            //Food info
            Calories = 0,
            Protein = 0,
            Fat = 0,
            Sodium = 0,
            Fiber = 0,
            Carbohydrates = 0,
            Sugars = 0,
            Potassium = 0,
            Vitamins = 0,
            Shelf = 0,
            Weight = 0,
            Cups = 0
        };
    }
    
    public static CerealPackageInfo ToCerealPackageinfo(this Cereal cerealModel)
    {
        return new CerealPackageInfo
        {
            Id = cerealModel.Id,
            Name = cerealModel.Name,
            Manufacturer = InfoConvertor.ToManufacturersName(cerealModel.Manufacturer),
            Type = InfoConvertor.ToProductType(cerealModel.Type),
            Rating = cerealModel.Rating
        };
    }
}