using System;
using System.Collections.Generic;
using System.Text;

namespace Money
{
    /// <summary>
    /// определнеи аргументов для формирования файла
    /// </summary>
     public interface IFileServiceArgs
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        DateTime CreationDate { get; set; }
        string Title { get; set; }        
    }
}
