using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab1
{
    class Comparator : IComparer<List<string>>
    {
        public int Compare([AllowNull] List<string> x, [AllowNull] List<string> y)
        {
            return -x.Count + y.Count;
        }
    }
}
