using System;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using Tcc.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tcc.API.Controllers
{
    [Route("index")]    // Rota genérica do controller
    public class DefaultController : ControllerBase
    {
        // PLACEHOLDER -> Inserir conexão do banco de dados aqui
        private string ConnectionString = "Data Source=DESKTOP-J9H9Q9B;Initial Catalog=ApiTeste;Integrated Security=True";
        // Variável que recebe os dados do BD
        SqlCommand cmd = new SqlCommand();

        [HttpGet]
        [Route("Consulta")]
        public IActionResult GetConsultaResult(int idWeb)
        {
            try
            {
                Teste userTest = new Teste();   // PLACEHOLDER
                // Variável que lê as informações puxadas pelo BD para exibir
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Operação SQL
                    cmd.CommandText = "SELECT * FROM "; // Preciso do BD para inserir a requisição aqui
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);  // Preciso do BD e Informações da Pagina WEB para completar
                    // Estabelece a conexão com o BD
                    cmd.Connection = connection;
                    // Faz algo, o que ainda não sei
                    reader = cmd.ExecuteReader();
                    if (reader.Read()) 
                    {
                        userTest.setId(Convert.ToInt32(reader["id"]));  // PLACEHOLDER
                        connection.Close();
                        return Ok("PLACEHOLDER");
                    } else 
                    {
                        return Ok("Não há resultado correspondentes a pesquisa");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
                throw;
            }
        }

        [HttpPost]
        [Route("Cadastro")]
        public IActionResult GetCadastroResult(int idWeb)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Comando SQL
                    cmd.CommandText = "INSERT INTO <Table> VALUES <Values>";    // HOLDERPLACE
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);  // REDLOHECALP
                    // Estabelece a conexão com o BD
                    cmd.Connection = connection;    
                    // Executa o comando SQL
                    cmd.ExecuteNonQuery();

                    // Encerra a conexão, e eu vou encerrar a vida de alguém >:(
                    connection.Close(); 
                }
                return Ok("SEGURADOR DE LUGAR");   // Se não fuder tudo, manda um código 200 (OK) com a mensagem Sucesso
            } catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);   // Fudeu tudo, portanto avisa e mostra o erro
                throw;
            }
        }
        
        [HttpPost]
        [Route("Atualizar")]
        public IActionResult GetUpdateResult(int idWeb) {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Comando SQL
                    cmd.CommandText = "UPDATE <table> SET <values> WHERE <condition>";    // PLACEHOLDER
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);  // PLACEHOLDER
                    // Estabelece a conexão com o BD
                    cmd.Connection = connection;    
                    // Executa o comando SQL
                    cmd.ExecuteNonQuery();

                    // Encerra a conexão, e eu vou encerrar a vida de alguém >:(
                    connection.Close(); 
                }
                return Ok("PLACEHOLDER");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
                throw;
            }
        }

        [HttpPost]   /* Por razões técnicas, o delete tem que ser referenciado como POST,
                       se der, tento arrumar depois*/ 
        [Route("Delete")]
        public IActionResult GetDeleteResult(int idWeb) {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Comando SQL
                    cmd.CommandText = "DELETE FROM <Table> WHERE <Condição>";
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);  // PLACEHOLDER, estou vendo um padrão
                    // Estabelece a conexão com o BD
                    cmd.Connection = connection;
                    // Executa o comando SQL
                    cmd.ExecuteNonQuery();

                    // Encerra a conexão, e eu vou encerrar a vida de alguém >:(
                    connection.Close(); 
                }
                return Ok("Deletado!");
            } catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
                throw;
            }
        }  
    }   
}