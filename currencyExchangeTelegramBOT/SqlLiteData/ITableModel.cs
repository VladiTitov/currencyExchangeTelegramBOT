using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace SqlLiteData
{
    public class ITableModel<T> : IModel<T>
    {
        string connection;
        string table;

        public ITableModel(string _connection, string _table)
        {
            connection = _connection;
            table = _table;
        }

        #region Добавление

        #region По одному объекту

        public void Add(T currency, string request)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                //string sqlQuery = $"INSERT INTO {table} (Name, Age) VALUES(@Name, @Age)";
                string sqlQuery = $"INSERT INTO {table} {request}";
                db.Execute(sqlQuery, currency);
            }
        }

        #endregion

        #region Списком объектов
        public void Add(List<T> currencies, string request)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = $"INSERT INTO {table} {request}";
                foreach (var currency in currencies)
                {
                    db.Execute(sqlQuery, currency);
                }
            }
        }
        #endregion

        #endregion

        #region Создание таблицы

        public void Create(string request)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                //string sqlQuery = $"CREATE TABLE {table} ('Key' TEXT NOT NULL CONSTRAINT 'PK_Currencies' PRIMARY KEY,'Url' TEXT NULL,'NameLat' TEXT NULL,'NameRus' TEXT NULL)";
                string sqlQuery = $"CREATE TABLE {table} {request}";
                db.Execute(sqlQuery);
            }
        }

        #endregion

        #region Удаление

        public void Delete(int id)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = $"DELETE FROM {table} WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        #endregion

        #region Получение данных

        #region По одному объекту

        public T Get(int id)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                return db.Query<T>($"SELECT * FROM {table} WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        #endregion

        #region Списком объектов

        public List<T> GetData()
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                return db.Query<T>($"SELECT * FROM {table}").ToList();
            }
        }

        #endregion

        #endregion

        #region Обновление данных

        public void Update(T currency, string request)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = $"UPDATE {table} {request}";
                db.Execute(sqlQuery, currency);
            }
        }

        #endregion
    }
}
