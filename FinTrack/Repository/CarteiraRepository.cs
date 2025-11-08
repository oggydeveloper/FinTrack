

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
    }
}
