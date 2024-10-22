namespace ConsoleApp2
{
    internal class Program
    {
        static List<string> tarefas = new List<string>();

        static void Main(string[] args)
        {
            int opcao = 0;

            // Loop principal do programa
            while (opcao != 4)
            {
                Console.Clear(); // Limpa o console para uma nova exibição do menu

                // Exibir o menu
                Console.WriteLine("=== Gerenciador de Tarefas ===");
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Exibir Tarefas");
                Console.WriteLine("3. Remover Tarefa");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                // Ler a opção do usuário
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    // Executar a opção escolhida
                    switch (opcao)
                    {
                        case 1:
                            AdicionarTarefa();
                            break;
                        case 2:
                            ExibirTarefas();
                            break;
                        case 3:
                            RemoverTarefa();
                            break;
                        case 4:
                            Console.WriteLine("\nSaindo... Até mais!");
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida! Tente novamente.");
                            PausarConsole();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida! Digite um número.");
                    PausarConsole();
                }
            }
        }

        // Função para adicionar uma tarefa
        static void AdicionarTarefa()
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Tarefa ===");
            Console.Write("Digite a tarefa: ");
            string tarefa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(tarefa))
            {
                tarefas.Add(tarefa);
                Console.WriteLine("\nTarefa adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nA tarefa não pode estar em branco!");
            }
            PausarConsole();
        }

        // Função para exibir as tarefas
        static void ExibirTarefas()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Tarefas ===");

            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa para exibir.");
            }
            else
            {
                for (int i = 0; i < tarefas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tarefas[i]}");
                }
            }
            PausarConsole();
        }

        // Função para remover uma tarefa
        static void RemoverTarefa()
        {
            Console.Clear();
            ExibirTarefas();

            if (tarefas.Count > 0)
            {
                Console.Write("\nDigite o número da tarefa que deseja remover: ");
                if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tarefas.Count)
                {
                    tarefas.RemoveAt(indice - 1);
                    Console.WriteLine("\nTarefa removida com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nNúmero inválido!");
                }
            }
            PausarConsole();
        }

        // Função auxiliar para pausar o console e esperar uma tecla
        static void PausarConsole()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}