using Services.Model;

namespace Services.Implementation
{
    public class SqlGenerator
    {
        public void GenerateSql(Report report)
        {
            foreach(var block in report.Blocks)
            {
                block.MetaData = GenerateReportBlock(block);
            }
        }

        public string[,] GenerateReportBlock(ReportBlock block)
        {
            //generate the dynamical sql 
            //run sql and return data
            //parse data into a 2D array and return it.
            return null;
        }
    }
}
