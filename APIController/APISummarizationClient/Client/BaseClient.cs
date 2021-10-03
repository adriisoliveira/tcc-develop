using Newtonsoft.Json.Linq;
using System.IO;

namespace APISummarizationClient.Client
{
    public class BaseClient
    {
        public BaseClient()
        {
            JObject jObject = JObject.Parse(File.ReadAllText(
                   Path.Combine(
                       Directory.GetParent(
                           System.IO.Directory.GetCurrentDirectory())
                       .FullName, "APISummarizationClient\\apiconnection.json")));
            Host = jObject["api"]["host"].ToString().Trim().Trim('/');
        }
        public BaseClient(string controllerPath) : this()
        {
            ControllerPath = controllerPath;
        }
        #region :: Propriedades
        protected string Host { get; private set; }
        public string ControllerPath { get; set; }

        public string Url { get { return string.Format("{0}/{1}", Host, ControllerPath); } }
        #endregion
    }
}
