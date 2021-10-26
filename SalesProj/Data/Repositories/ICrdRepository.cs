using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProj.Data.Repositories
{
    // T would be the type of data being stored
    // U would be the type of the id on the model
    // C would be the type of the read data 
    public interface ICrdRepository<T, U, C>
    {
        T Create(T t);
        public IList<T> Read();
        //T ReadyById(U u);
        public void Delete(U u);
        bool Exists(U u);

        //internal string TotalYearRead(C c);
        //sum of year
        string TotalYearRead(C c, string passYear);
        //sum of month and year
        string TotalYearMonthRead(C c, string passYear, string passMonth);
        //total of year
        public IList<T> TotalSalesYear(string passYear);

        public IList<T> TotalSalesYearMonth(string passYear, string passMonth);

    }
}

