
using FinTrack.Models;
using FinTrack.Controllers;
using FinTrack.Repository;

namespace FinTrack.Ui.Menu;

public static class Menu
{
    public static void ExibirMenu()
    {
        var carteira = new Carteira("Carteira Principal", 0m, new List<Transacao>());
        var usuario = new Usuario
        {
            id = Guid.NewGuid(),
            Nome = "Usuário",
            Carteira = carteira,
            MetaMensal = 0
        };

        var controller = new CarteiraController(carteira, usuario);
        var repo = new CarteiraRepository();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("== FinTrack ==");
            Console.WriteLine("1 - Adicionar Receita");
            Console.WriteLine("2 - Adicionar Despesa");
            Console.WriteLine("3 - Listar Transações");
            Console.WriteLine("4 - Mostrar Saldo");
            Console.WriteLine("5 - Resumo Mensal");
            Console.WriteLine("6 - Definir Meta Mensal");
            Console.WriteLine("7 - Verificar Meta");
            Console.WriteLine("8 - Salvar Carteira");
            Console.WriteLine("9 - Carregar Carteira");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            var opc = Console.ReadLine();
            Console.WriteLine();

            switch (opc)
            {
                case "1":
                    Console.Write("Descrição da receita: ");
                    var descR = Console.ReadLine() ?? string.Empty;
                    var valorR = LerDecimal("Valor da receita: ");
                    controller.AdicionarReceita(descR, valorR);
                    carteira.Saldo = carteira.CalcularSaldo();
                    Console.WriteLine("Receita adicionada.");
                    Pausa();
                    break;

                case "2":
                    Console.Write("Descrição da despesa: ");
                    var descD = Console.ReadLine() ?? string.Empty;
                    var valorD = LerDecimal("Valor da despesa: ");
                    var tipo = LerInt("Tipo de pagamento (ex: 1 = à vista, 2 = parcelado): ");
                    var parcelas = LerInt("Número de parcelas: ");
                    controller.AdicionarDespesa(descD, valorD, tipo, parcelas);
                    carteira.Saldo = carteira.CalcularSaldo();
                    Console.WriteLine("Despesa adicionada.");
                    Pausa();
                    break;

                case "3":
                    Console.WriteLine("Transações:");
                    controller.ListarTransacoes();
                    Pausa();
                    break;

                case "4":
                    Console.WriteLine($"Saldo atual: {controller.CalcularSaldo():C}");
                    Pausa();
                    break;

                case "5":
                    var mes = LerInt("Mês (1-12): ");
                    var ano = LerInt("Ano (ex: 2025): ");
                    controller.ResumoMensal(mes, ano);
                    Pausa();
                    break;

                case "6":
                    var meta = LerDouble("Defina sua meta mensal: ");
                    controller.DefinirMetaMensal(meta);
                    Console.WriteLine("Meta definida.");
                    Pausa();
                    break;

                case "7":
                    controller.VerificarMeta();
                    Pausa();
                    break;

                case "8":
                    try
                    {
                        repo.SalvarCarteira(carteira);
                        Console.WriteLine("Carteira salva em arquivo.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao salvar: {ex.Message}");
                    }
                    Pausa();
                    break;

                case "9":
                    try
                    {
                        repo.CarregarCarteira(carteira);
                        // carteira já atualizado por referência; recalcula saldo
                        carteira.Saldo = carteira.CalcularSaldo();
                        Console.WriteLine("Carteira carregada do arquivo.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao carregar: {ex.Message}");
                    }
                    Pausa();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    Pausa();
                    break;
            }
        }
    }

    private static decimal LerDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (decimal.TryParse(s, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out var v))
                return v;
            Console.WriteLine("Valor inválido, tente novamente.");
        }
    }

    private static int LerInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (int.TryParse(s, out var v))
                return v;
            Console.WriteLine("Valor inválido, tente novamente.");
        }
    }

    private static double LerDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (double.TryParse(s, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out var v))
                return v;
            Console.WriteLine("Valor inválido, tente novamente.");
        }
    }

    private static void Pausa()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey(true);
    }
}
