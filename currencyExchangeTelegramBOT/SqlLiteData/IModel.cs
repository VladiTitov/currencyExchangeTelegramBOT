using System.Collections.Generic;

namespace SqlLiteData
{
    public interface IModel<T>
    {
        void Add(T data);
        void Add(List<T> data);
        void Delete(int id);
        T Get(int id);
        List<T> GetData();
        void Update(T data);
        void Create();
    }
}
