using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyModelLibrary
{   

    /// <summary>
    /// этот класс предастваляет 1 запись в бухгалтерии
    /// </summary>
    
    public class Stroka
    {

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        /// <summary>
        /// сумма операции
        /// </summary>
        public int Sum { get; set; }
        /// <summary>
        /// Знак операции (true - доход. false -  расход)
        /// </summary>
        public bool Sign { get; set; }

        /// <summary>
        /// Тип расхода из класса recordType
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// время записи
        /// </summary>
        public DateTime Data { get; set; }
        /// <summary>
        /// примечание к записи
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// инициализация новой записи в книгу
        /// </summary>
        /// <param name="sum">Сумма транзакции</param>
        /// <param name="type">тип</param>
        /// <param name="n">описание</param>
        /// <param name="s">Знак true +, false -</param>
        public Stroka(int sum, bool s, string type, string n)
        {
            Sum = sum;
            Type = type;
            Note = n;
            Sign = s;
            if (s == false)
                Sum = -Sum;
            Data = DateTime.Now;
        }

        public Stroka() { }

        public override string ToString()
        {
            if (Sign)
            {
                return $"+{Sum} {Type} {Data} {Note}";
            }
            else
            {
                return $"-{Sum} {Type} {Data} {Note}";
            }
        }

    }
}
