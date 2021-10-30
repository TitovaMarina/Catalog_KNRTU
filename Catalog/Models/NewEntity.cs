using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class NewEntity
    {
        [DisplayName("Название")]        
        public string FieldName { get; set; }
        //[DisplayName("Длина")]
        //public int Length { get; set; } = 255;
        [DisplayName("Важно/Неважно")]
        public bool Importance { get; set; }
    }
}
