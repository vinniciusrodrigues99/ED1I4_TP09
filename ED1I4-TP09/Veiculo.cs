using System;

namespace Atividade09
{
    internal class Veiculo
    {
        public int Id { get; set; }
        public int QtdLotacao { get; set; }
        public int QtdViagem { get; set; }

        public Veiculo(int id, int qtdLotacao)
        {
            Id = id;
            QtdLotacao = qtdLotacao;
            QtdViagem = 0;
        }
    }
}
