using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Models
{
    public abstract class Transacao
    {
        public int Id { get; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Categoria Categoria { get; set; }
        public virtual decimal CalcularValorLiquido()
        {
            return Valor;
        }

        public virtual void ExibirDetalhes()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Valor: {Valor:C}");
            Console.WriteLine($"Data: {Data:d}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Valor Líquido: {CalcularValorLiquido():C}");
        }
    }
}
