using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Catalog
{
    //[Table("Entities")]
    public class Entity : INotifyPropertyChanged
    {
        public Entity(string entityName)
        {
            EntityName = entityName;
        }
        public Entity()
        {
            
        }
        //public int ID_Entity { get; set; }

        private string entityName;
        private string annotationFields;
        [Key]
        public string EntityName
        {
            get { return entityName; }
            set
            {
                entityName = value;
                OnPropertyChanged("EntityName");
            }
        }
        public string AnnotationFields
        {
            get { return annotationFields; }
            set
            {
                annotationFields = value;
                OnPropertyChanged("AnnotationFields");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        

    }
}
