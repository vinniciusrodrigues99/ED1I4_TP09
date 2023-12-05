using System;

namespace Atividade09
{
    internal class Viagem
    {
        public Aeroporto AeroportoSaida { get; set; }
        public Aeroporto AeroportoChegada { get; set; }
        public Veiculo Veiculo { get; set; }

        public Viagem(Aeroporto aeroportoSaida, Aeroporto aeroportoChegada, Veiculo veiculo)
        {
            AeroportoSaida = aeroportoSaida;
            AeroportoChegada = aeroportoChegada;
            Veiculo = veiculo;

            veiculo.QtdViagem++;
        }
    }
}