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

        public ITableModel(string conn) => connection = conn;

        public void Add(T currency)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, currency);
            }
        }

        public void Add(List<T> currencies)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = "INSERT INTO Currencies (Key, Url, NameLat, NameRus) VALUES(@Key, @Url, @NameLat, @NameRus)";
                foreach (var currency in currencies)
                {
                    db.Execute(sqlQuery, currency);
                }
            }
        }

        public void Create()
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = "CREATE TABLE 'Currencies' ('Key' TEXT NOT NULL CONSTRAINT 'PK_Currencies' PRIMARY KEY,'Url' TEXT NULL,'NameLat' TEXT NULL,'NameRus' TEXT NULL)";
                db.Execute(sqlQuery);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public T Get(int id)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                return db.Query<T>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<T> GetData()
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                return db.Query<T>("SELECT * FROM CURRENCIES").ToList();
            }
        }

        public void Update(T currency)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                string sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, currency);
            }
        }
    }
}
