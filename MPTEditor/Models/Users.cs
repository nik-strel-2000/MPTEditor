using System.ComponentModel.DataAnnotations;

namespace MPTEditor.Models
{
    public class Users
    {
        [Key]
        public int Id_User { get; set; }
        [EmailAddress(ErrorMessage = "Введите правильный Email")]
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 50 символов")]
        public string Password { get; set; }
        public int Position_id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AvatarURL { get; set; } 
    }
}
