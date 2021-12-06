using Microsoft.ML;

namespace ML
{
    public class ModelLoader
    {
        public static ITransformer Load()
        {
            DataViewSchema modelSchema;
            var context = new MLContext();

            // Load trained model
            ITransformer trainedModel = context.Model.Load("model.zip", out modelSchema);

            return trainedModel;
        }
    }
}
