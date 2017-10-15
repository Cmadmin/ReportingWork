
using System;
using System.Collections.Generic;

namespace Services.Model
{
    public class Report
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }

        public List<ReportBlock> Blocks { get; set; }
    }
}
