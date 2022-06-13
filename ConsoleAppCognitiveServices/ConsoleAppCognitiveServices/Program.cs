using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Azure;
using Azure.AI.TextAnalytics;
using RestSharp;
using Newtonsoft.Json;
using System.Speech.Synthesis;
using SpeechSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

namespace ConsoleAppCognitiveServices
{
    public class Program
    {
       
        static async Task Main(string[] args)
        {
            var client = new TextAnalyticsClient(Constants.endpoint, Constants.credentials);
            var speechTextResult = await Handler.SpeechToTextExample();
            Console.WriteLine("~................................~ Speech Recognization Finished ~................................~!\n\n");

            Handler.SentimentAnalysisExample(client, speechTextResult);
            Console.WriteLine("~................................~Sentiment Analysis Finished~................................~!\n\n");

            Handler.LanguageDetectAndTranslateExample(client, speechTextResult);
            Console.WriteLine("~................................~ Language Detection and Translation Finished ~................................~!\n\n");

            Handler.EntityRecognitionExample(client, speechTextResult);
            Console.WriteLine("~................................~ Entity Recognition Finished ~................................~!\n\n");

            Handler.EntityLinkingExample(client);
            Console.WriteLine("~................................~ Entity Linking Finished ~................................~!\n\n");

            Handler.KeyPhraseExtractionExample(client, speechTextResult);
            Console.WriteLine("~................................~ Key Phrase Extraction Finished ~................................~!\n\n");


            Handler.TextToSpeechExample(client, speechTextResult);
            Console.WriteLine("~................................~ Text to Speech Finished ~................................~!\n\n");


            Console.Write("Press any key to exit.");
            Console.ReadKey();
            Console.WriteLine("Finished");
        }
    }
}
