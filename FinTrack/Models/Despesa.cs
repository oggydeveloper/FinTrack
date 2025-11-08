namespace FinTrack.Models;

public class Despesa : Transacao
{
    public int TipoPagamento { get; set; }
    public int Parcelas { get; set; }
    public override decimal CalcularValorLiquido()
    {
        return Valor;
    }
}
