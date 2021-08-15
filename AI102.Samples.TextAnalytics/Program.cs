using Azure;
using System;
using System.Globalization;
using Azure.AI.TextAnalytics;

namespace AI102.Samples.TextAnalytics
{
    class Program
    {

        // This needs to be removed eventually
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("PUSH YOUR KEYS HERE");
        private static readonly Uri endpoint = new Uri("https://sgaitextanalytics.cognitiveservices.azure.com/");

        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            // You will implement these methods later in the quickstart.
            SentimentAnalysisExample(client);            
            KeyPhraseExtractionExample(client);

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

        static void SentimentAnalysisExample(TextAnalyticsClient client)
        {
            string inputText = "I had the best day of my life. I wish you were there with me.";
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(inputText);
            Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

            foreach (var sentence in documentSentiment.Sentences)
            {
                Console.WriteLine($"\tText: \"{sentence.Text}\"");
                Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
                Console.WriteLine($"\tPositive score: {sentence.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tNegative score: {sentence.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tNeutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");
            }
        }


        static void KeyPhraseExtractionExample(TextAnalyticsClient client)
        {
            var response = client.ExtractKeyPhrases("My cat might need to see a veterinarian.");

            // Printing key phrases
            Console.WriteLine("Key phrases:");

            foreach (string keyphrase in response.Value)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }

    } 
}
