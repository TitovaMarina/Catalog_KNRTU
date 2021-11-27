using System.ComponentModel;

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
