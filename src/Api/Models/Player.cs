namespace Api.Models;

public class Player
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public bool? IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}