﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.MachineLearning
{
    public class SentimentData
    {
        [LoadColumn(0)]
        public string? SentimentText;

        [LoadColumn(1), ColumnName("Label")]
        public bool Sentiment;
    }

    public class SentimentPrediction : SentimentData
    {

        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}
