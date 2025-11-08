namespace FinTrack.Models;

public class Carteira
{
    public string Nome { get; set; }
    public decimal Saldo { get; set; }
    public List<Transacao> Transacoes { get; set; }

    public Carteira(string nome, decimal saldo, List<Transacao> transacoes)
    {
        Nome = nome;
        Saldo = saldo;
        Transacoes = transacoes;
    }

    public void AdicionarTransacao(Transacao transacao)
    {
        Transacoes.Add(transacao);
    }

    public void ExibirTransacoes()
    {
        foreach (var transacao in Transacoes)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Descrição: {transacao.Descricao}" +
                $"Data criação: {transacao.Data}");
        }
    }

    public decimal CalcularSaldo()
    {
        var TotalReceitas = Transacoes
            .Where(t => t is Receita)
            .Sum(t => t.Valor);

        var TotalDespesas = Transacoes
            .Where(t => t is Despesa)
            .Sum(t => t.Valor);

        return TotalReceitas - TotalDespesas;
    }

    public void ExibirResumoMensal(int mes, int ano)
    {
        var receitasDoMes = Transacoes
            .Where(t => t is Receita && t.Data.Month == mes && t.Data.Year == ano)
            .Sum(t => t.Valor);
        var despesasDoMes = Transacoes
            .Where(t => t is Despesa && t.Data.Month == mes && t.Data.Year == ano)
            .Sum(t => t.Valor);
        Console.WriteLine($"Resumo do Mês {mes}/{ano}:");
        Console.WriteLine($"Total de Receitas: {receitasDoMes:C}");
        Console.WriteLine($"Total de Despesas: {despesasDoMes:C}");
        Console.WriteLine($"Saldo Líquido: {(receitasDoMes - despesasDoMes):C}");
    }
}
    
