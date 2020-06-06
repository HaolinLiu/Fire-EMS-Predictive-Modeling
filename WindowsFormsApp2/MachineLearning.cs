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
        private static string _trainDataPath => Path.Combine(_appPath, "Data", "ModelFileTrain.tsv");
        private static string _testDataPath => Path.Combine(_appPath, "Data", "ModelFileTest.tsv");
        private static string _modelPath => Path.Combine(_appPath, "Models", "model.zip");
        private static string _modelFolderPath => Path.Combine(_appPath, "Models");
        private static string _rulesFolderPath => Path.Combine(_appPath, "Data");



        private static MLContext _mlContext;
        private static PredictionEngine<GitHubIssue, IssuePrediction> _predEngine;
        private static ITransformer _trainedModel;
        static IDataView _trainingDataView;

        private AnalyzeData ana;
        private CallResponseData[] combinedData;
        // public string processText = "s";
        
        public void Import (string callPath, string responsePath){
            // read data from files
            DataTable callDataTable = CallData.ImportCallData(callPath);
            DataTable ResponseDataTable = CallData.ImportCallData(responsePath);

            // combine all data to CallResponseData
            ana = new AnalyzeData();
            combinedData = ana.CombineData(callDataTable, ResponseDataTable);
        }

        public AnalyzeData GetAna() {
            return ana;
        }

        public int[] CreatTsv(List<int> month, List<int> week, List<int> year, int[] time) {
            // check if data folder exist, if not create it
            if (!Directory.Exists(_rulesFolderPath))
            {
                Directory.CreateDirectory(_rulesFolderPath);
            }

            ModelFileCreater c = new ModelFileCreater();
            int[] selectItemNum = c.CreatFile(combinedData, ana.callCount, _trainDataPath, _testDataPath, month, week, year, time);

            // for debug
            Console.WriteLine(ana.callCount);
            Console.WriteLine(_trainDataPath);
            Console.WriteLine(_testDataPath);

            return selectItemNum;
        }

        public void CreatRulesFile(string value){
            List<long> result = new List<long>();

            for (int i=0; i<ana.NatureCodeTypeNum; i++){
                result.Add(long.Parse(PredictIssue(ana.NatureCodeType[i])));
            }

            ResultData r = new ResultData(ana.NatureCodeType, ana.NatureCodeTypeNum, ana.UnitTypeName, ana.UnitTypeNum, result);
            r.PrintResult(_rulesFolderPath, value);
        }

        public double[] ML (){

            // Create MLContext to be shared across the model creation workflow objects 
            // Set a random seed for repeatable/deterministic results across multiple trainings.
            // <SnippetCreateMLContext>
            _mlContext = new MLContext(seed: 0);
            // </SnippetCreateMLContext>

            // STEP 1: Common data loading configuration 
            // CreateTextReader<GitHubIssue>(hasHeader: true) - Creates a TextLoader by inferencing the dataset schema from the GitHubIssue data model type.
            // .Read(_trainDataPath) - Loads the training text file into an IDataView (_trainingDataView) and maps from input columns to IDataView columns.
            Console.WriteLine($"=============== Loading Dataset  ===============");
            
            // <SnippetLoadTrainData>
            _trainingDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(_trainDataPath, hasHeader: true);
            // </SnippetLoadTrainData>

            Console.WriteLine($"=============== Finished Loading Dataset  ===============");
            
            // <SnippetSplitData>
            //   var (trainData, testData) = _mlContext.MulticlassClassification.TrainTestSplit(_trainingDataView, testFraction: 0.1);
            // </SnippetSplitData>

            // <SnippetCallProcessData>
            var pipeline = ProcessData();
            // </SnippetCallProcessData>

            // <SnippetCallBuildAndTrainModel>
           var trainingPipeline = BuildAndTrainModel(_trainingDataView, pipeline);
            // </SnippetCallBuildAndTrainModel>

            // <SnippetCallEvaluate>
            double[] accuracy = Evaluate(_trainingDataView.Schema);
            // </SnippetCallEvaluate>
  

            Console.WriteLine("Finish project");

            return accuracy;
        }

        public static IEstimator<ITransformer> ProcessData()
        {   
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

        public static IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
        {
            // STEP 3: Create the training algorithm/trainer
            // Use the multi-class SDCA algorithm to predict the label using features.
            //Set the trainer/algorithm and map label to value (original readable state)
            // <SnippetAddTrainer> 
            var trainingPipeline = pipeline.Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                    .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            // </SnippetAddTrainer> 

            // STEP 4: Train the model fitting to the DataSet
            Console.WriteLine($"=============== Training the model  ===============");

            // <SnippetTrainModel> 
            _trainedModel = trainingPipeline.Fit(trainingDataView);
            // </SnippetTrainModel> 
            Console.WriteLine($"=============== Finished Training the model Ending time: {DateTime.Now.ToString()} ===============");

            // (OPTIONAL) Try/test a single prediction with the "just-trained model" (Before saving the model)
            Console.WriteLine($"=============== Single Prediction just-trained-model ===============");

            // Create prediction engine related to the loaded trained model
            // <SnippetCreatePredictionEngine1>
            _predEngine = _mlContext.Model.CreatePredictionEngine<GitHubIssue, IssuePrediction>(_trainedModel);
            // </SnippetCreatePredictionEngine1>
            // <SnippetCreateTestIssue1> 
            GitHubIssue issue = new GitHubIssue() {
                NatureCode = "111"
            };
            // </SnippetCreateTestIssue1>

            // <SnippetPredict>
            var prediction = _predEngine.Predict(issue);
            // </SnippetPredict>

            // <SnippetOutputPrediction>
            Console.WriteLine($"=============== Single Prediction just-trained-model - Result: {prediction.Result} ===============");
            // </SnippetOutputPrediction>

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
            // create models folder if it is not exist
            if (!Directory.Exists(_modelFolderPath))
            {
                Directory.CreateDirectory(_modelFolderPath);
            }

            // <SnippetSaveModel> 
            mlContext.Model.Save(model, trainingDataViewSchema, _modelPath);
            // </SnippetSaveModel>

            Console.WriteLine("The model is saved to {0}", _modelPath);
        }
    }
}
