using Catalog.DAL.DataBase;
using System;

namespace Catalog.DAL.Model
{
    public class User
    {
        public DataBaseHelpers Db { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(string name, string surname, DateTime dateOfBirth, string login, string password)
        {
            Db = null;
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
        public User(string login, string password)
        {
            Db = null;
            Login = login;
            Password = password;
            Name = "-";
            Surname = "-";
            DateOfBirth = new DateTime();
        }

        public void CreateDatabase()
        {
            Db = new DataBaseHelpers(Login);
            Db.CreateFile();
        }
    }
}
