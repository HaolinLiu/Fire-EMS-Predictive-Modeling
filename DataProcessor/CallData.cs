using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;

namespace DataProcessor
{
    /// <summary>
    /// Class to hold call data
    /// </summary>
    public class CallData
    {
        //public DataTable CallDataTable;

        public static DataTable ImportCallData(string fileName)
        {
            DataTable newDataTable = new DataTable();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string[] colNames = streamReader.ReadLine().Split(',');
                foreach (string colName in colNames)
                {
                    newDataTable.Columns.Add(colName);
                }

                while (!streamReader.EndOfStream)
                {
                    string[] row = streamReader.ReadLine().Split(',');
                    DataRow newDataRow = newDataTable.NewRow();
                    for (int i = 0; i < colNames.Length; i++)
                    {
                        newDataRow[i] = row[i];
                    }
                    newDataTable.Rows.Add(newDataRow);
                }
            }

            return newDataTable;
        }

    }

}
