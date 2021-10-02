using System;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using Tcc.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tcc.API.Controllers
{
    [Route("Api")]  // Rota inicial. Todos os endereços dos métodos "passam" por essa rota 
                    // (Ex. http://localhost:5000/api/Exemplo)
    public class TesteController : ControllerBase
    {
        // Informação de conexão com o banco de dados
        private string ConnectionString = "Data Source=DESKTOP-J9H9Q9B;Initial Catalog=ApiTeste;Integrated Security=True";
        // Variável para comandos do BD
        SqlCommand cmd = new SqlCommand();
        
        [HttpGet]           // Puxa do BD
        [Route("Teste")]    // http://localhost:5000/api/Teste
        // Método de teste de conexão do Postman. Provavelmente será deletado no fim
        public IActionResult Get() {
            // Retorna um código 200 (Ok), como uma mensagem
            return Ok("Tá safe");
        }

        [HttpGet]
        [Route("DataBaseGet")]
        public IActionResult GetByBd(int idWeb, string nomeWeb, int resultId, string resultNome) {
            try
            {
                Teste userTest = new Teste();
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Comando SQL
                    cmd.CommandText = "SELECT id, nomeTeste FROM teste WHERE id = @id";
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);
                    // Estabelece a conexão com o BD
                    cmd.Connection = connection;
                    // Faz algo, o que ainda não sei
                    reader = cmd.ExecuteReader();
                    if (reader.Read()) 
                    {
                        userTest.setId(Convert.ToInt32(reader["id"]));
                        userTest.setNomeTeste(Convert.ToString(reader["nomeTeste"]));
                        resultId = userTest.getId();
                        resultNome = userTest.getNomeTeste();
                        connection.Close();
                        return Ok("Sucesso: id = " + userTest.getId() + "Nome = " + userTest.getNomeTeste());
                    } else 
                    {
                        connection.Close();
                        return Ok("Usuário não encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);
                throw;
            }
        }

        [HttpPost]               // Adiciona ao BD
        [Route("DataBasePost")]  // http://localhost:5000/api/DataBasePost
        public IActionResult GetByWeb(int idWeb, string nomeWeb)   // Método retorna o resultado 
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Comando SQL
                    cmd.CommandText = "insert into Teste (id, nomeTeste) values (@id, @nomeTeste)";
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);
                    cmd.Parameters.AddWithValue("@NomeTeste", nomeWeb); 
                    // Estabelece a conexão com o BD
                    cmd.Connection = connection;
                    // Executa o comando SQL
                    cmd.ExecuteNonQuery();


                    // Encerra a conexão, e eu vou encerrar a vida de alguém >:(
                    connection.Close(); 
                }
                return Ok("Sucesso");   // Se não fuder tudo, manda um código 200 (OK) com a mensagem Sucesso
            } catch (Exception ex)
            {
                return BadRequest("Erro: " + ex);   // Fudeu tudo, portanto avisa e mostra o erro
                throw;
            }
	    }

        [HttpPost]            // Deleta do BD
        [Route("DataBaseDel")]  // http://localhost:5000/api/DataBaseDel
        public IActionResult GetByYeet(int idWeb)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    // Abre a conexão com o BD
                    connection.Open();

                    // Comando SQL
                    cmd.CommandText = "delete from Teste where id = @id";
                    // Parametros usados para inserir no BD
                    cmd.Parameters.AddWithValue("@id", idWeb);
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