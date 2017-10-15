

using Services.Model;

namespace Services.Implementation
{
    public class ReportProcessor
    {
        public void GenerateReport(Report report)
        {
            foreach (var block in report.Blocks)
            {
                block.MetaData = GenerateBlock(block);
            }
        }

        public string[,] GenerateBlock(ReportBlock block)
        {
            //generate the dynamical sql 
            //run sql and return data
            //parse data into a 2D array and return it.
            return null;
        }
    }
}
