
using System.Security.Cryptography.X509Certificates;

namespace FinTrack.Models;

public class Receita : Transacao
{
    public string Origem { get; protected set; }

    public override decimal CalcularValorLiquido()
    {
        return Valor;
    }
}
