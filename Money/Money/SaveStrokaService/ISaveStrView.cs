using System;
using System.Collections.Generic;
using System.Text;

namespace Money
{
    public interface ISaveStrView
    {
        int Value { get; set; }

        string Category { get; set; }

        string Details { get; set; }

        models.Stroka theStroka { get; set; }
    }
}
