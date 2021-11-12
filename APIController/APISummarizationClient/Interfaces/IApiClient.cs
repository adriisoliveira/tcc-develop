namespace APISummarizationClient.Interfaces
{
    public interface IApiClient
    {
        public ISummarizationClient Summarization { get; set; }
    }
}
