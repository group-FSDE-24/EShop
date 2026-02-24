namespace EShop.Domain.Helpers;

public class RefreshToken
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime CreatedDate { get; set; }
}
