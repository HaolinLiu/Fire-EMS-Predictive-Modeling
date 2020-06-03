using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace WindowsFormsApp2
{
    class ModelFileCreater
    {
        public int[] CreatFile(CallResponseData[] data, int callNum, string trainDataPath, string testDataPath,
                                List<int> month, List<int> week, List<int> year, int[] time)
        {
            int[] selectItemNum = {0, 0, 0};

            int edgeOfTrainAndTest = (int)(callNum * 0.9);


            FileStream fs_trian = new FileStream(trainDataPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw_trian = new StreamWriter(fs_trian);
            StringBuilder sb_trian = new StringBuilder();

            sb_trian.Append("ID").Append("\t").Append("Result").Append("\t").Append("NatureCode").Append("\t").Append("CallRecived").Append("\t").Append("Address");

            // title 
            sw_trian.WriteLine(sb_trian);
            // flush
            sw_trian.Flush();
            sw_trian.Close();
            fs_trian.Close();

            // write data
            StreamWriter swd_trian = new StreamWriter(trainDataPath, true, Encoding.Default);

            for (int i = 0; i < edgeOfTrainAndTest; i++)
            {   
                if(month.Contains(data[i].CallRecived.Month) && week.Contains((int)data[i].CallRecived.DayOfWeek) 
                    && year.Contains(data[i].CallRecived.Year) && data[i].CallRecived.Hour >= time[0] && data[i].CallRecived.Hour < time[1] ){
                    swd_trian.WriteLine(data[i].CallID + "\t" + data[i].Result + "\t" + data[i].NatureCode + "\t" + data[i].CallRecived.ToString() + "\t" + data[i].Address);
                    // add data from each row
                    selectItemNum[0]++;
                }
            }
            
            swd_trian.Flush();
            swd_trian.Close();



            FileStream fs_test = new FileStream(testDataPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw_test = new StreamWriter(fs_test);
            StringBuilder sb_test = new StringBuilder();

            sb_test.Append("ID").Append("\t").Append("Result").Append("\t").Append("NatureCode").Append("\t").Append("CallRecived").Append("\t").Append("Address");

            // title 
            sw_test.WriteLine(sb_test);
            // flush
            sw_test.Flush();
            sw_test.Close();
            fs_test.Close();

            // write data
            StreamWriter swd_test = new StreamWriter(testDataPath, true, Encoding.Default);

            for (int i = edgeOfTrainAndTest; i < callNum; i++)
            {
                if(month.Contains(data[i].CallRecived.Month) && week.Contains((int)data[i].CallRecived.DayOfWeek) 
                    && year.Contains(data[i].CallRecived.Year) && data[i].CallRecived.Hour >= time[0] && data[i].CallRecived.Hour < time[1] ) {
                    swd_test.WriteLine(data[i].CallID + "\t" + data[i].Result + "\t" + data[i].NatureCode + "\t" + data[i].CallRecived.ToString() + "\t" + data[i].Address);
                    // add data from each row
                    selectItemNum[1]++;
                }
            }


            swd_test.Flush();
            swd_test.Close();

            selectItemNum[2] = selectItemNum[0] + selectItemNum[1];

            return selectItemNum;
        }
    }
}
