using Domain.Entities;
using Microsoft.ML;

namespace ML
{
    public class DiagnosisPredictor
    {
        private ITransformer trainedModel;
        private static DiagnosisPredictor instance;

        private DiagnosisPredictor()
        {
            trainedModel = ModelLoader.Load();
        }

        public void UpdateModel()
        {
            trainedModel = ModelLoader.Load();
        }

        public bool Predict(Prediction data)
        {
            PredictionData predictionData = new PredictionData
            {
                IDNumber = 0,
                Radius1 = data.Radius1,
                Texture1 = data.Texture1,
                Perimeter1 = data.Perimeter1,
                Area1 = data.Area1,
                Smoothness1 = data.Smoothness1,
                Compactness1 = data.Compactness1,
                Concavity1 = data.Concavity1,
                ConcavePoints1 = data.ConcavePoints1,
                Symmetry1 = data.Symmetry1,
                FractalDimension1 = data.FractalDimension1,
                Radius2 = data.Radius2,
                Texture2 = data.Texture2,
                Perimeter2 = data.Perimeter2,
                Area2 = data.Area2,
                Smoothness2 = data.Smoothness2,
                Compactness2 = data.Compactness2,
                Concavity2 = data.Concavity2,
                ConcavePoints2 = data.ConcavePoints2,
                Symmetry2 = data.Symmetry2,
                FractalDimension2 = data.FractalDimension2,
                Radius3 = data.Radius3,
                Texture3 = data.Texture3,
                Perimeter3 = data.Perimeter3,
                Area3 = data.Area3,
                Smoothness3 = data.Smoothness3,
                Compactness3 = data.Compactness3,
                Concavity3 = data.Concavity3,
                ConcavePoints3 = data.ConcavePoints3,
                Symmetry3 = data.Symmetry3,
                FractalDimension3 = data.FractalDimension3
            };
            var context = new MLContext();
            PredictionEngine<PredictionData, Result> predictionEngine = context.Model.CreatePredictionEngine<PredictionData, Result>(trainedModel);

            Result prediction = predictionEngine.Predict(predictionData);

            return prediction.PredictedValue > 0;
        }

        public static DiagnosisPredictor GetInstance()
        {
            if (instance == null)
            {
                instance = new DiagnosisPredictor();
            }
            return instance;
        }

    }
}
