using System;
using System.ComponentModel.DataAnnotations;

namespace MPTEditor.Models
{
    public class Listeners
    {
        [Key]
        public int Id_Listener { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [EmailAddress(ErrorMessage = "Введите правильный Email")]
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }
        public Int64 NumberPhone { get; set; }
    }
}
