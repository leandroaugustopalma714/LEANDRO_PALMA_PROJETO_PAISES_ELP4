using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class CtrlCidades : Controller<Cidades>
    {
        ColCidades aColCidades;
        DaoCidades aDaoCidades;
        public CtrlCidades()
        {
            aColCidades = new ColCidades();
            aDaoCidades = new DaoCidades();
        }
        public override string Salvar(object obj)
        {
            //base.Salvar(obj);
            return aDaoCidades.Salvar(obj);
        }
        public override List<Cidades> Listar()
        {
            return aDaoCidades.Listar();
        }
    }
}
