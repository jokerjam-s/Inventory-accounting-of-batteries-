using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class BatteryInfo
    {
        public int Id { get; set; }

        [Display(Name = "Емкость")]
        [Range(0,50000, ErrorMessage = "Значение вне допустимого диапазона!")]
        public int capacity { get; set; }

        [Display(Name = "Наименование")]
        [StringLength(150)]
        [Required(ErrorMessage = "Наименование обязательно для заполнения!")]
        public string name { get; set; }

        [Display(Name = "№ партии")]
        [StringLength(50)]
        public string partnumber { get; set; }

        [Display(Name = "Серийный №")]
        [StringLength(50)]
        public string serial { get; set; }

        [Display(Name = "Списан")]
        public bool isDamage { get; set; }

        public ICollection<BatteryState> batteryState;

        public BatteryInfo()
        {
            batteryState = new List<BatteryState>();
        }
    }
}

