namespace FinTrack.Models;
public class Usuario
{
    public Guid id { get; init; }
    public string Nome { get; set; }
    public Carteira Carteira { get; set; }
    public double MetaMensal { get; set; }

    public void DefinirMetaMensal(double meta)
    {
        MetaMensal = meta;
    }

    public void ResumoGeral()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Meta Mensal: {MetaMensal:C}");
        Console.WriteLine("Carteira:");
        Console.WriteLine($"Nome: {Carteira.Nome}");
        Console.WriteLine($"Saldo: {Carteira.Saldo:C}");
    }
    public void VerificarMeta()
    {
        if (Carteira.Saldo >= (decimal)MetaMensal)
        {
            Console.WriteLine("Parabéns! Você atingiu sua meta mensal.");
        }
        else
        {
            Console.WriteLine("Você ainda não atingiu sua meta mensal. Continue se esforçando!");
        }
    }
}
