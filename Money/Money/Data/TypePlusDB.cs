using SQLite;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Money.Data
{
    public class TypePlusDB
    {
        readonly SQLiteAsyncConnection _typePlusDB;

        public TypePlusDB(string dbPath)
        {
            _typePlusDB = new SQLiteAsyncConnection(dbPath);
            _typePlusDB.CreateTableAsync<models.TypePlus>().Wait();
        }

        /// <summary>
        /// Получение объектов из БД
        /// </summary>
        /// <returns></returns>
        public Task<List<models.TypePlus>> GetStringAsync()
        {
            return _typePlusDB.Table<models.TypePlus>().ToListAsync();
        }
        /// <summary>
        /// Добавление новой строки
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Task<int> SaveStringAsync(string s)
        {
            var t = new models.TypePlus(s);
            return _typePlusDB.InsertAsync(t);
        }

        /// <summary>
        /// Удаление строки (внимание может вернуть null)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Task<int> DeleteValueAsync(string s)
        {
            var X= _typePlusDB.Table<models.TypePlus>().Where(i => i.Value == s).FirstOrDefaultAsync();
            if (X != null)
            {
                return _typePlusDB.DeleteAsync(X);
            }
            return null;
        }
    }
}
