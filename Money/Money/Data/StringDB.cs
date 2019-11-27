using System;
using System.Collections.Generic;
using SQLite;
using MoneyModelLibrary;
using System.Threading.Tasks;
using System.Text;
using System.Collections.ObjectModel;

namespace Money.Data
{
    public class StringDB
    {
        readonly SQLiteAsyncConnection _database;

        public StringDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Stroka>().Wait();
        }

        /// <summary>
        /// Получение строк
        /// </summary>
        /// <returns></returns>
        public Task<List<Stroka>> GetStroksAsync()
        {
            return _database.Table<Stroka>().ToListAsync();
        }
        /// <summary>
        /// получение строк по ИД
        /// </summary>
        public Task<Stroka> GetStroksAsync(int id)
        {
            return _database.Table<Stroka>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Сохранение или изменение строки
        /// </summary>
        /// <param name="stroka"></param>
        /// <returns></returns>
        public Task<int> SaveStrokaAsync(Stroka stroka)
        {
            if (stroka.ID != 0)
            {
                return _database.UpdateAsync(stroka);
            }
            else
            {
                return _database.InsertAsync(stroka);
            }
        }
        /// <summary>
        /// Удаление строки
        /// </summary>
        /// <param name="stroka"></param>
        /// <returns></returns>
        public Task<int> DeleteStrokaAsync(Stroka stroka)
        {
            return _database.DeleteAsync(stroka);
        }
    }

}
