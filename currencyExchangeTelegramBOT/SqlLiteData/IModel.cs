using System.Collections.Generic;

namespace SqlLiteData
{
    public interface IModel<T>
    {
        void Add(T data, string request);
        void Add(List<T> data, string request);
        void Delete(int id);
        T Get(int id);
        List<T> GetData();
        void Update(T data, string request);
        void Create(string request);
    }
}
