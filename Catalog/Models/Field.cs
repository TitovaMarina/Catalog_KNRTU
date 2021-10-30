using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    //простенький класс для бинда данных (в шаблонах gridcolumn забинжены поля этого класса)
    public class Field
    {
        public Field(string title)
        {
            Title = title;
            FValue = "";
        }
        public Field(string title, string value)
        {
            Title = title;
            FValue = value;
        }
        public Field() { }
        public string Title { get; set; }
        public string FValue { get; set; }
    }
}
