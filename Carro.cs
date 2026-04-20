namespace MediaPorLitro;

public class Carro : Veiculo
{
    public Carro(string modelo, double capacidade, double consumo)
        : base(modelo, TipoVeiculo.Carro, capacidade, consumo) { }

    public override double PercentualAcrescimo() => 0.05;

    public override double CalcularAutonomia()
    {
        return base.CalcularAutonomia() * (1 + PercentualAcrescimo());
    }
}
