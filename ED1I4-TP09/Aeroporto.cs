using System;
using System.Collections.Generic;
using System.Linq;

namespace Atividade09
{
    internal class Aeroporto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        internal Stack<Veiculo> PilhaVeiculos { get; set; }

        public Aeroporto(int id, string nome)
        {
            Id = id;
            Nome = nome;
            PilhaVeiculos = new Stack<Veiculo>();
        }

        public Aeroporto()
        {
            Id = -1;
        }

        public string MostraGaragem()
        {
            int lotacao = PilhaVeiculos.Sum(v => v.QtdLotacao);
            return $"Quantidade de veículos: {PilhaVeiculos.Count}\nPotencial de transporte: {lotacao}";
        }
    }
}
