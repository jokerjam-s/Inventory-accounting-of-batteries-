using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.ViewModels
{
    public class RegisterUserViewModel
    {
        [Display(Name = "ФИО")]
        [StringLength(50)]
        [Required(ErrorMessage = "ФИО обязательно для заполнения!")]
        [MinLength(5, ErrorMessage = "Минимальная длина ФИО 5 символов!")]
        public string userFio { get; set; }

        [Display(Name = "Дата приема")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата приема на работу обязательна для заполнения!")]
        public DateTime userPriem { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
