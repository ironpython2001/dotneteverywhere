using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;



namespace MLDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://carlos.mendible.com/2018/06/10/simple-machine-learning-with-dotnet-core-sample/
            // Create a learning pipeline
            var pipeline = new LearningPipeline();

            // Load training data and add it to the pipeline
            string dataPath = @"titanic.training.csv";
            var data = new TextLoader(dataPath).CreateFrom<TitanicData>(useHeader: true, separator: ',');
            pipeline.Add(data);

            // Transform any text feature to numeric values
            pipeline.Add(new CategoricalOneHotVectorizer(
                "Sex",
                "Ticket",
                "Fare",
                "Cabin",
                "Embarked"));

            // Put all features into a vector
            pipeline.Add(new ColumnConcatenator(
                "Features",
                "Pclass",
                "Sex",
                "Age",
                "SibSp",
                "Parch",
                "Ticket",
                "Fare",
                "Cabin",
                "Embarked"));

            // Add a learning algorithm to the pipeline. 
            // This is a classification scenario (Did this passenger survive?)
            //pipeline.Add(new FastTreeBinaryClassifier() { NumLeaves = 5, NumTrees = 10, MinDocumentsInLeafs = 2 });
            //pipeline.Add(new FastTreeBinaryClassifier() );
            pipeline.Add(new Microsoft.ML.Trainers.FastTreeBinaryClassifier());

            // Train your model based on the data set
            Console.WriteLine($"Training Titanic.ML model...");
            var model = pipeline.Train<TitanicData, TitanicPrediction>();

            // Save the model to a file
            var modelPath = @"titanic.model";
            model.WriteAsync(modelPath).Wait();

            // Use your model to make a prediction
            var prediction = model.Predict(new TitanicData()
            {
                Pclass = 3f,
                Name = "Braund, Mr. Owen Harris",
                Sex = "male",
                Age = 31,
                SibSp = 0,
                Parch = 0,
                Ticket = "335097",
                Fare = "7.75",
                Cabin = "",
                Embarked = "Q"
            });

            Console.WriteLine($"Did this passenger survive? {(prediction.Survived ? "Yes" : "No")}");

            // Evaluate the model using the test data
            Console.WriteLine($"Evaluating Titanic.ML model...");
            dataPath = @"titanic.csv";
            data = new TextLoader(dataPath).CreateFrom<TitanicData>(useHeader: true, separator: ',');
            var evaluator = new Microsoft.ML.Models.BinaryClassificationEvaluator();
            var metrics = evaluator.Evaluate(model, data);
            
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.Auc:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.ReadLine();
        }
    }
}
