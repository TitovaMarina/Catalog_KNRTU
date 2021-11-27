using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Catalog
{
    public class AuthorizedUser : IDataErrorInfo
    {
        [Key]
        public int UserID { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Name":
                        //Обработка ошибок для свойства Name
                        break;
                    case "LastName":
                        //smth
                        break;
                    case "Login":
                        //Обработка ошибок для свойства Position
                        break;
                    case "Password":
                        //Обработка ошибок для свойства Position
                        break;
                    default:
                        break;
                }
                return error;
            }
        }
        public string Error => throw new NotImplementedException();
    }
}
