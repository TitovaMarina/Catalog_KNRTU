using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Catalog.DAL.Model;

namespace Catalog.DAL.DataBase
{
    public class DocumentRepository
    {
        DataBaseHelpers _dataBaseHelper;
        public DocumentRepository(string fileName)
        {
            _dataBaseHelper = new DataBaseHelpers(fileName);
        }
         
        /// <summary>
        /// Get one exact Document from the table-Entity
        /// </summary>
        /// <param name="tableTitle"></param>
        /// <returns></returns>
        public OrderedDictionary GetDocumentByID(string tableTitle, int id)
        {
            string query = $"select * from \"{tableTitle}\" where id={id}";
            OrderedDictionary res = new OrderedDictionary();
            DataTable dt = _dataBaseHelper.ReadRows(query);
            foreach (DataColumn col in dt.Columns)
            {
                res.Add(col.ColumnName, dt.AsEnumerable().Select(row => row.Field<string>(col.ColumnName)).ToList());
            }

            return res;
        }

        public bool AddDocument(string tableTitle, Document doc)
        {
            string query = $"insert into \"{tableTitle}\" (" + string.Join(", ", doc.Fields.Keys.Cast<string>().Select(x => $"\"{x}\"")) + ") values (" + string.Join(", ", Enumerable.Repeat("?", doc.Fields.Count)) + ")";
            SQLiteParameter[] parameters = new SQLiteParameter[doc.Fields.Count];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = new SQLiteParameter(DbType.String, doc.Fields[i]);
            }
            return _dataBaseHelper.ExecuteNonQuery(query, parameters);
        }

        public bool EditDocument(string tableTitle, int id, Document doc)
        {
            string query = $"update \"{tableTitle}\" set " + string.Join(", ", doc.Fields.Keys.Cast<string>().Select(x => $"\"{x}\"=?")) + " where id=@id";
            SQLiteParameter[] parameters = new SQLiteParameter[doc.Fields.Count + 1];

            parameters[0] = new SQLiteParameter("@id", id);
            for (int i = 1; i < parameters.Length; i++)
            {
                parameters[i] = new SQLiteParameter(DbType.String, doc.Fields[i - 1]);
            }
            return _dataBaseHelper.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteDocument(string tableTitle, int id)
        {
            string query = $"delete from \"{tableTitle}\" where id=@id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);
            return _dataBaseHelper.ExecuteNonQuery(query, parameter);
        }

    }
}
