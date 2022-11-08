using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class TerminalInfo
    {
        public int Id { get; set; }

        [Display(Name ="Инв. №")]
        [StringLength(50)]
        [Required(ErrorMessage = "Инв. № обязателен для заполнения!")]
        public string name { get; set; }

        [Display(Name = "Серийный №")]
        [StringLength(100)]
        [Required(ErrorMessage = "Серийный номер обязателен для заполнения!")]
        public string serial { get; set; }

        [Display(Name = "Модель")]
        public int ModelTSDId { get; set; }

        [Display(Name = "Год пр-ва")]
        [Range(2000, 2100, ErrorMessage = "Значение года вне допустимого диапазона!")]
        public int prodYear { get; set; }

        [Display(Name = "Срок гарантии")]
        [DataType(DataType.Date)]
        public DateTime? garantSrok { get; set; }

        [Display(Name = "Ответственный")]
        [StringLength(30)]
        public string otvetstv { get; set; }

        [Display(Name = "МАС адрес")]
        [StringLength(20)]
        public string macadr { get; set; }

        [Display(Name = "Списан")]
        public bool isDamage { get; set; }

        [Display(Name = "Дата списания")]
        [DataType(DataType.Date)]
        public DateTime? dateDamage { get; set; } 

        [Display(Name = "Причина списания")]
        public string dismNotes { get; set; }

        [Display(Name ="Резерв")]
        public bool isReserv { get; set; }

        [Display(Name = "Ремонт")]
        public bool isRemont { get; set; }

        [Display(Name = "Причина ремонта")]
        public string remNotes { get; set; }

        [Display(Name = "Склад")]
        public int SkladId { get; set; }

        [Display(Name = "Оп. система")]
        public int OpSystemId { get; set; }

        public  ICollection<BatteryState> batteryStates { get; set; }

        public ModelTSD modelTSD { get; set; }

        public Sklad sklad { get; set; }

        public OpSystem opsystem { get; set; }

        public TerminalInfo()
        {
            batteryStates = new List<BatteryState>();
        }

    }
}
