using APISummarizationClient.Model;

namespace APISummarizationClient.Interfaces
{
    public interface ISummarizationClient
    {
        SummyLuhnData SummyLuhn(string text, int qnt);
    }
}
