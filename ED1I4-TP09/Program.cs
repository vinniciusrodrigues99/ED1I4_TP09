using Atividade09;

class Program
{
    static void Main()
    {
        Fretamento fretamento = new Fretamento();
        int opcao = 0;

        do
        {
            Console.WriteLine("0. Finalizar\r\n1. Cadastrar veículo\r\n2. Cadastrar garagem\r\n3. Iniciar jornada\r\n4. Encerrar jornada\r\n5. Liberar viagem de uma determinada origem para um determinado destino\r\n6. Listar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)\r\n7. Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino\r\n8. Listar viagens efetuadas de uma determinada origem para um determinado destino\r\n9. Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino ");
            
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch
            {
                opcao = 999;
            }

            switch (opcao)
            {
                case 0:
                    break;
                case 1:
                    CadastrarVeiculo(fretamento);
                    break;
                case 2:
                    CadastrarGaragem(fretamento);
                    break;
                case 3:
                    IniciarJornada(fretamento);
                    break;
                case 4:
                    EncerrarJornada(fretamento);
                    break;
                case 5:
                    LiberarViagem(fretamento);
                    break;
                case 6:
                    ListarVeiculosGaragem(fretamento);
                    break;
                case 7:
                    InformarQuantidadeViagens(fretamento);
                    break;
                case 8:
                    ListarViagensEspecifica(fretamento);
                    break;
                case 9:
                    InformarQuantidadePassageiros(fretamento);
                    break;
                default:
                    Console.WriteLine("Opção indesejada. Redigite.");
                    apagaTela();
                    break;
            }
        } while (opcao != 0);
    }

    // Define other methods and classes here

    static void CadastrarVeiculo(Fretamento fretamento)
    {
        if (!fretamento.Jornada)
        {
            int lotacao;
            Console.WriteLine("Qual a lotação do veículo?");
            lotacao = int.Parse(Console.ReadLine());

            Veiculo veiculo = new Veiculo(id_veiculo, lotacao);
            fretamento.Garagem.ListaVeiculo.Add(veiculo);

            Console.WriteLine("Veículo cadastrado!");
            id_veiculo++;
        }
        else
        {
            Console.WriteLine("A jornada deve estar encerrada para adicionar veículos");
        }

        apagaTela();
    }

    static void CadastrarGaragem(Fretamento fretamento)
    {
        if (!fretamento.Jornada)
        {
            string nome;
            Console.WriteLine("Qual o nome do aeroporto?");
            nome = Console.ReadLine();

            Aeroporto aeroporto = new Aeroporto(id_aeroporto, nome);
            fretamento.Aeroportos.Add(aeroporto);
            id_aeroporto++;
            Console.WriteLine("Aeroporto cadastrado!");
        }
        else
        {
            Console.WriteLine("A jornada deve estar encerrada para adicionar garagens");
        }

        apagaTela();
    }

    static void IniciarJornada(Fretamento fretamento)
    {
        if (!fretamento.Jornada)
        {
            fretamento.IniciaJornada();
            Console.WriteLine("A jornada foi iniciada");
        }
        else
        {
            Console.WriteLine("A jornada já está iniciada");
        }

        apagaTela();
    }

    static void EncerrarJornada(Fretamento fretamento)
    {
        if (fretamento.Jornada)
        {
            Console.WriteLine(fretamento.EncerraJornada());
            Console.WriteLine("-------------------------");
            Console.WriteLine("A jornada foi encerrada");
            Console.WriteLine("-------------------------");
        }
        else
        {
            Console.WriteLine("A jornada já está encerrada");
        }

        apagaTela();
    }

    static void LiberarViagem(Fretamento fretamento)
    {
        int aeroportoOrigem, aeroportoDestino;

        Console.WriteLine("Qual o ID do aeroporto de origem?");
        aeroportoOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual o ID do aeroporto de destino?");
        aeroportoDestino = int.Parse(Console.ReadLine());

        if (aeroportoOrigem == aeroportoDestino)
        {
            Console.WriteLine("É necessário inserir um aeroporto diferente para se locomover");
        }
        else
        {
            if (fretamento.ProcuraAeroporto(aeroportoOrigem).Id != -1 && fretamento.ProcuraAeroporto(aeroportoDestino).Id != -1)
            {
                Aeroporto origem = fretamento.ProcuraAeroporto(aeroportoOrigem);
                Aeroporto destino = fretamento.ProcuraAeroporto(aeroportoDestino);

                if (fretamento.PermiteViagem(origem))
                {
                    Viagem viagem = new Viagem(origem, destino, origem.PilhaVeiculos.Peek());
                    destino.PilhaVeiculos.Push(origem.PilhaVeiculos.Pop());

                    fretamento.Viagens.Add(viagem);

                    Console.WriteLine("Viagem realizada!");
                }
                else
                {
                    Console.WriteLine("Sem carros disponíveis no aeroporto escolhido");
                }
            }
            else
            {
                Console.WriteLine("IDs utilizadas inválidas!");
            }
        }

        apagaTela();
    }

    static void ListarVeiculosGaragem(Fretamento fretamento)
    {
        int id;
        Console.WriteLine("Informe o ID da garagem desejada");
        id = int.Parse(Console.ReadLine());

        if (fretamento.ProcuraAeroporto(id).Id != -1)
        {
            Console.WriteLine(fretamento.ProcuraAeroporto(id).MostraGaragem());
        }
        else
        {
            Console.WriteLine("Garagem com Id inexistente");
        }

        apagaTela();
    }

    static void InformarQuantidadeViagens(Fretamento fretamento)
    {
        int aeroportoOrigem, aeroportoDestino;

        Console.WriteLine("Qual o ID do aeroporto de origem?");
        aeroportoOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual o ID do aeroporto de destino?");
        aeroportoDestino = int.Parse(Console.ReadLine());

        if (aeroportoOrigem == aeroportoDestino)
        {
            Console.WriteLine("É necessário inserir um aeroporto diferente para verificar as viagens");
        }
        else
        {
            if (fretamento.ProcuraAeroporto(aeroportoOrigem).Id != -1 && fretamento.ProcuraAeroporto(aeroportoDestino).Id != -1)
            {
                Aeroporto origem = fretamento.ProcuraAeroporto(aeroportoOrigem);
                Aeroporto destino = fretamento.ProcuraAeroporto(aeroportoDestino);

                Console.WriteLine(fretamento.QtdViagemEspecifica(origem, destino));
            }
            else
            {
                Console.WriteLine("IDs utilizadas inválidas!");
            }
        }

        apagaTela();
    }

    static void ListarViagensEspecifica(Fretamento fretamento)
    {
        int aeroportoOrigem, aeroportoDestino;

        Console.WriteLine("Qual o ID do aeroporto de origem?");
        aeroportoOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual o ID do aeroporto de destino?");
        aeroportoDestino = int.Parse(Console.ReadLine());

        if (aeroportoOrigem == aeroportoDestino)
        {
            Console.WriteLine("É necessário inserir um aeroporto diferente para verificar as viagens");
        }
        else
        {
            if (fretamento.ProcuraAeroporto(aeroportoOrigem).Id != -1 && fretamento.ProcuraAeroporto(aeroportoDestino).Id != -1)
            {
                Aeroporto origem = fretamento.ProcuraAeroporto(aeroportoOrigem);
                Aeroporto destino = fretamento.ProcuraAeroporto(aeroportoDestino);

                Console.WriteLine(fretamento.ListaViagemEspecifica(origem, destino));
            }
            else
            {
                Console.WriteLine("IDs utilizadas inválidas!");
            }
        }

        apagaTela();
    }

    static void InformarQuantidadePassageiros(Fretamento fretamento)
    {
        int aeroportoOrigem, aeroportoDestino;

        Console.WriteLine("Qual o ID do aeroporto de origem?");
        aeroportoOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual o ID do aeroporto de destino?");
        aeroportoDestino = int.Parse(Console.ReadLine());

        if (aeroportoOrigem == aeroportoDestino)
        {
            Console.WriteLine("É necessário inserir um aeroporto diferente para verificar as viagens");
        }
        else
        {
            if (fretamento.ProcuraAeroporto(aeroportoOrigem).Id != -1 && fretamento.ProcuraAeroporto(aeroportoDestino).Id != -1)
            {
                Aeroporto origem = fretamento.ProcuraAeroporto(aeroportoOrigem);
                Aeroporto destino = fretamento.ProcuraAeroporto(aeroportoDestino);

                Console.WriteLine(fretamento.QtdPassageirosViagemEspecifica(origem, destino));
            }
            else
            {
                Console.WriteLine("IDs utilizadas inválidas!");
            }
        }

        apagaTela();
    }

    static void apagaTela()
    {
        Console.WriteLine("Aperte qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}