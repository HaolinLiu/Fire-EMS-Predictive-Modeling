using System;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<CallResponseData.Response> foo = new List<CallResponseData.Response>();
            foo.Add(new CallResponseData.Response("1", "2", DateTime.UtcNow, DateTime.MinValue));
            CallResponseData a = new CallResponseData("1", "1", DateTime.Now, "1", foo, 1, 01010);
            Console.WriteLine(" Call ID: " + a.CallID);
            Console.WriteLine(" Nature Code: " + a.NatureCode);
            string testFileDir = @"C:\Users\haoli\Desktop\CS 461\drive-download-20191123T001728Z-001\";
            string testFileCD = testFileDir + "EasierSampleCalls.csv";
            string testFileRD = testFileDir + "EasierSampleResponses.csv";
            
            DataTable callDataTable = CallData.ImportCallData(testFileCD);
            DataTable ResponseDataTable = CallData.ImportCallData(testFileRD);


            AnalyzeData ana = new AnalyzeData();
            CallResponseData[] combinedData = ana.CombineData(callDataTable, ResponseDataTable);

            Console.WriteLine(ana.callCount);
            
            // CallResponseData[] combinedData = AnalyzeData.CombineData(callDataTable, ResponseDataTable);
            // Console.WriteLine("" + combinedData.Length);

            ModelFileCreater c = new ModelFileCreater();
            c.CreatFile(combinedData, ana.callCount);
        }
    }
}