using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class ColEstados : Colecoes<Estados>
    {
        public Estados BuscarPorEstado(string estado)
        {
            foreach (var oestado in aLista)
            {
                if (oestado.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase))
                {
                    return oestado;
                }
            }
            return null;
        }
        public Estados BuscarPorUf(string uf)
        {
            foreach (var oestado in aLista)
            {
                if (oestado.UF.Equals(uf, StringComparison.OrdinalIgnoreCase))
                {
                    return oestado;
                }
            }
            return null;
        }
        public override void Imprimir()
        {
            foreach (var oEstado in aLista)
            {
                Console.WriteLine($"Estado: {oEstado.Estado}");
                Console.WriteLine($"UF: {oEstado.UF}");
                Console.WriteLine($"País: {oEstado.OPais.Pais}");
            }
        }
    }
}
