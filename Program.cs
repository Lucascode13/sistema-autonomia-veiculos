using System.Globalization;
using MediaPorLitro;

class Program
{
    static List<Veiculo> veiculos = new();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ExibirTitulo();

        bool rodando = true;
        while (rodando)
        {
            ExibirMenu();
            string opcao = Console.ReadLine() ?? "";

            switch (opcao.Trim())
            {
                case "1": CadastrarVeiculo(); break;
                case "2": ListarTodos(); break;
                case "3": ExibirEstatisticas(); break;
                case "4": CompararVeiculos(); break;
                case "0": rodando = false; break;
                default:
                    Console.WriteLine("\n  Opcao invalida. Tente novamente.");
                    break;
            }
        }

        Console.WriteLine("\n  Encerrando o sistema. Ate logo!\n");
    }

    static void ExibirTitulo()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  ================================================");
        Console.WriteLine("     SISTEMA DE AUTONOMIA DE VEICULOS - C# .NET 8 ");
        Console.WriteLine("  ================================================");
        Console.WriteLine("  Conceitos: Heranca | Polimorfismo | Enum | LINQ  ");
        Console.WriteLine("  ================================================");
        Console.WriteLine();
    }

    static void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("  -------- MENU PRINCIPAL --------");
        Console.WriteLine($"  Veiculos cadastrados: {veiculos.Count}");
        Console.WriteLine("  [1] Cadastrar veiculo");
        Console.WriteLine("  [2] Listar todos");
        Console.WriteLine("  [3] Estatisticas gerais");
        Console.WriteLine("  [4] Comparar dois veiculos");
        Console.WriteLine("  [0] Sair");
        Console.Write("\n  Escolha: ");
    }

    static void CadastrarVeiculo()
    {
        Console.WriteLine("\n  ===== CADASTRO DE VEICULO =====");
        Console.WriteLine("  Tipos disponiveis:");
        Console.WriteLine("  [1] Carro  (+5% eficiencia)");
        Console.WriteLine("  [2] Moto   (+12% eficiencia)");
        Console.WriteLine("  [3] Caminhao (-10% + reducao por carga)");
        Console.Write("\n  Tipo: ");

        string tipoOpcao = Console.ReadLine() ?? "";

        Console.Write("  Modelo: ");
        string modelo = Console.ReadLine() ?? "Sem modelo";

        double capacidade = LerDouble("  Capacidade do tanque (L): ");
        double consumo = LerDouble("  Consumo medio (Km/L): ");

        switch (tipoOpcao.Trim())
        {
            case "1":
                veiculos.Add(new Carro(modelo, capacidade, consumo));
                Console.WriteLine($"\n  Carro '{modelo}' cadastrado com sucesso!");
                break;
            case "2":
                veiculos.Add(new Moto(modelo, capacidade, consumo));
                Console.WriteLine($"\n  Moto '{modelo}' cadastrada com sucesso!");
                break;
            case "3":
                double carga = LerDouble("  Carga transportada (toneladas): ");
                veiculos.Add(new Caminhao(modelo, capacidade, consumo, carga));
                Console.WriteLine($"\n  Caminhao '{modelo}' cadastrado com sucesso!");
                break;
            default:
                Console.WriteLine("\n  Tipo invalido. Veiculo nao cadastrado.");
                break;
        }
    }

    static void ListarTodos()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("\n  Nenhum veiculo cadastrado ainda.");
            return;
        }

        Console.WriteLine("\n  ===== LISTA DE VEICULOS =====");
        foreach (var v in veiculos)
            v.ExibirDados();

        Console.WriteLine("\n  =============================");
    }

    static void ExibirEstatisticas()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("\n  Nenhum veiculo cadastrado ainda.");
            return;
        }

        Console.WriteLine("\n  ===== ESTATISTICAS =====");

        double maiorAutonomia = veiculos.Max(v => v.CalcularAutonomia());
        double menorAutonomia = veiculos.Min(v => v.CalcularAutonomia());
        double mediaAutonomia = veiculos.Average(v => v.CalcularAutonomia());

        var maisEficiente = veiculos.OrderByDescending(v => v.CalcularAutonomia()).First();
        var menosEficiente = veiculos.OrderBy(v => v.CalcularAutonomia()).First();

        int carros   = veiculos.Count(v => v.Tipo == TipoVeiculo.Carro);
        int motos    = veiculos.Count(v => v.Tipo == TipoVeiculo.Moto);
        int caminhoes = veiculos.Count(v => v.Tipo == TipoVeiculo.Caminhao);

        Console.WriteLine($"\n  Total de veiculos : {veiculos.Count}");
        Console.WriteLine($"  Carros            : {carros}");
        Console.WriteLine($"  Motos             : {motos}");
        Console.WriteLine($"  Caminhoes         : {caminhoes}");
        Console.WriteLine($"\n  Maior autonomia   : {maiorAutonomia:F2} Km  ({maisEficiente.Modelo})");
        Console.WriteLine($"  Menor autonomia   : {menorAutonomia:F2} Km  ({menosEficiente.Modelo})");
        Console.WriteLine($"  Media geral       : {mediaAutonomia:F2} Km");
        Console.WriteLine("\n  ========================");
    }

    static void CompararVeiculos()
    {
        if (veiculos.Count < 2)
        {
            Console.WriteLine("\n  Cadastre pelo menos 2 veiculos para comparar.");
            return;
        }

        Console.WriteLine("\n  ===== COMPARAR VEICULOS =====");
        for (int i = 0; i < veiculos.Count; i++)
            Console.WriteLine($"  [{i + 1}] {veiculos[i].Tipo} - {veiculos[i].Modelo}  ({veiculos[i].CalcularAutonomia():F2} Km)");

        Console.Write("\n  Primeiro veiculo: ");
        if (!int.TryParse(Console.ReadLine(), out int idx1) || idx1 < 1 || idx1 > veiculos.Count) { Console.WriteLine("  Invalido."); return; }

        Console.Write("  Segundo veiculo : ");
        if (!int.TryParse(Console.ReadLine(), out int idx2) || idx2 < 1 || idx2 > veiculos.Count) { Console.WriteLine("  Invalido."); return; }

        var v1 = veiculos[idx1 - 1];
        var v2 = veiculos[idx2 - 1];

        double aut1 = v1.CalcularAutonomia();
        double aut2 = v2.CalcularAutonomia();
        double diff = Math.Abs(aut1 - aut2);
        var vencedor = aut1 >= aut2 ? v1 : v2;

        Console.WriteLine($"\n  {v1.Tipo} {v1.Modelo,-15} → {aut1:F2} Km");
        Console.WriteLine($"  {v2.Tipo} {v2.Modelo,-15} → {aut2:F2} Km");
        Console.WriteLine($"\n  Diferenca: {diff:F2} Km");
        Console.WriteLine($"  Vencedor : {vencedor.Modelo} ({vencedor.Tipo})");
        Console.WriteLine("  =============================");
    }

    static double LerDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string entrada = Console.ReadLine() ?? "";
            if (double.TryParse(entrada, CultureInfo.InvariantCulture, out double valor) && valor > 0)
                return valor;
            Console.WriteLine("  Valor invalido. Digite um numero positivo.");
        }
    }
}
