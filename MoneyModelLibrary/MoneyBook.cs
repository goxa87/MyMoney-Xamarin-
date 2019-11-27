using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyModelLibrary
{
    /// <summary>
    /// Записная книга
    /// </summary>
    public class MoneyBook // этот класс утратил актуальность с подключением SQLite
    {
        /// <summary>
        /// Имя записной книжки
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Коллекция записей бухгалтерской книги
        /// </summary>
        public ObservableCollection<Stroka> Book { get; set; }

        /// <summary>
        /// Инициализация 
        /// </summary>
        public MoneyBook(string n)
        {
            Book = this.Loader();
            Name = n;
        }

        /// <summary>
        /// Загрузчик записей книги
        /// </summary>
        /// <returns></returns>
        ObservableCollection<Stroka> Loader()
        {
            ObservableCollection<Stroka> rez = new ObservableCollection<Stroka>();
            // здесь загрузка из файла

            for (int i = 0; i < 10; i++) // это временно
            {
                rez.Add(new Stroka(i * 100, false, "еда", "Заметка " + i));
            }
            return rez;
        }
    }
}
