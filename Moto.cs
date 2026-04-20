namespace MediaPorLitro;

public class Moto : Veiculo
{
    public Moto(string modelo, double capacidade, double consumo)
        : base(modelo, TipoVeiculo.Moto, capacidade, consumo) { }

    public override double PercentualAcrescimo() => 0.12;

    public override double CalcularAutonomia()
    {
        return base.CalcularAutonomia() * (1 + PercentualAcrescimo());
    }
}
