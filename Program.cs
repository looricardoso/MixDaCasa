using System;
using MixDaCasa.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MixDaCasa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Burguers que contém o ingrediente --Burguer Mix da Casa--");
            string ingId = "c533fe1d-5177-45af-b165-892d30ef7ea4";
            using (var db = new hamburgueriaContext())
            {
                var burguerIng = db.BurguerIngrediente
                    .Include(lanche => lanche.Burguer);

                foreach (var b in burguerIng.Where(filtro => filtro.IngredienteId == ingId).OrderBy(o => o.Burguer.Preco))
                {
                    var nomeBurguer = b.Burguer.Nome;
                    var preco = b.Burguer.Preco;
                    Console.WriteLine($"Lanche: {nomeBurguer} - Preço: {preco}");
                    // Console.WriteLine(b.Nome);
                }
            }
        }
    }
}
