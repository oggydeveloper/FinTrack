using FinTrack.Models;

namespace FinTrack.Controllers;
public class CarteiraController
{
    private readonly Carteira _carteira;
    private readonly Usuario _usuario;

    public CarteiraController(Carteira carteira, Usuario usuario)
    {
        _carteira = carteira;
        _usuario = usuario;
    }

    public void AdicionarReceita(string descricao, decimal valor)
    {
        var receita = new Receita
        {
            Descricao = descricao,
            Valor = valor,
            Data = DateTime.Now
        };
        _carteira.AdicionarTransacao(receita);
        _carteira.Saldo = _carteira.CalcularSaldo();
    }

    public void AdicionarDespesa(string descricao, decimal valor, int tipoPagamento, int parcelas)
    {
        var despesa = new Despesa
        {
            Descricao = descricao,
            Valor = valor,
            Data = DateTime.Now,
            TipoPagamento = tipoPagamento,
            Parcelas = parcelas
        };
        _carteira.AdicionarTransacao(despesa);
        _carteira.Saldo = _carteira.CalcularSaldo();
    }

    public void ListarTransacoes()
    {
        _carteira.ExibirTransacoes();
    }

    public decimal CalcularSaldo()
    {
        return _carteira.CalcularSaldo();
    }

    public void ResumoMensal(int mes, int ano)
    {
        _carteira.ExibirResumoMensal(mes, ano);
    }

    public void DefinirMetaMensal(double meta)
    {
        _usuario.DefinirMetaMensal(meta);
    }

    public void VerificarMeta()
    {
        _usuario.VerificarMeta();
    }
}
