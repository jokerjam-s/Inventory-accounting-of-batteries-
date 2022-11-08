using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        [StringLength(50)]
        [Required(ErrorMessage = "ФИО обязательно для заполнения!")]
        [MinLength(5, ErrorMessage = "Минимальная длина ФИО 5 символов!")]
        public string userFio { get; set; }

        [Display(Name = "Дата приема")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата приема на работу обязательна для заполнения!")]
        public DateTime userPriem { get; set; }

        [Display(Name = "Дата увольнения")]
        [DataType(DataType.Date)]
        public DateTime? userDismiss { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
