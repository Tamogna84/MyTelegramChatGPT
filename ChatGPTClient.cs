using Newtonsoft.Json;
using OpenAI.ChatGpt;
using OpenAI.ChatGpt.Models.ChatCompletion.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyTelegramChatGPT
{
    internal class ChatGPTClient
    {
        public async Task<string> Ask(string text)
        {    
           
            
            string? key = Environment.GetEnvironmentVariable("openai_api_key");
            if (key == null)
            {
                throw new InvalidOperationException("Переменная окружения openai_api_key не задана!");
            }

            using var client = new OpenAiClient(key);

                       
            string response = await client.GetChatCompletions(new UserMessage(text), maxTokens: 1000);
            
            return response;
        }

    }
}
