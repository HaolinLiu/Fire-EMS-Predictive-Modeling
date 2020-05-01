/*
 * @Author: Haolin Liu
 * @Date: 2020-02-14 02:36:52
 * @LastEditTime: 2020-04-30 17:31:37
 * @LastEditors: Haolin Liu
 * @Description: Store the result of machine learning analyse. Can output the result to console or file.
 */
 using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsFormsApp2
{
    class ResultData
    {
        public List<string> NatureCode;
        // Store all the nature code like 321

        public int NatureCodeNum;
        // Store the number of nature codes

        public List<string> UnitTypeName;
        // Store all the unit type name;

        public int UnitTypeNum;
        // Store the number of unit types

        public List<long> Result;
        // Store the result of sending units like 010200
        // 2 UnitTypeName[2] and 1 UnitTypeName[4]

        public ResultData(List<string> NatureCode, int NatureCodeNum, List<string> UnitTypeName, int UnitTypeNum, List<long> Result)
        {
            this.NatureCode = NatureCode;
            this.NatureCodeNum = NatureCodeNum;
            this.UnitTypeName = UnitTypeName;
            this.UnitTypeNum = UnitTypeNum;
            this.Result = Result;
        }

        public void ConsoleResult()
        {
            long result;

            Console.WriteLine("Result:");

            Console.WriteLine("Nature Code Number:{0}\n", NatureCodeNum);

            for (int i = 0; i < NatureCodeNum; i++)
            {

                Console.WriteLine("Nature code:{0}.", NatureCode[i]);

                result = Result[i];

                for (int j = 0; j < UnitTypeNum; j++)
                {
                    Console.WriteLine("{0} {1}", result % 10, UnitTypeName[j]);
                    // get last digit
                    result = result / 10;
                    // delete last digit
                }
            }
        }

        public void PrintResult(string dataFileDir)
        {
            string rulesPath = dataFileDir + "/rules.csv";

            FileStream fs = new FileStream(rulesPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            StringBuilder sb = new StringBuilder();

            sb.Append("ID").Append(",").Append("NatureCode").Append(",").Append("Result");
            // title 
            sw.WriteLine(sb);
            // flush
            sw.Flush();
            sw.Close();
            fs.Close();

            // write data
            StreamWriter swd = new StreamWriter(rulesPath, true, Encoding.Default);
            string row;
            long result;

            for (int i = 0; i < NatureCodeNum; i++)
            {

                row = (i + 1).ToString() + "," + NatureCode[i] + ",";

                result = Result[i];

                for (int j = 0; j < UnitTypeNum; j++)
                {

                    row = row + result % 10 + UnitTypeName[j] + " ";
                    // Console.WriteLine("{0} {1}", result % 10, UnitTypeName[j]);
                    // get last digit

                    result = result / 10;
                    // delete last digit
                }

                swd.WriteLine(row);
                // add data from each row
            }

            swd.Flush();
            swd.Close();
        }
    }
}
