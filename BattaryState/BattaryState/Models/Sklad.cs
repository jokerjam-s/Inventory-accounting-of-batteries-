using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class Sklad
    {
        public int Id { get; set; }

        [Display(Name = "Склад")]
        [StringLength(50)]
        [Required(ErrorMessage = "Название склада обязательно для заполнения!")]
        public string sklName { get; set; }

        public ICollection<TerminalInfo> terminalInfo { get; set; }


        public Sklad()
        {
            terminalInfo = new List<TerminalInfo>();
        }
    }
}
