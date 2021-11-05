using APISummarizationClient.Interfaces;
using APISummarizationClient.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace APISummarizationClient.Client
{
    public class SummarizationClient : BaseClient, ISummarizationClient
    {
        public SummarizationClient(IConfiguration configuration) : base("summy", configuration) { }

        public SummyLuhnData SummyLuhn(string text, int lineQuantity)
        {
            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("text", text);
                parameters.Add("qnt", lineQuantity.ToString());

                return Call<SummyLuhnData>(parameters);
            }
        }

        #region :: Métodos privados
        ///TODO: permitir enviar queryString
        ///permitir adicionar mais fragments à url
        private TModel Call<TModel>(IDictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Url),
                    Content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Access-Control-Allow-Origin", "*");

                var responseContent = client.SendAsync(request).Result;
                var result = responseContent.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TModel>(result);
            }
        }
        #endregion
    }
}
