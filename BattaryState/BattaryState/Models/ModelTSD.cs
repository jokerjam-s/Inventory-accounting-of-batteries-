using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattaryState.Models
{
    public class ModelTSD
    {
        public int Id { get; set; }

        [Display(Name = "Модель ТСД")]
        [StringLength(100)]
        [Required(ErrorMessage = "Наименование модели обязательно для заполнения!")]
        public string modName { get; set; }

        public ICollection<TerminalInfo> terminalInfo { get; set; }

        public ModelTSD()
        {
            terminalInfo = new List<TerminalInfo>();
        }

    }
}
