namespace Test.Dtos;

public class Image
{
    public int ImageId { get; init; }
    public string ImageBase64String { get; init; } = string.Empty;
    //Foreing key to cereal table
    public int CerealId { get; init; }
}