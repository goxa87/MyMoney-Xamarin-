using System;
using System.Collections.Generic;
using System.Text;

namespace Money
{
    /// <summary>
    /// интерфейс формирования файла
    /// </summary>
    public interface IGetFileService
    {
        void MakeFile(IFileServiceArgs args);
    }
}
