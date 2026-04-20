namespace MediaPorLitro;

public class Caminhao : Veiculo
{
    public double CarroCarga { get; set; }

    public Caminhao(string modelo, double capacidade, double consumo, double cargaToneladas)
        : base(modelo, TipoVeiculo.Caminhao, capacidade, consumo)
    {
        CarroCarga = cargaToneladas;
    }

    public override double PercentualAcrescimo() => -0.10;

    public override double CalcularAutonomia()
    {
        double reducaoPorCarga = CarroCarga * 0.01;
        double fatorFinal = 1 + PercentualAcrescimo() - reducaoPorCarga;
        fatorFinal = Math.Max(fatorFinal, 0.5);
        return base.CalcularAutonomia() * fatorFinal;
    }

    public override void ExibirDados()
    {
        double autonomiaBase = CapacidadeTanque * ConsumoMedio;
        double autonomiaFinal = CalcularAutonomia();

        Console.WriteLine($"\n  +----------------------------------+");
        Console.WriteLine($"  | CAMINHAO                         |");
        Console.WriteLine($"  +----------------------------------+");
        Console.WriteLine($"  Modelo   : {Modelo}");
        Console.WriteLine($"  Tanque   : {CapacidadeTanque:F2} L");
        Console.WriteLine($"  Consumo  : {ConsumoMedio:F2} Km/L");
        Console.WriteLine($"  Carga    : {CarroCarga:F1} toneladas");
        Console.WriteLine($"  Base     : {autonomiaBase:F2} Km");
        Console.WriteLine($"  Reducao  : carga pesada reduz autonomia");
        Console.WriteLine($"  AUTONOMIA: {autonomiaFinal:F2} Km");
    }
}
