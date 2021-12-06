using Microsoft.ML.Data;

namespace ML
{
    internal class Result
    {
        [ColumnName("Score")]
        public float PredictedValue { get; set; }
    }
}
