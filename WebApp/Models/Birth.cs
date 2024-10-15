namespace WebApp.Models;

public class BirthModel
{
    public string? Name { get; set; }
    public DateTime? Birthdate { get; set; }
    
    public bool IsValid()
    {
        if (Name.Length > 0 && DateTime.Now > Birthdate)
        {
            return true;
        }

        return false;
    }

    public int Birth()
    {
        return (int)((DateTime.Now - Birthdate).Value.TotalDays / 365);
    }
}