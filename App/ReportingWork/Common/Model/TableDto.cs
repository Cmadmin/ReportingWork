using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class TableDto
    {
        public string Name { get; set; }

        public List<DBRowsDto> Rows { get; set; }
    }
}
