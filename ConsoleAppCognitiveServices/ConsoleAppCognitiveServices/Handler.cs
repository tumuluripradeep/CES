using Azure.AI.TextAnalytics;
using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

namespace ConsoleAppCognitiveServices
{
    public static class Handler
    {

        public static async Task<string> SpeechToTextExample()
        {
            var configuration = SpeechConfig.FromSubscription($AZUREAPIKEY, "eastus");
            var speechText = string.Empty;
            using (var recog = new SpeechRecognizer(configuration))
            {
                Console.WriteLine("Speak Something...!");
                var result = await recog.RecognizeOnceAsync();
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine(result.Text);
                    speechText = result.Text;
                }
            }
            return speechText;
        }

        public static void SentimentAnalysisExample(TextAnalyticsClient client, string speechTextResult)
        {
            //string inputText = "I had the best day of my life. I wish you were there with me.";
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(speechTextResult);
            Console.WriteLine($"Overall sentiment: {documentSentiment.Sentiment}\n");

            foreach (var sentence in documentSentiment.Sentences)
            {
                Console.WriteLine($"\tText: \"{sentence.Text}\"");
                Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
                Console.WriteLine($"\tPositive score: {sentence.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tNegative score: {sentence.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tNeutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");
            }
        }

        public static void LanguageDetectAndTranslateExample(TextAnalyticsClient client, string speechTextResult)
        {
            //DetectedLanguage detectedLanguage = client.DetectLanguage("Ce document est rédigé en Français.");
            DetectedLanguage detectedLanguage = client.DetectLanguage(speechTextResult);
            Console.WriteLine("Detected Language:");
            Console.WriteLine($"\t{detectedLanguage.Name},\tISO-6391: {detectedLanguage.Iso6391Name}\n");

            var response = Helper.PerformRestCall(speechTextResult);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //var rawResponse = response.Content;
                //Responseobject result = JsonConvert.DeserializeObject<Responseobject>(rawResponse);
                Console.WriteLine("Translated Language:");
                Console.WriteLine($"\t{response.Content}\n");
            }
        }

        public static void EntityRecognitionExample(TextAnalyticsClient client, string speechTextResult)
        {
            //speechTextResult = "I had a wonderful trip to Seattle last week.";
            var response = client.RecognizeEntities(speechTextResult);
            Console.WriteLine("Named Entities:");
            foreach (var entity in response.Value)
            {
                Console.WriteLine($"\tText: {entity.Text},\tCategory: {entity.Category},\tSub-Category: {entity.SubCategory}");
                Console.WriteLine($"\t\tScore: {entity.ConfidenceScore:F2}\n");
            }
        }

        public static void EntityLinkingExample(TextAnalyticsClient client)
        {
            var response = client.RecognizeLinkedEntities(
                "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, " +
                "to develop and sell BASIC interpreters for the Altair 8800. " +
                "During his career at Microsoft, Gates held the positions of chairman, " +
                "chief executive officer, president and chief software architect, " +
                "while also being the largest individual shareholder until May 2014.");
            Console.WriteLine("Linked Entities:");
            foreach (var entity in response.Value)
            {
                Console.WriteLine($"\tName: {entity.Name},\tID: {entity.DataSourceEntityId},\tURL: {entity.Url}\tData Source: {entity.DataSource}");
                Console.WriteLine("\tMatches:");
                foreach (var match in entity.Matches)
                {
                    Console.WriteLine($"\t\tText: {match.Text}");
                    Console.WriteLine($"\t\tScore: {match.ConfidenceScore:F2}\n");
                }
            }
        }

        public static void KeyPhraseExtractionExample(TextAnalyticsClient client, string speechTextResult)
        {
            var response = client.ExtractKeyPhrases(speechTextResult);
            // Printing key phrases
            Console.WriteLine("Key phrases:");

            foreach (string keyphrase in response.Value)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }

        public static void TextToSpeechExample(TextAnalyticsClient client, string speechTextResult)
        {
            Console.WriteLine("Enter some text to validate text to speech:");
            var textEntered = Console.ReadLine();
            SpeechSynthesizer _SS = new SpeechSynthesizer();
            _SS.Volume = 100;
            _SS.Speak(textEntered);
        }
    }
}
