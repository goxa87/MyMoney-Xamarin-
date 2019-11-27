using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyModelLibrary
{
    public delegate void onThrow(string s, int i);

    public class MyException : Exception
    {
        
        public event onThrow OnThrow;

        /// <summary>
        /// Цифровое обозначение ошибки
        /// </summary>
        public int Index { get; }
        /// <summary>
        /// Сообщение ошибки
        /// </summary>
        public override string Message { get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mes">Сообщение</param>
        /// <param name="index">Индекс исключения</param>
        /// <param name="method">Метод при возникновении события выброса исключения </param>
        public MyException(string mes, int index, onThrow method)
        {
            Message = mes;
            Index = index;
            OnThrow += method;
            OnThrow(mes, index);
        }
    }
}
