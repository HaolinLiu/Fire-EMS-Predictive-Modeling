using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            List<CallResponseData.Response> foo = new List<CallResponseData.Response>();
            foo.Add(new CallResponseData.Response("1", "2", DateTime.UtcNow, DateTime.MinValue));
            CallResponseData a = new CallResponseData("1", "1", DateTime.Now, "1", foo);
            Console.WriteLine(" Call ID: " + a.CallID);
            Console.WriteLine(" Nature Code: " + a.NatureCode);
            string testFileDir = "C:\\Users\\annal\\Documents\\Capstone\\testFiles\\easy\\";
            string testFileCD = testFileDir + "EasierSampleCalls.csv";
            string testFileRD = testFileDir + "EasierSampleResponses.csv";
            
            DataTable callDataTable = CallData.ImportCallData(testFileCD);
            DataTable ResponseDataTable = CallData.ImportCallData(testFileRD);

            CallResponseData[] combinedData = AnalyzeData.CombineData(callDataTable, ResponseDataTable);
            Console.WriteLine("" + combinedData.Length);
            //DataTable mergedData = callDataTable.Merge(ResponseDataTable);

            MLContext mLContext = new MLContext();

            TrainTestData splitDataView = LoadData(mLContext, combinedData);

           // ITransformer model = CreateModel(mLContext, splitDataView.TrainSet);

            //Evaluate(mLContext, model, splitDataView.TestSet);

        }

        public static TrainTestData LoadData(MLContext mLContext, CallResponseData[] data)
        {
            IDataView dataView = mLContext.Data.LoadFromEnumerable<CallResponseData>(data);
            TrainTestData splitData = mLContext.Data.TrainTestSplit(dataView, testFraction: .02);
            return splitData;
        }

       /* public static ITransformer CreateModel(MLContext mLContext, IDataView trainData)
        {
            
        }*/

        public static void Evaluate (MLContext mLContext, ITransformer model, IDataView testData)
        {

        }


    }
}
