﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyModelLibrary
{
    /// <summary>
    /// этот класс группирует и считает выборки записей по месяцам и за весь период
    /// </summary>
    class CommonInfo
    {
        /// <summary>
        /// выборка по категориям за весь период
        /// </summary>
        public Dictionary<string, int> AllTime { get; private set; }

        /// <summary>
        /// выборка по категориям за прошлый месяц
        /// </summary>
        public Dictionary<string, int> LastMonth { get; private set; }
        /// <summary>
        /// выборка по категориям за текущий месяц
        /// </summary>
        public Dictionary<string, int> CurrentMonth { get; private set; }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <returns></returns>
        piblic CommonInfo(List<Stroka> strokas)
        {
            AllTime = new Dictionary<string, int>();
            LastMonth = new Dictionary<string, int>();
            CurrentMonth = new Dictionary<string, int>();
            
            // разбрасывает все значения входного массива по словарям

        }

    }
}
