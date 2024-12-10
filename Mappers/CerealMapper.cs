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
            Manufacturer = cere.Manufacturer,
            Type = cere.Type,
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
}