using Fond_wf.Model;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Fond_wf.Functions
{
    public interface IDataFunc
    {
        DataTable GetDataFromFile(string filepath);
        List<SearchParameters> GetDataForPlotXY(DataTable csvTable, int numColx, int numColy);
    }
    public class IDataFunc_ : IDataFunc
    {
        public DataTable GetDataFromFile(string filepath)
        {
            DataTable csvTable = new DataTable();

            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(filepath)), true))
            {
                csvTable.Load(csvReader);
            }

            return csvTable;
        }

        public List<SearchParameters> GetDataForPlotXY(DataTable csvTable, int numColx, int numColy)
        {
            //DateTime,Param
            List<SearchParameters> searchParameters = new List<SearchParameters>();

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                searchParameters.Add(new SearchParameters
                {
                    DateTime = csvTable.Rows[i][0].ToString(),
                    Param = csvTable.Rows[i][1].ToString()
                });              
            }
            return searchParameters;
        }
    }
}
