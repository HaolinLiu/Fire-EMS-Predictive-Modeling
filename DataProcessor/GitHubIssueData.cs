using Microsoft.ML.Data;

namespace DataProcessor
{
    public class GitHubIssue
    {
        [LoadColumn(0)]
        public string ID { get; set; }
        [LoadColumn(1)]
        public string Result { get; set; }
        [LoadColumn(2)]
        public string NatureCode { get; set; }
        [LoadColumn(3)]
        public string CallRecived {get; set; }
        [LoadColumn(4)]
        public string Address {get; set; }
        
    }

    public class IssuePrediction
    {
        [ColumnName("PredictedLabel")]
        public string Result;
    }
}
