using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace WindowsFormsApp2
{
    class ModelFileCreater
    {
        public void CreatFile(CallResponseData[] data, int callNum, string trainDataPath, string testDataPath)
        {

            int edgeOfTrainAndTest = (int)(callNum * 0.9);
            // string fileName = "C:\\Users\\haoli\\Desktop\\CS 462\\Fire-EMS-Predictive-Modeling\\ModelFileTest.tsv";
            // fix file name.

            FileStream fs_trian = new FileStream(trainDataPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw_trian = new StreamWriter(fs_trian);
            StringBuilder sb_trian = new StringBuilder();

            sb_trian.Append("ID").Append("\t").Append("Result").Append("\t").Append("NatureCode").Append("\t").Append("CallRecived").Append("\t").Append("Address");

            // sb.Append("NatureCode").Append("    ").Append("Result");
            // title 
            sw_trian.WriteLine(sb_trian);
            // flush
            sw_trian.Flush();
            sw_trian.Close();
            fs_trian.Close();

            // write data
            StreamWriter swd_trian = new StreamWriter(trainDataPath, true, Encoding.Default);
            // StringBuilder sbd = new StringBuilder();
            // sbd.Append("321").Append(",").Append("01010").Append(",");

            for (int i = 0; i < edgeOfTrainAndTest; i++)
            {
                swd_trian.WriteLine(data[i].CallID + "\t" + data[i].Result + "\t" + data[i].NatureCode + "\t" + data[i].CallRecived.ToString() + "\t" + data[i].Address);
                // add data from each row
            }
            
            swd_trian.Flush();
            swd_trian.Close();



            FileStream fs_test = new FileStream(testDataPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw_test = new StreamWriter(fs_test);
            StringBuilder sb_test = new StringBuilder();

            sb_test.Append("ID").Append("\t").Append("Result").Append("\t").Append("NatureCode").Append("\t").Append("CallRecived").Append("\t").Append("Address");

            // sb.Append("NatureCode").Append("    ").Append("Result");
            // title 
            sw_test.WriteLine(sb_test);
            // flush
            sw_test.Flush();
            sw_test.Close();
            fs_test.Close();

            // write data
            StreamWriter swd_test = new StreamWriter(testDataPath, true, Encoding.Default);
            // StringBuilder sbd = new StringBuilder();
            // sbd.Append("321").Append(",").Append("01010").Append(",");

            for (int i = edgeOfTrainAndTest + 1; i < callNum; i++)
            {
                swd_test.WriteLine(data[i].CallID + "\t" + data[i].Result + "\t" + data[i].NatureCode + "\t" + data[i].CallRecived.ToString() + "\t" + data[i].Address);
                // add data from each row
            }


            swd_test.Flush();
            swd_test.Close();
        }
    }
}
