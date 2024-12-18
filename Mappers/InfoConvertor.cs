namespace Test.Mappers;

public static class InfoConvertor
{
    public static string ToManufacturersName(string manufacturerLetter)
    {
        switch (manufacturerLetter)
        {
            case "A":
                return "American Home Food Products";
            case "G":
                return "General Mills";
            case "K":
                return "Kelloggs";
            case "N":
                return "Nabisco";
            case "P":
                return "Post";
            case "Q":
                return "Quaker Oats";
            case "R":
                return "Ralston Purina";
            default:
                return "Unknown";
        }
    }

    public static string ToProductType(string typeLetter)
    {
        switch (typeLetter)
        {
            case "C":
                return "Cold";
            case "H":
                return "Hot";
            default:
                return "Unknown";
        }
    }
}