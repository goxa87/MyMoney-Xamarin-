using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace Money.models
{
    /// <summary>
    /// тип для хранения типа дохода 
    /// </summary>
    public class TypePlus
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
        public TypePlus(){}
        /// <summary>
        /// нициализация
        /// </summary>
        /// <param name="s">строка тодержимого</param>
        public TypePlus(string s) { Value = s; }


    }
}
