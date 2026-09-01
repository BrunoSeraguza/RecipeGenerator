namespace MyRecipeBookGenerator.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } =  Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
    public string Name { get; set; } = string.Empty;
    public string Passoword { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
}
