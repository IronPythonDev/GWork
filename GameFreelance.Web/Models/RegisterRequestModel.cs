using System.ComponentModel.DataAnnotations;
using GameFreelance.Domain.Core.Entity;
using GameFreelance.Web.Utils;

namespace GameFreelance.Web.Models
{
    public class RegisterRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан Логин")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Не указано Имя")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Не указана Фамилия")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Не указан ИД от Аккаунта ВКонтакте")]
        public string VKontakteId { get; set; }
        
        [Required(ErrorMessage = "Не указан Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRememberUser { get; set; }
        public UserModel ConvertToUserModel()
        {
            return new UserModel{ Login = Login, FirstName = FirstName , LastName = LastName , Password = PasswordUtils.GetHashPassword(Password) , VKontakteId = VKontakteId , Id = Id};
        }
    }
}