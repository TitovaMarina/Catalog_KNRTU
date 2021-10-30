using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Catalog.DAL.DataBase
{
    public class EntityRepository
    {
        DataBaseHelpers _dataBaseHelper;
        public EntityRepository(string fileName)
        {
            _dataBaseHelper = new DataBaseHelpers(fileName);
        }
        public bool CreateNewEntity(string tableTitle, IEnumerable<string> fieldsNames, bool[] annotationFields)
        {
            string query = $"select exists (select 1 from tablesInfo where name=@name)";
            SQLiteParameter parameter1 = new SQLiteParameter("@name", tableTitle);

            object res = _dataBaseHelper.ExecuteScalar(query, parameter1);
            if (res == null || Convert.ToBoolean(res))
                return false;

            query = $"create table \"{tableTitle}\" (id integer primary key autoincrement, " + string.Join(", ", fieldsNames.Select(x => $"\"{x}\" text")) + ")";

            if (!_dataBaseHelper.ExecuteNonQuery(query))
                return false;

            string annotationFieldsMask = "";
            for (int i = 0; i < annotationFields.Length; i++)
            {
                annotationFieldsMask += annotationFields[i] ? '1' : '0';
            }
            query = $"insert into tablesInfo (name, annotationFields) values (@name, @annotationFields)";
            SQLiteParameter parameter2 = new SQLiteParameter("@annotationFields", annotationFieldsMask);

            _dataBaseHelper.ExecuteNonQuery(query, parameter1, parameter2);

            return true;
        }
        public IEnumerable<string> GetEntities()
        {
            string query = "select name from tablesInfo";
            return _dataBaseHelper.ReadRows(query).AsEnumerable().Select(row => row.Field<string>(0));
        }
        public OrderedDictionary GetEntityAnnotationFieldList(string tableTitle)
        {
            string query = "select annotationFields from tablesInfo where name=@name";
            SQLiteParameter parameter = new SQLiteParameter("@name", tableTitle);
            string annotationFields = Convert.ToString(_dataBaseHelper.ExecuteScalar(query, parameter));

            query = $"select * from \"{tableTitle}\"";
            DataTable dt = _dataBaseHelper.ReadRows(query, annotationFields);

            OrderedDictionary res = new OrderedDictionary();
            foreach (DataColumn col in dt.Columns)
            {
                res.Add(col.ColumnName, dt.AsEnumerable().Select(row => row.Field<string>(col.ColumnName)).ToList());
            }

            return res;
        }
        /// <summary>
        /// tried to get the list of columns names
        /// </summary>
        /// <param name="tableTitle"></param>
        /// <returns></returns>
        public IEnumerable<string> GetFieldNameListOfEntity(string tableTitle)
        {
            string query = $"select name from pragma_table_info('{tableTitle}')";
            var dataTable = _dataBaseHelper.ReadRows(query);
            return dataTable.AsEnumerable().Select(row => row.Field<string>(0));
        }

    }
}
