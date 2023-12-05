using System.Collections.Generic;
using System.Linq;

namespace Atividade09
{
    internal class Fretamento
    {
        public List<Viagem> Viagens { get; set; }
        public List<Aeroporto> Aeroportos { get; set; }
        public Garagem Garagem { get; set; }
        public bool Jornada { get; set; }

        public Fretamento()
        {
            Viagens = new List<Viagem>();
            Aeroportos = new List<Aeroporto>();
            Garagem = new Garagem();
        }

        public void IniciaJornada()
        {
            int counter = 0;

            foreach (Veiculo v in Garagem.ListaVeiculo)
            {
                if (counter < Aeroportos.Count)
                {
                    Aeroportos[counter].PilhaVeiculos.Push(v);
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }

            Jornada = true;
        }

        public string EncerraJornada()
        {
            string retorno = "";

            foreach (Veiculo v in Garagem.ListaVeiculo)
            {
                retorno += $"Carro: {v.Id}\nQuantidade de passageiros transportados: {v.QtdLotacao * v.QtdViagem}\n\n";
                v.QtdViagem = 0;
            }

            Jornada = false;
            return retorno;
        }

        public bool PermiteViagem(Aeroporto aeroportoSaida)
        {
            return Jornada && aeroportoSaida.PilhaVeiculos.Count > 0;
        }

        public Aeroporto ProcuraAeroporto(int id)
        {
            return Aeroportos.FirstOrDefault(aeroporto => aeroporto.Id == id) ?? new Aeroporto();
        }

        public string QtdViagemEspecifica(Aeroporto a1, Aeroporto a2)
        {
            int counter = Viagens.Count(v => v.AeroportoSaida == a1 && v.AeroportoChegada == a2);
            return $"A quantidade de viagens de {a1.Nome} para {a2.Nome} é de: {counter}";
        }

        public string ListaViagemEspecifica(Aeroporto a1, Aeroporto a2)
        {
            string retorno = $"Viagens de {a1.Nome} para {a2.Nome}:\n";
            int counter = 1;

            foreach (Viagem v in Viagens.Where(v => v.AeroportoSaida == a1 && v.AeroportoChegada == a2))
            {
                retorno += $"{counter}ª viagem - carro {v.Veiculo.Id}\n";
                counter++;
            }

            return retorno;
        }

        public string QtdPassageirosViagemEspecifica(Aeroporto a1, Aeroporto a2)
        {
            int counter = Viagens.Where(v => v.AeroportoSaida == a1 && v.AeroportoChegada == a2)
                                 .Sum(v => v.Veiculo.QtdLotacao);

            return $"A quantidade de pessoas transportadas de {a1.Nome} para {a2.Nome} é de: {counter}";
        }
    }
}
