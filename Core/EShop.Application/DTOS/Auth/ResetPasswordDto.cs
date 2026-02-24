using System.ComponentModel.DataAnnotations;

namespace EShop.Application.DTOS.Auth
{
   public class ResetPasswordDto
    {
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string NewPasswordConfirm { get; set; }
    }
}
