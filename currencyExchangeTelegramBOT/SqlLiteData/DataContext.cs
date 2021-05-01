using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Banks._02_Classes;
using Dapper;

namespace SqlLiteData
{
    public interface ICurrencyRepo<T>
    {
        void Add(T data);
        void Add(List<T> data);
        void Delete(int id);
        T Get(int id);
        List<T> GetCurrencies();
        void Update(T data);
        void Create();
    }

    public class CurrencyRepo : ICurrencyRepo<Currency>
    {
        string connection;

        public CurrencyRepo(string conn) => connection = conn;

        public void Add(Currency currency)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, currency);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Add(List<Currency> currencies)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                var sqlQuery = "INSERT INTO Currencies (Key, Url, NameLat, NameRus) VALUES(@Key, @Url, @NameLat, @NameRus)";
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
                var sqlQuery = "CREATE TABLE 'Currencies' ('Key' TEXT NOT NULL CONSTRAINT 'PK_Currencies' PRIMARY KEY,'Url' TEXT NULL,'NameLat' TEXT NULL,'NameRus' TEXT NULL)";
                db.Execute(sqlQuery);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Currency Get(int id)
        {
            using(IDbConnection db = new SQLiteConnection(connection))
            {
                return db.Query<Currency>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Currency> GetCurrencies()
        {
            using(IDbConnection db = new SQLiteConnection(connection))
            {
                return db.Query<Currency>("SELECT * FROM CURRENCIES").ToList();
            }
        }

        public void Update(Currency currency)
        {
            using (IDbConnection db = new SQLiteConnection(connection))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, currency);
            }
        }
    }    
}
