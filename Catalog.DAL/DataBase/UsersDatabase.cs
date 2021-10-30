using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Catalog.DAL.Model;

namespace Catalog.DAL
{
    public class UsersDatabase
    {
        private const string connectionString = "Data Source=users.sqlite;Version=3;";

        public UsersDatabase()
        {
            if (File.Exists("users.sqlite"))
            {
                return;
            }

            try
            {
                SQLiteConnection.CreateFile("users.sqlite");
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand("create table users (login text primary key, password text, name text, surname text, dateOfBirth text)", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public string GetConnectionString 
        //{ 
        //    get { return connectionString; }
        //}
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool Register(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command1 = new SQLiteCommand("select exists (select 1 from users where login=@login)", connection))
            using (SQLiteCommand command2 = new SQLiteCommand("insert into users (login, password, name, surname, dateOfBirth) values (@login, @password, @name, @surname, date(@dateOfBirth))", connection))
            {
                try
                {
                    connection.Open();
                    command1.Parameters.AddWithValue("@login", user.Login);
                    bool exists = Convert.ToBoolean(command1.ExecuteScalar());
                    if (exists)
                        return false;

                    command2.Parameters.AddWithValue("@login", user.Login);
                    command2.Parameters.AddWithValue("@password", HashPassword(user.Password));
                    command2.Parameters.AddWithValue("@name", user.Name);
                    command2.Parameters.AddWithValue("@surname", user.Surname);
                    command2.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                    command2.ExecuteNonQuery();
                    user.CreateDatabase();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                    //return false;
                }
            }
        }

        public bool Authorize(string login, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand("select * from users where login=@login and password=@password", connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", HashPassword(password));
                    //command.ExecuteScalar();
                    //return true;
                    string exists = Convert.ToString(command.ExecuteScalar());
                    if (!String.IsNullOrEmpty(exists))
                        return true;
                    else
                        return false;

                }
                catch (SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                    //return false;
                }
            }
        }
    }
}
