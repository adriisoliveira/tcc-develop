using APIController.Annotations;
using APIController.Business.Entity.Users;
using APIController.Business.Interfaces.Service.Logs;
using APIController.Business.Interfaces.Service.Users;
using APISummarizationClient.Client;
using APISummarizationClient.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIController.Controllers
{
    [ApiController]
    [Route("teste")]
    public class TesteController : BaseController
    {
        protected IUserService _userService;
        public IApiAccessLogService _apiAccessLogService;
        public IApiClient _client;
        public TesteController(IUserService userService, IApiAccessLogService apiAccessLogService, IApiClient client)
        {
            _userService = userService;
            _apiAccessLogService = apiAccessLogService;
            _client = client;
        }

        //[HttpGet]
        //public IEnumerable<User> Index()
        //{
        //    return _userService.GetAll();
        //}

        [HttpGet]
        public bool Teste()
        {
            return true;
        }

        [HttpGet]
        [Route("luhn")]
        public string luhn()
        {
            var result =  _client.Summarization.SummyLuhn("O Campeonato Mundial de Fórmula 1 da FIA de 2008 foi a 59.ª temporada da competição anual de Fórmula 1, categoria de monopostos reconhecida pela Fédération Internationale de l'Automobile (FIA). O campeonato foi disputado em dezoito etapas, iniciando na Austrália em 16 de março e terminando no Brasil em 2 de novembro. Nesta temporada ocorreu a estreia do Grande Prêmio de Singapura, realizado no Circuito Urbano de Marina Bay, sendo a primeira corrida da história da Fórmula 1 a ser realizada à noite. O Grande Prêmio da Europa passou a ser sediado no Circuito Urbano de Valência, em Valência, Espanha. O piloto inglês Lewis Hamilton da McLaren conquistou seu primeiro campeonato de pilotos com a diferença final de um ponto para o brasileiro Felipe Massa da Ferrari, que ficou com a segunda colocação, enquanto seu companheiro de equipe Kimi Räikkönen ficou com a terceira colocação.A Ferrari também venceu o campeonato de construtores, ficando a McLaren com a segunda colocação e a BMW Sauber com a terceira colocação.Na conquista do título, Hamilton se tornou o piloto mais jovem a conquistar o campeonato mundial desta categoria, sendo superado posteriormente por Sebastian Vettel em 2010, bem como o primeiro piloto negro a conquistá-lo.", 1);
            return result.Text;
        }
    }
}
