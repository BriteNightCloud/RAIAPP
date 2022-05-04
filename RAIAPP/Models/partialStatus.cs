using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAIAPP.Models
{
    partial class Status
    {
        public string StatusColor
        {
            get
            {
                if (StatusName == "Выполнено")
                {
                    return "Green";
                }
                if (StatusName == "Запланировано")
                {
                    return "Blue";
                }
                if (StatusName == "Принята к исполнению")
                {
                    return "Orange";
                }
                return "Black";
            }
        }
    }
}
