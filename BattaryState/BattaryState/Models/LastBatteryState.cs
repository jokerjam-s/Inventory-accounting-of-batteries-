using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class LastBatteryState
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name ="Начало")]
        public DateTime beginChangeTime { get; set; }

        [Display(Name = "Окончание")]
        public DateTime lastChangeTime { get; set; }


        [Display(Name = "Батарея")]
        public int BatteryInfoId { get; set; }

        [Display(Name = "Терминал")]
        public int TerminalInfoId { get; set; }

        [Display(Name = "Начальный V")]
        public int beginVoltage { get; set; }

        [Display(Name = "Конечный V")]
        public int endVoltage { get; set; }

        [Display(Name = "Начальный %")]
        public int beginPercent { get; set; }

        [Display(Name = "Конечный %")]
        public int endPercent { get; set; }

        [Display(Name = "Ток")]
        public int currency { get; set; }

        [Display(Name = "Батарея")]
        public BatteryInfo batteryInfo { get; set; }

        [Display(Name = "Терминал")]
        public TerminalInfo terminalInfo { get; set; }

    }
}
