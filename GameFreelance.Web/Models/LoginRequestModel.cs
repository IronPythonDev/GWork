using System.ComponentModel.DataAnnotations;

namespace GameFreelance.Web.Models
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Не указан логин ")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}