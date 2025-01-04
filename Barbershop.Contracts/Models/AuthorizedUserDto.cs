namespace Barbershop.Contracts.Models;

public class AuthorizedUserDto : EntityDto
{
    public string Login { get; set; }
    public bool IsAdmin { get; set; }
}