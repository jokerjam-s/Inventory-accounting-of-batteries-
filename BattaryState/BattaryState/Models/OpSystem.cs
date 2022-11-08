using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class OpSystem
    {
        public int Id { get; set; }

        [Display(Name = "Опер. система")]
        [StringLength(50)]
        [Required(ErrorMessage = "Наименование операционной системы обязательно для заполнения!")]
        public string osName { get; set; }

        public ICollection<TerminalInfo> terminalInfo { get; set; }

        public OpSystem()
        {
            terminalInfo = new List<TerminalInfo>();
        }
    }
}
