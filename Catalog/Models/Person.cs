using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Catalog
{
    //[Table("Person")]
    public class Person : INotifyPropertyChanged
    {
        [Key]
        public int ID_Person { get; set; }

        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string address;
        private string eyecolor;
        private string telephone;
        //[Required]
        [DisplayName("Firsttt Name")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string DateOfBirth
        {
            get 
            {
                //if (String.IsNullOrEmpty(dateOfBirth.ToString()))
                //    dateOfBirth = DateTime.Now;
                return dateOfBirth; 
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("IsSmart");
            }
        }
        public string EyeColor
        {
            get { return eyecolor; }
            set
            {
                eyecolor = value;
                OnPropertyChanged("IsSingle");
            }
        }
        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                OnPropertyChanged("Telephone");
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
