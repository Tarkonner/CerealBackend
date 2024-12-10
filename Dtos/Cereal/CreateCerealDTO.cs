namespace Test.Dtos.Cereal;

public class CreateCerealDTO
{
    public string Name { get; init; } = string.Empty;
    public string Manufacturer { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public int Calories { get; init; }
    public int Protein { get; init; }
    public int Fat { get; init; }
    public int Sodium { get; init; }
    public float Fiber { get; init; }
    public float Carbohydrates { get; init; }
    public int Sugars { get; init; }
    public int Potassium { get; init; }
    public int Vitamins { get; init; }
    public int Shelf { get; init; }
    public float Weight { get; init; }
    public float Cups { get; init; }
    public string Rating { get; init; } = string.Empty;
}