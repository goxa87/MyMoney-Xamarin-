using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace Money.models
{
    public class TypeMinus
    {
        /// <summary>
        /// идекнтификатор
        /// </summary>
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// инициализация
        /// </summary>
        public TypeMinus() { }
        /// <summary>
        /// нициализация
        /// </summary>
        /// <param name="s">строка тодержимого</param>
        public TypeMinus(string s) { Value = s; }
    }
}
