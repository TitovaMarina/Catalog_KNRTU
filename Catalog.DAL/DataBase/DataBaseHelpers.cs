using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Catalog.DAL.DataBase
{
    public class DataBaseHelpers
    {
        private string _fileName;
        private string _connectionString;

        public DataBaseHelpers(string fileName)
        {
            _fileName = fileName;
            _connectionString = $"Data Source={fileName}.sqlite;Version=3;";
        }

        public void CreateFile()
        {
            try
            {
                SQLiteConnection.CreateFile(_fileName);
                ExecuteFirstQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void ExecuteFirstQuery()
        {
            string query = "create table tablesInfo (name text primary key, annotationFields text not null)";
            ExecuteNonQuery(query);
        }


        public DataTable ReadRows(string query, string annotationFieldsMask = null)
        {
            DataTable table = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            table.Columns.Add(reader.GetName(0));

                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                if (annotationFieldsMask == null || annotationFieldsMask[i - 1] == '1')
                                {
                                    table.Columns.Add(reader.GetName(i));
                                }
                            }
                        }

                        object[] values = new object[reader.FieldCount];

                        while (reader.Read())
                        {
                            DataRow row = table.NewRow();
                            reader.GetValues(values);
                            row.ItemArray = values.Where((x, i) => i == 0 || annotationFieldsMask == null || (i > 0 && annotationFieldsMask[i - 1] == '1')).ToArray();
                            table.Rows.Add(row);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return table;
            }
        }


        public bool ExecuteNonQuery(string query, params SQLiteParameter[] parameters)
        {
            bool success = false;
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddRange(parameters);
                    //MessageBox.Show(command.CommandText.ToString());
                    command.ExecuteNonQuery();
                    success = true;
                }
                catch (SQLiteException ex)
                {
                    success = false;
                    throw new Exception(ex.Message);
                }
                return success;
            }
        }

        public object ExecuteScalar(string query, params SQLiteParameter[] parameters)
        {
            object res = null;
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddRange(parameters);
                    res = command.ExecuteScalar();
                }
                catch (SQLiteException ex)
                {
                    res = 0;
                    throw new Exception(ex.Message);
                }
                return res;
            }
        }
    }
}
