using FinTrack.Models;
using FinTrack.Repository;

namespace FinTrack.Controllers;
public class CarteiraController
{
    private readonly Carteira _carteira;
    private readonly Usuario _usuario;
    private readonly CarteiraRepository _carteiraRepository;

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

    public void RemoverTransacoes(Transacao t)
    {
        if (_carteira.Transacoes.Contains(t))
        {
            _carteira.RemoverTransacao(t);
            _carteira.Saldo = _carteira.CalcularSaldo();
        }
        else
        {
            Console.WriteLine("Transação não encontrada na carteira.");
        }
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

    public void SalvarCarteira()
    {
        _carteiraRepository.SalvarCarteira(_carteira);
    }
    public void CarregarCarteira()
    {
        _carteiraRepository.CarregarCarteira(_carteira);
    }
}
