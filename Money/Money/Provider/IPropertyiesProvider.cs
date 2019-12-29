using System;
using System.Collections.Generic;
using System.Text;

namespace Money
{
    /// <summary>
    /// операции для страницы настроек
    /// </summary>
    interface IPropertyiesProvider
    {
        IPropertiesView view { get; set; }

        IGetFileService ServiceFile { get; set; }

        void SaveFileOperation(object sender, EventArgs e);

        void CallRashPage();

        void CallDohodPage();

        void Clearhistory();
    }
}
