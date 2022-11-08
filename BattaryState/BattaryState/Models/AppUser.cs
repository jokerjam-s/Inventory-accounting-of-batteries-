using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace BattaryState.Models
{
    public class AppUser : IdentityUser<int>
    {
        [Display(Name = "ФФИО")]
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
        public DateTime? userDismis { get; set; }

    }
}
