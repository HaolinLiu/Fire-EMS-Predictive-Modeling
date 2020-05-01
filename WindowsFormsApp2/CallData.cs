/*
 * @Author: Haolin Liu
 * @Date: 2020-01-14 16:21:15
 * @LastEditTime: 2020-04-30 17:23:12
 * @LastEditors: Haolin Liu
 * @Description: import data from excal and output them to DataTable
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;


namespace WindowsFormsApp2
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
