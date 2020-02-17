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
    }

    public class IssuePrediction
    {
        [ColumnName("PredictedLabel")]
        public string Result;
    }
}
