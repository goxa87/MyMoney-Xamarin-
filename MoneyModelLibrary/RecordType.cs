using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyModelLibrary
{
    public class RecordType
    {
        /// <summary>
        /// Метод, который будет вызван при возникновении ошибок
        /// </summary>
        public onThrow CallExMethod { get; set; }

        /// <summary>
        /// Список различных типов записей
        /// </summary>
        public List<string> Types { get; set; }
        /// <summary>
        /// Инииализация
        /// </summary>
        /// <param name="meth">Метод для оповещения об ошибках</param>
        public RecordType()
        {
            // здесь должна быть загрузка из файла списка типов
            CallExMethod = meth;
            Types = new List<string>();

            // ЭТО ВРЕМЕННО. ОРГАНИЗОВАТЬ РАБОТУ С ФАЙЛОМ
            Types.Add("еда");
            Types.Add("доход");
            Types.Add("ништяки");
            Types.Add("одежда обувь");
            Types.Add("развлечения");
            Types.Add("ремонт машины");
            Types.Add("заправка");
            Types.Add("коммунальные платежи");
            Types.Add("кредиты");
            Types.Add("отдых");
        }

        /// <summary>
        /// индексатор к Types
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns></returns>
        public string this[int index]
        {
            get { return Types[index]; } 
            set => Types[index] = value;
        }

        /// <summary>
        /// Возвращает длинну массива
        /// </summary>
        /// <returns></returns>
        public int GetLenth()
        {
            return Types.Count;
        }

        /// <summary>
        /// Добавление записей
        /// </summary>
        /// <param name="s"></param>
        public void Add(string s)
        {
            s = s.ToLower();
            Types.Add(s);
            // ПЕРЕЗПИСАТЬ ФАЙЛ
        }
        /// <summary>
        /// удаляет запись с  указанным значением
        /// </summary>
        /// <param name="value">Часть строки значения для удаления</param>
        public bool RemoveAt(string value)
        {
            try
            {
                value = value.ToLower();

                bool flag = false; // флаг нахождения данной подстроки в списке
                for (int i = 0; i < Types.Count; i++)  // перебор
                {
                    if (Types[i].Contains(value)) // если содержит подстроку
                    {
                        flag = true;
                        Types.RemoveAt(i);
                        //ПЕРЕЗАПИСАТЬ ФАЙЛ
                        return true;
                    }
                }
                if (flag == false)
                    throw new MyException("Подстрока для удаления из списка типов не найдена", 1, CallExMethod);
                return false;
            }
            catch (MyException)
            {
                //ex.OnThrow(ex.Message, ex.Index);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
