using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Banks._02_Classes;

namespace SqlLiteDataAPI
{
    public class TableCheck
    {
        public void Check<T>(string connection)
        {
            try
            {
               
            }
            catch
            {
                new TableModel<T>(connection, typeof(T).Name).Create("");
                this.Check<T>(connection);
            }
        }
    }
}
