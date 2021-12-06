using Microsoft.ML.Data;


namespace ML
{
    public class PredictionData
    {
        [LoadColumn(0), ColumnName("ID")]
        public int IDNumber { get; set; }

        [LoadColumn(1), ColumnName("Label")]
        public bool Diagnosis { get; set; }

        [LoadColumn(2)]
        public float Radius1 { get; set; }

        [LoadColumn(3)]
        public float Texture1 { get; set; }

        [LoadColumn(4)]
        public float Perimeter1 { get; set; }

        [LoadColumn(5)]
        public float Area1 { get; set; }

        [LoadColumn(6)]
        public float Smoothness1 { get; set; }

        [LoadColumn(7)]
        public float Compactness1 { get; set; }

        [LoadColumn(8)]
        public float Concavity1 { get; set; }

        [LoadColumn(9)]
        public float ConcavePoints1 { get; set; }

        [LoadColumn(10)]
        public float Symmetry1 { get; set; }

        [LoadColumn(11)]
        public float FractalDimension1 { get; set; }

        [LoadColumn(12)]
        public float Radius2 { get; set; }

        [LoadColumn(13)]
        public float Texture2 { get; set; }

        [LoadColumn(14)]
        public float Perimeter2 { get; set; }

        [LoadColumn(15)]
        public float Area2 { get; set; }

        [LoadColumn(16)]
        public float Smoothness2 { get; set; }

        [LoadColumn(17)]
        public float Compactness2 { get; set; }

        [LoadColumn(18)]
        public float Concavity2 { get; set; }

        [LoadColumn(19)]
        public float ConcavePoints2 { get; set; }

        [LoadColumn(20)]
        public float Symmetry2 { get; set; }

        [LoadColumn(21)]
        public float FractalDimension2 { get; set; }

        [LoadColumn(22)]
        public float Radius3 { get; set; }

        [LoadColumn(23)]
        public float Texture3 { get; set; }

        [LoadColumn(24)]
        public float Perimeter3 { get; set; }

        [LoadColumn(25)]
        public float Area3 { get; set; }

        [LoadColumn(26)]
        public float Smoothness3 { get; set; }

        [LoadColumn(27)]
        public float Compactness3 { get; set; }

        [LoadColumn(28)]
        public float Concavity3 { get; set; }

        [LoadColumn(29)]
        public float ConcavePoints3 { get; set; }

        [LoadColumn(30)]
        public float Symmetry3 { get; set; }

        [LoadColumn(31)]
        public float FractalDimension3 { get; set; }
    }
}
