using System;
using System.Collections.Generic;
using System.Text;

namespace Money
{
    public class FileServiceArgs : IFileServiceArgs
    {
        /// <summary>
        ///дата начала выборки
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// дата окончания выборки
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Заголовок для файла
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Создание аргументов для файла
        /// </summary>
        /// <param name="title">заголовок</param>
        /// <param name="start">начальная дата</param>
        /// <param name="end">конечная дата</param>
        public FileServiceArgs(string title, DateTime start, DateTime end)
        {
            Title = title;
            StartDate = start;
            EndDate = end;
            CreationDate = DateTime.Now;
        }
    }
}
