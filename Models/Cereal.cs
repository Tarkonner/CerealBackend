namespace Test.Models;

public class Cereal
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }
    public int Sodium { get; set; }
    public float Fiber { get; set; }
    public float Carbohydrates { get; set; }
    public int Sugars { get; set; }
    public int Potassium { get; set; }
    public int Vitamins { get; set; }
    public int Shelf { get; set; }
    public float Weight { get; set; }
    public float Cups { get; set; }
    public string Rating { get; set; } = string.Empty;
}