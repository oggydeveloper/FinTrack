namespace FinTrack.Models;

public class Categoria
{
    public string Nome { get; set; }
    public string Tipo { get; set; }

    public void ExibirCategoria()
    {
        Console.WriteLine($"Categoria: {Nome}\nTipo: {Tipo}");
        
    }
}
