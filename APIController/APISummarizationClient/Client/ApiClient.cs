using APISummarizationClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace APISummarizationClient.Client
{
    public class ApiClient : IApiClient
    {
        public ApiClient(
            ISummarizationClient summarizationClient)
        {
            Summarization = summarizationClient;
        }
        public ISummarizationClient Summarization { get; set; }
    }
}
