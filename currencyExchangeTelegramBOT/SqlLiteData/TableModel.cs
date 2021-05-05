using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using SqlLiteData;

namespace SqlLiteDataAPI
{
    public class TableModel<T> : IModel<T>
    {
        private readonly string _connection;
        private readonly string _table;

        public TableModel(string table)
        {
            this._connection = "Data Source=../data.db";
            this._table = table;
        }

        #region Добавление

        #region По одному объекту

        public void Add(T currency, string request)
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            //string sqlQuery = $"INSERT INTO {table} (Name, Age) VALUES(@Name, @Age)";
            var sqlQuery = $"INSERT INTO {_table} {request}";
            db.Execute(sqlQuery, currency);
        }

        #endregion

        #region Списком объектов
        public void Add(List<T> currencies, string request)
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            var sqlQuery = $"INSERT INTO {_table} {request}";
            foreach (var currency in currencies)
            {
                db.Execute(sqlQuery, currency);
            }
        }
        #endregion

        #endregion

        #region Создание таблицы

        public void Create(string request)
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            //string sqlQuery = $"CREATE TABLE {table} ('Key' TEXT NOT NULL CONSTRAINT 'PK_Currencies' PRIMARY KEY,'Url' TEXT NULL,'NameLat' TEXT NULL,'NameRus' TEXT NULL)";
            var sqlQuery = $"CREATE TABLE {_table} {request}";
            db.Execute(sqlQuery);
        }

        #endregion

        #region Удаление

        public void Delete(int id)
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            var sqlQuery = $"DELETE FROM {_table} WHERE Id = @id";
            db.Execute(sqlQuery, new { id });
        }

        #endregion

        #region Получение данных

        #region По одному объекту

        public T Get(int id)
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            return db.Query<T>($"SELECT * FROM {_table} WHERE Id = @id", new { id }).FirstOrDefault();
        }

        #endregion

        #region Списком объектов

        public List<T> GetData()
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            return db.Query<T>($"SELECT * FROM {_table}").ToList();
        }

        #endregion

        #endregion

        #region Обновление данных

        public void Update(T data, string request)
        {
            using IDbConnection db = new SQLiteConnection(_connection);
            var sqlQuery = $"UPDATE {_table} {request}";
            db.Execute(sqlQuery, data);
        }

        #endregion
    }
}
