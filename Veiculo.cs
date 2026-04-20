namespace MediaPorLitro;

public class Veiculo
{
    public string Modelo { get; set; }
    public TipoVeiculo Tipo { get; set; }
    public double CapacidadeTanque { get; set; }
    public double ConsumoMedio { get; set; }

    public Veiculo(string modelo, TipoVeiculo tipo, double capacidade, double consumo)
    {
        Modelo = modelo;
        Tipo = tipo;
        CapacidadeTanque = capacidade;
        ConsumoMedio = consumo;
    }

    public virtual double CalcularAutonomia()
    {
        return CapacidadeTanque * ConsumoMedio;
    }

    public virtual double PercentualAcrescimo() => 0.0;

    public virtual void ExibirDados()
    {
        double autonomiaBase = CapacidadeTanque * ConsumoMedio;
        double autonomiaFinal = CalcularAutonomia();
        double acrescimo = PercentualAcrescimo();

        Console.WriteLine($"\n  +----------------------------------+");
        Console.WriteLine($"  | {Tipo.ToString().ToUpper(),-32} |");
        Console.WriteLine($"  +----------------------------------+");
        Console.WriteLine($"  Modelo   : {Modelo}");
        Console.WriteLine($"  Tanque   : {CapacidadeTanque:F2} L");
        Console.WriteLine($"  Consumo  : {ConsumoMedio:F2} Km/L");
        Console.WriteLine($"  Base     : {autonomiaBase:F2} Km");

        if (acrescimo > 0)
            Console.WriteLine($"  Acrescimo: +{acrescimo:P0} por eficiencia do tipo");

        Console.WriteLine($"  AUTONOMIA: {autonomiaFinal:F2} Km");
    }
}
