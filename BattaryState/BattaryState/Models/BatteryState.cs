using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class BatteryState
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Батарея")]
        public int BatteryInfoId { get; set;  }

        [Display(Name = "Дата/время измерений")]
        [DataType(DataType.DateTime)]
        public DateTime changeTime { get; set; }

        [Display(Name = "Текущий уровень")]
        public int current { get; set; }

        [Display(Name = "К-во циклов")]
        public int cycles { get; set; }

        [Display(Name = "% заряда")]
        public int percent { get; set; }

        [Display(Name = "Температура")]
        public int temper { get; set; }

        [Display(Name = "Терминал")]
        public int TerminalInfoId { get; set; }

        public BatteryInfo batteryInfo;

        public TerminalInfo terminalInfo;

    }
}
