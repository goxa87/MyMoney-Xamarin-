using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Money
{
    public class GetFileService : IGetFileService
    {
        public void MakeFile(IFileServiceArgs args)
        {
            Debug.WriteLine("Comme secsessfuly");
        }
    }
}
