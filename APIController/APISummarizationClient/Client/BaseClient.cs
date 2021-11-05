using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;

namespace APISummarizationClient.Client
{
    public class BaseClient
    {
        public BaseClient(IConfiguration configuration)
        {
            Host = configuration.GetSection("ClientConnections:Summy")["Host"];
        }
        public BaseClient(string controllerPath, IConfiguration configuration) : this(configuration)
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
