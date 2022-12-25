using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Graph
    {
        public string Val { get; set; }
        public List<string> Next { get; set; } = new List<string>();
        public List<string> Prev { get; set; } = new List<string>();
    }
}
