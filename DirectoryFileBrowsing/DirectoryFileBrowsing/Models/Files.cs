using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryFileBrowsing.Models
{
    public class Files
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Third { get; set; }
        public IEnumerable<string> Names { get; set; }
        public string Warning { get; set; }
    }
}