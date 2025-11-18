using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class CtrlEstados
    {
        // 2. Os mesmos "donos" do CtrlPaises
        ColEstados aColEstados;
        DaoEstados aDaoEstados;

        // 3. CONSTRUTOR (lógica idêntica ao CtrlPaises)
        public CtrlEstados()
        {
            // Instancia os dois
            this.aColEstados = new ColEstados();
            this.aDaoEstados = new DaoEstados();

            // CARREGA O CACHE!
            // Pega tudo do banco de dados (DAO)
            List<Estados> listaDoBanco = aDaoEstados.Listar();

            // Joga na coleção em memória (Coleção)
            foreach (Estados e in listaDoBanco)
            {
                aColEstados.Inserir(e);
            }
        }

        // --- MÉTODOS DE LEITURA (Usam o Cache Rápido) ---

        public List<Estados> Listar()
        {
            // Usa o método 'RetornaLista' da sua coleção
            return aColEstados.RetornaLista();
        }

        public Estados Carregar(int id)
        {
            // Usa a coleção em memória para isso, é mais rápido!
            return aColEstados.RetornaLista().FirstOrDefault(e => e.Codigo == id);
        }

        // --- MÉTODOS DE ESCRITA (Usam OS DOIS) ---

        public string Salvar(Estados oEstado)
        {
            // 1. Salva no banco (garante que é permanente)
            string idSalvo = aDaoEstados.Salvar(oEstado);

            // 2. Atualiza o objeto com o ID (caso seja um INSERT)
            oEstado.Codigo = Convert.ToInt32(idSalvo);

            // 3. Atualiza o cache na memória
            int index = -1;
            List<Estados> lista = aColEstados.RetornaLista();

            for (int i = 0; i < lista.Count; i++)
            {
                // Procura o item pelo Código
                if (lista[i].Codigo == oEstado.Codigo)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                // Se achou (index é 0 ou maior), usa o seu método 'Atualizar'
                aColEstados.Atualizar(index, oEstado);
            }
            else
            {
                // Se não achou (era -1), usa o seu método 'Inserir'
                aColEstados.Inserir(oEstado);
            }

            return idSalvo; // Retorna o ID
        }

        public string Excluir(Estados oEstado)
        {
            // 1. Exclui do banco (permanente)
            aDaoEstados.Excluir(oEstado);

            // 2. Exclui do cache na memória
            // O seu método 'Remove(T item)' espera o objeto exato.
            // Vamos procurá-lo na lista primeiro.
            Estados itemParaRemover = null;
            foreach (Estados e in aColEstados.RetornaLista())
            {
                if (e.Codigo == oEstado.Codigo)
                {
                    itemParaRemover = e; // Achamos o objeto que está na lista
                    break;
                }
            }

            if (itemParaRemover != null)
            {
                // Agora sim podemos chamar o seu método 'Remove'
                aColEstados.Remove(itemParaRemover);
            }

            return oEstado.Codigo.ToString();
        }

        // Adicione aqui outros métodos de busca específicos do ColEstados
        // Ex: public Estados BuscarPorUF(string uf) { ... }
    }
}
