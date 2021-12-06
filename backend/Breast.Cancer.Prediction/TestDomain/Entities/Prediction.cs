using Domain.Common;
using Microsoft.ML.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("predictions")]
    public class Prediction : BaseEntity
    {
        [Column("userID")]
        public Guid patientID { get; set; }

        [Column("diagnosis")]
        public bool Diagnosis { get; set; }

        [Column("radius1")]
        public float Radius1 { get; set; }

        [Column("texture1")]
        [LoadColumn(3)]
        public float Texture1 { get; set; }

        [Column("perimeter1")]
        [LoadColumn(4)]
        public float Perimeter1 { get; set; }

        [Column("area1")]
        [LoadColumn(5)]
        public float Area1 { get; set; }

        [Column("smoothness1")]
        [LoadColumn(6)]
        public float Smoothness1 { get; set; }

        [Column("compactness1")]
        [LoadColumn(7)]
        public float Compactness1 { get; set; }

        [Column("concavity1")]
        [LoadColumn(8)]
        public float Concavity1 { get; set; }

        [Column("concavePoints1")]
        [LoadColumn(9)]
        public float ConcavePoints1 { get; set; }

        [Column("symmetry1")]
        [LoadColumn(10)]
        public float Symmetry1 { get; set; }

        [Column("fractalDimension1")]
        [LoadColumn(11)]
        public float FractalDimension1 { get; set; }

        [Column("radius2")]
        [LoadColumn(12)]
        public float Radius2 { get; set; }

        [Column("texture2")]
        [LoadColumn(13)]
        public float Texture2 { get; set; }

        [Column("perimeter2")]
        [LoadColumn(14)]
        public float Perimeter2 { get; set; }

        [Column("area2")]
        [LoadColumn(15)]
        public float Area2 { get; set; }

        [Column("smoothness2")]
        [LoadColumn(16)]
        public float Smoothness2 { get; set; }

        [Column("compactness2")]
        [LoadColumn(17)]
        public float Compactness2 { get; set; }

        [Column("concavity2")]
        [LoadColumn(18)]
        public float Concavity2 { get; set; }

        [Column("concavePoints2")]
        [LoadColumn(19)]
        public float ConcavePoints2 { get; set; }

        [Column("symmetry2")]
        public float Symmetry2 { get; set; }

        [Column("fractalDimension2")]
        public float FractalDimension2 { get; set; }

        [Column("radius3")]
        public float Radius3 { get; set; }

        [Column("texture3")]
        public float Texture3 { get; set; }

        [Column("perimeter3")]
        public float Perimeter3 { get; set; }

        [Column("area3")]
        public float Area3 { get; set; }

        [Column("smoothness3")]
        public float Smoothness3 { get; set; }

        [Column("compactness3")]
        public float Compactness3 { get; set; }

        [Column("concavity3")]
        public float Concavity3 { get; set; }

        [Column("concavePoints3")]
        public float ConcavePoints3 { get; set; }

        [Column("symmetry3")]
        public float Symmetry3 { get; set; }

        [Column("fractalDimension3")]
        public float FractalDimension3 { get; set; }

        [Column("predictionDate")]
        public DateTime PredictionDate { get; set; }
    }
}
