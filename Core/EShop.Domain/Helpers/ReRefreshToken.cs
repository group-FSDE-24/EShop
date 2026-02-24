namespace EShop.Domain.Helpers;

public class RePasswordToken
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime CreatedDate { get; set; }
}
