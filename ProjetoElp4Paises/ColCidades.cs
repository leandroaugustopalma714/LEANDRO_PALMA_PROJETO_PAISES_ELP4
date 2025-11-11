using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class ColCidades : Colecoes<Cidades>
    {
        public Cidades BuscarPorCidade(string cidade)
        {
            foreach (var ocidade in aLista)
            {
                if (ocidade.Cidade.Equals(cidade, StringComparison.OrdinalIgnoreCase))
                {
                    return ocidade;
                }
            }
            return null;
        }
        public Cidades BuscarPorDdd(string ddd)
        {
            foreach (var ocidade in aLista)
            {
                if (ocidade.DDD.Equals(ddd, StringComparison.OrdinalIgnoreCase))
                {
                    return ocidade;
                }
            }
            return null;
        }
        public override void Imprimir()
        {
            foreach (var oCidade in aLista)
            {
                Console.WriteLine($"Cidade: {oCidade.Cidade}");
                Console.WriteLine($"DDD: {oCidade.DDD}");
                Console.WriteLine($"Estado: {oCidade.OEstado.Estado}");
            }
        }
    }
}
