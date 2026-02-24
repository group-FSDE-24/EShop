using System.ComponentModel.DataAnnotations;

namespace EShop.Application.DTOS.Auth;

public class ForgetPasswordDTO
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
    [Compare("NewPassword")]
    public string NewPasswordConfirm { get; set; }
}
