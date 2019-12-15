using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Money.Data
{
    /// <summary>
    /// обращение к списку параметров списания
    /// </summary>
    public class TypeMinusDb
    {
        readonly SQLiteAsyncConnection _typeMinusDB;

        public TypeMinusDb(string dbPath)
        {
            _typeMinusDB = new SQLiteAsyncConnection(dbPath);
            _typeMinusDB.CreateTableAsync<models.TypeMinus>().Wait();
        }

        /// <summary>
        /// Получение объектов из БД
        /// </summary>
        /// <returns></returns>
        public Task<List<models.TypeMinus>> GetStringAsync()
        {
            return _typeMinusDB.Table<models.TypeMinus>().ToListAsync();
        }
        /// <summary>
        /// Добавление новой строки
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Task<int> SaveStringAsync(string s)
        {
            var t = new models.TypeMinus(s);
            return _typeMinusDB.InsertAsync(t);
        }


        /// <summary>
        /// Удаление строки (внимание может вернуть null)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Task<int> DeleteValueAsync(string s)
        {
            var X = _typeMinusDB.Table<models.TypeMinus>().Where(i => i.Value == s).FirstOrDefaultAsync();
            if (X != null)
            {
                return _typeMinusDB.DeleteAsync(X);
            }
            return null;
        }
    }
}
