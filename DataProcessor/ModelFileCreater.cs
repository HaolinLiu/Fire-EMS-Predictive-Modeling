using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace DataProcessor
{
    class ModelFileCreater
    {   
        public void CreatFile(CallResponseData[] data, int callNum){

            string fileName = "C:\\Users\\haoli\\Desktop\\CS 462\\Fire-EMS-Predictive-Modeling\\ModelFile.csv";
            // fix file name.

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            StringBuilder sb = new StringBuilder();

            sb.Append("NatureCode").Append(",").Append("Result");
            // title 
            sw.WriteLine(sb);
            // flush
            sw.Flush();
            sw.Close();
            fs.Close();

            // write data
            StreamWriter swd = new StreamWriter(fileName, true, Encoding.Default);
            // StringBuilder sbd = new StringBuilder();
            // sbd.Append("321").Append(",").Append("01010").Append(",");

            for (int i=0; i<callNum; i++){
                swd.WriteLine(data[i].NatureCode + "," + data[i].Result);
                // add data from each row
            }

            
            swd.Flush();
            swd.Close();
        }
    }
}
