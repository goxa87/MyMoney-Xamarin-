using System;
using System.Collections.Generic;
using SQLite;
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
            _database.CreateTableAsync<models.Stroka>().Wait();
        }

        /// <summary>
        /// Получение строк
        /// </summary>
        /// <returns></returns>
        public Task<List<models.Stroka>> GetStroksAsync()
        {
            return _database.Table<models.Stroka>().ToListAsync();
        }
        /// <summary>
        /// получение строк по ИД
        /// </summary>
        public Task<models.Stroka> GetStroksAsync(int id)
        {
            return _database.Table<models.Stroka>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Сохранение или изменение строки
        /// </summary>
        /// <param name="stroka"></param>
        /// <returns></returns>
        public Task<int> SaveStrokaAsync(models.Stroka stroka)
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
        public Task<int> DeleteStrokaAsync(models.Stroka stroka)
        {
            return _database.DeleteAsync(stroka);
        }
    }

}
