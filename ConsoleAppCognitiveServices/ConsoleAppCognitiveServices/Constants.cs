using Azure;
using System;

namespace ConsoleAppCognitiveServices
{
    public static class Constants
    {
        public static readonly AzureKeyCredential credentials = new AzureKeyCredential("24a7d25983fc4c218b207a36345cbc88");
        public static readonly Uri endpoint = new Uri("https://azure-ai-text-analysis.cognitiveservices.azure.com/");
        public static readonly string langTranslationUrl = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=fr";

    }
}
