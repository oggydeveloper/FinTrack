using FinTrack.Models;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinTrack.Repository
{
    public class CarteiraRepository
    {
        private readonly string _caminhoArquivo = "carteira.json";

        public void SalvarCarteira(Carteira carteira)
        {
            var opcoes = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(carteira, opcoes);
            File.WriteAllText(_caminhoArquivo, json);
        }

        public void CarregarCarteira(Carteira carteira)
        {
            if (File.Exists(_caminhoArquivo))
            {
                var json = File.ReadAllText(_caminhoArquivo);
                var opcoes = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };
                var carteiraCarregada = JsonSerializer.Deserialize<Carteira>(json, opcoes);
                if (carteiraCarregada != null)
                {
                    carteira.Nome = carteiraCarregada.Nome;
                    carteira.Saldo = carteiraCarregada.Saldo;
                    carteira.Transacoes = carteiraCarregada.Transacoes;
                }
            }
            else
            {
                Console.WriteLine("Arquivo de carteira não encontrado.");
            }
        }
    }
}
