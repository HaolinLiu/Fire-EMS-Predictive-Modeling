using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using System.IO;
using System.Data;


namespace WindowsFormsApp2
{
    class MachineLearning
    {
        private static string _appPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private static string _trainDataPath => Path.Combine(_appPath, "..", "..", "..", "Data", "ModelFileTrain.tsv");
        private static string _testDataPath => Path.Combine(_appPath, "..", "..", "..", "Data", "ModelFileTest.tsv");
        private static string _modelPath => Path.Combine(_appPath, "..", "..", "..", "Models", "model.zip");
        private static string _testFileDir => Path.Combine(_appPath, "..", "..", "..", "Data");



        private static MLContext _mlContext;
        private static PredictionEngine<GitHubIssue, IssuePrediction> _predEngine;
        private static ITransformer _trainedModel;
        static IDataView _trainingDataView;


        public double[] ML (string callPath, string responsePath){
            DataTable callDataTable = CallData.ImportCallData(callPath);
            DataTable ResponseDataTable = CallData.ImportCallData(responsePath);

            AnalyzeData ana = new AnalyzeData();
            CallResponseData[] combinedData = ana.CombineData(callDataTable, ResponseDataTable);

            // label1.Text = ana.callCount.ToString();

            // label1.Text = _trainDataPath;
            // label2.Text = _testDataPath;

            string trainDataPath = "C:\\Users\\haoli\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Data\\ModelFileTrain.tsv";
            string testDataPath = "C:\\Users\\haoli\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Data\\ModelFileTrain.tsv";


            ModelFileCreater c = new ModelFileCreater();
            c.CreatFile(combinedData, ana.callCount, trainDataPath, testDataPath);


            Console.WriteLine(ana.callCount);
            Console.WriteLine(trainDataPath);
            Console.WriteLine(testDataPath);


            // Create MLContext to be shared across the model creation workflow objects 
            // Set a random seed for repeatable/deterministic results across multiple trainings.
            // <SnippetCreateMLContext>
            _mlContext = new MLContext(seed: 0);
            // </SnippetCreateMLContext>

            // STEP 1: Common data loading configuration 
            // CreateTextReader<GitHubIssue>(hasHeader: true) - Creates a TextLoader by inferencing the dataset schema from the GitHubIssue data model type.
            // .Read(_trainDataPath) - Loads the training text file into an IDataView (_trainingDataView) and maps from input columns to IDataView columns.
            // label1.Text =  "=============== Loading Dataset  ===============";
            
            // <SnippetLoadTrainData>
            _trainingDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(trainDataPath, hasHeader: true);
            // </SnippetLoadTrainData>

            // label2.Text = "=============== Finished Loading Dataset  ===============";
            
            // <SnippetSplitData>
            //   var (trainData, testData) = _mlContext.MulticlassClassification.TrainTestSplit(_trainingDataView, testFraction: 0.1);
            // </SnippetSplitData>


            // label2.Text = "=============== Processing Data ===============";
            // <SnippetCallProcessData>
            var pipeline = ProcessData();
            // </SnippetCallProcessData>


            // label3.Text = "=============== Training the model  ===============";
            // <SnippetCallBuildAndTrainModel>
            var trainingPipeline = BuildAndTrainModel(_trainingDataView, pipeline);
            // </SnippetCallBuildAndTrainModel>


            // label4.Text = "=============== Evaluating the model  ===============";
            // <SnippetCallEvaluate>
            double[] accuracy = Evaluate(_trainingDataView.Schema);
            // </SnippetCallEvaluate>


            // label5.Text = "=============== Finished  ===============";

            // <SnippetCallPredictIssue>
            // string prediction = PredictIssue("111");
            // Console.WriteLine($"=============== Single Prediction - Result: {prediction} ===============");
            // // </SnippetCallPredictIssue>


            List<long> result = new List<long>();

            for (int i=0; i<ana.NatureCodeTypeNum; i++){
                result.Add(long.Parse(PredictIssue(ana.NatureCode[i])));

                // Console.WriteLine("{0},{1}Nature code:{2}.", i, ana.NatureCode[i], PredictIssue(ana.NatureCode[i]));
                // for debug
            }

            ResultData r = new ResultData(ana.NatureCode, ana.NatureCodeTypeNum, ana.UnitTypeName, ana.UnitTypeNum, result);
            r.PrintResult(_testFileDir);


            return accuracy;
        }

        public static IEstimator<ITransformer> ProcessData()
        {   
            // label5.Text = "=============== Evaluating the model  ===============";

            Console.WriteLine($"=============== Processing Data ===============");
            // STEP 2: Common data process configuration with pipeline data transformations
            // <SnippetMapValueToKey>
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey(inputColumnName: "Result", outputColumnName: "Label")
                            // </SnippetMapValueToKey>
                            // <SnippetFeaturizeText>
                            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "NatureCode", outputColumnName: "CodeFeaturized"))
                            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "CallRecived", outputColumnName: "DateFeaturized"))
                            .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Address", outputColumnName: "AddressFeaturized"))
                            // </SnippetFeaturizeText>
                            // <SnippetConcatenate>
                            .Append(_mlContext.Transforms.Concatenate("Features", "CodeFeaturized", "DateFeaturized", "AddressFeaturized"))
                            // </SnippetConcatenate>
                            //Sample Caching the DataView so estimators iterating over the data multiple times, instead of always reading from file, using the cache might get better performance.
                            // <SnippetAppendCache>
                            .AppendCacheCheckpoint(_mlContext);
                            // </SnippetAppendCache>

            Console.WriteLine($"=============== Finished Processing Data ===============");
            
            // <SnippetReturnPipeline>
            return pipeline;
            // </SnippetReturnPipeline>
        }

        public IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
        {
            // STEP 3: Create the training algorithm/trainer
            // Use the multi-class SDCA algorithm to predict the label using features.
            //Set the trainer/algorithm and map label to value (original readable state)
            // <SnippetAddTrainer> 
            // label6.Text = "=============== Evaluating the model  ===============";
            var trainingPipeline = pipeline.Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                    .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            // </SnippetAddTrainer> 

            // STEP 4: Train the model fitting to the DataSet
            Console.WriteLine($"=============== Training the model  ===============");

            // <SnippetTrainModel> 
            // label7.Text = "=============== Evaluating the model  ===============";
            _trainedModel = trainingPipeline.Fit(trainingDataView);
            // </SnippetTrainModel> 
            Console.WriteLine($"=============== Finished Training the model Ending time: {DateTime.Now.ToString()} ===============");

            // // (OPTIONAL) Try/test a single prediction with the "just-trained model" (Before saving the model)
            // Console.WriteLine($"=============== Single Prediction just-trained-model ===============");

            // // Create prediction engine related to the loaded trained model
            // // <SnippetCreatePredictionEngine1>
            // _predEngine = _mlContext.Model.CreatePredictionEngine<GitHubIssue, IssuePrediction>(_trainedModel);
            // // </SnippetCreatePredictionEngine1>
            
            // // <SnippetCreateTestIssue1> 
            // GitHubIssue issue = new GitHubIssue() {
            //     NatureCode = "111"
            // };
            // // </SnippetCreateTestIssue1>

            // // <SnippetPredict>
            // var prediction = _predEngine.Predict(issue);
            // // </SnippetPredict>

            // // <SnippetOutputPrediction>
            // Console.WriteLine($"=============== Single Prediction just-trained-model - Result: {prediction.Result} ===============");
            // // </SnippetOutputPrediction>

            // <SnippetReturnModel>
            return trainingPipeline;
            // </SnippetReturnModel>
        }

        public static double[] Evaluate(DataViewSchema trainingDataViewSchema)
        {
            // STEP 5:  Evaluate the model in order to get the model's accuracy metrics
            Console.WriteLine($"=============== Evaluating to get model's accuracy metrics - Starting time: {DateTime.Now.ToString()} ===============");

            //Load the test dataset into the IDataView
            // <SnippetLoadTestDataset>
            var testDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(_testDataPath,hasHeader: true);
            // </SnippetLoadTestDataset>

            //Evaluate the model on a test dataset and calculate metrics of the model on the test data.
            // <SnippetEvaluate>
            var testMetrics = _mlContext.MulticlassClassification.Evaluate(_trainedModel.Transform(testDataView));
            // </SnippetEvaluate>

            Console.WriteLine($"=============== Evaluating to get model's accuracy metrics - Ending time: {DateTime.Now.ToString()} ===============");
            // <SnippetDisplayMetrics>
            Console.WriteLine($"*************************************************************************************************************");
            Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"*       MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
            Console.WriteLine($"*       MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
            Console.WriteLine($"*       LogLoss:          {testMetrics.LogLoss:#.###}");
            Console.WriteLine($"*       LogLossReduction: {testMetrics.LogLossReduction:#.###}");
            Console.WriteLine($"*************************************************************************************************************");
            // </SnippetDisplayMetrics>


            // label5.Text = "=============== Evaluating the model  ===============";


            // Save the new model to .ZIP file
            // <SnippetCallSaveModel>
            SaveModelAsFile(_mlContext, trainingDataViewSchema, _trainedModel);
            // </SnippetCallSaveModel>

            double[] metrics = {testMetrics.MicroAccuracy, testMetrics.MacroAccuracy,testMetrics.LogLoss, testMetrics.LogLossReduction};

            return metrics;
        }

        public static string PredictIssue(string natureCode)
        {
            // <SnippetLoadModel>
            ITransformer loadedModel = _mlContext.Model.Load(_modelPath, out var modelInputSchema);            
            // </SnippetLoadModel>

            // <SnippetAddTestIssue> 
            GitHubIssue singleIssue = new GitHubIssue() { NatureCode = natureCode };
            // </SnippetAddTestIssue> 

            //Predict label for single hard-coded issue
            // <SnippetCreatePredictionEngine>
            _predEngine = _mlContext.Model.CreatePredictionEngine<GitHubIssue, IssuePrediction>(loadedModel);
            // </SnippetCreatePredictionEngine>

            // <SnippetPredictIssue>
            var prediction = _predEngine.Predict(singleIssue);
            // </SnippetPredictIssue>

            return prediction.Result;
            
        }

        private static void SaveModelAsFile(MLContext mlContext,DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            // <SnippetSaveModel> 
            mlContext.Model.Save(model, trainingDataViewSchema, _modelPath);
            // </SnippetSaveModel>

            Console.WriteLine("The model is saved to {0}", _modelPath);
        }
    }
}
