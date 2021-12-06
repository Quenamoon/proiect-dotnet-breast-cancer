using Microsoft.ML;
using System;
using System.Linq;

namespace ML
{
    public class ModelTrainer
    {
        public static void Train()
        {
            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<PredictionData>("E:\\Facultate\\An3\\.NET\\dotnet-cancer-prediction\\backend\\Breast.Cancer.Prediction\\ModelTrainer\\data.txt", hasHeader: false, separatorChar: ',');

            var split = context.Data.TrainTestSplit(data, testFraction: 0.2);

            var features = split.TrainSet.Schema
                   .Select(col => col.Name)
                   .Where(colName => colName != "ID" && colName != "Label")
                   .ToArray();

            var pipeline = context.Transforms.Concatenate("Features", features)
                           .Append(context.BinaryClassification.Trainers.AveragedPerceptron());

            var model = pipeline.Fit(split.TestSet);
            var predictions = model.Transform(split.TestSet);

            context.Model.Save(model, data.Schema, "model.zip");
        }
    }
}
