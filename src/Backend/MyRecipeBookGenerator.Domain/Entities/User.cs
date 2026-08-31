namespace MyRecipeBookGenerator.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
    public string Name { get; set; } = string.Empty;
    public string Passoword { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
}
