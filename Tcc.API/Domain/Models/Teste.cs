using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcc.API.Domain.Models
{
    public class Teste
    {
        private int id;
        private string nomeTeste;
        public Teste() {}
        public Teste(int id, string nomeTeste) {
            this.id = id;
            this.nomeTeste = nomeTeste;
        }

        public int getId() {
            return this.id;
        }
        public void setId(int id) {
            this.id = id;
        }
        public string getNomeTeste() {
            return this.nomeTeste;
        }
        public void setNomeTeste(string nomeTeste) {
            this.nomeTeste = nomeTeste;
        }
    }
}