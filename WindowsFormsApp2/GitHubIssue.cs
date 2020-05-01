﻿/*
 * @Author: Haolin Liu
 * @Date: 2020-02-16 17:01:58
 * @LastEditTime: 2020-04-30 17:26:29
 * @LastEditors: Haolin Liu
 * @Description: The data type for machine learning to analyse
 */
 using Microsoft.ML.Data;

namespace WindowsFormsApp2
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
        public string CallRecived { get; set; }
        [LoadColumn(4)]
        public string Address { get; set; }
    }

    public class IssuePrediction
    {
        [ColumnName("PredictedLabel")]
        public string Result;
    }
}
