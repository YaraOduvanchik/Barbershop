namespace Barbershop.Contracts.Models;

public class AdminDto : UserDto
{
    public string Login { get; set; }

    public string PasswordHash { get; set; }
}