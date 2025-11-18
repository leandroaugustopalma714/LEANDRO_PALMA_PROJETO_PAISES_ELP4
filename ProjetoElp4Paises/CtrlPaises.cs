using ProjetoELP4_Paisess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq; 
using System.Collections.Generic; 
namespace ProjetoElp4Paises
{
    internal class CtrlPaises
    {
        // 1. O Controlador "é dono" dos dois
        DaoPaises oDaoPaises;
        ColPaises oColPaises;

        // 2. CONSTRUTOR: Carrega o cache (Coleção)
        public CtrlPaises()
        {
            this.oDaoPaises = new DaoPaises();
            this.oColPaises = new ColPaises();

            // 3. CARREGA O CACHE!
            // Pega tudo do banco de dados (lento, mas só faz 1 vez)
            List<Paises> listaDoBanco = oDaoPaises.Listar();

            // Joga na coleção em memória usando o seu método 'Inserir'
            foreach (Paises p in listaDoBanco)
            {
                oColPaises.Inserir(p);
            }
        }

        // --- MÉTODOS DE LEITURA (Usam o Cache Rápido) ---

        public List<Paises> Listar()
        {
            // Usa o seu método 'RetornaLista'
            return oColPaises.RetornaLista();
        }

        // O seu FrmConsPaises precisa desse para preencher o 'oPais'
        public Paises Carregar(int id)
        {
            // Vamos usar a coleção em memória para isso, é mais rápido!
            // (Usando LINQ para achar o primeiro país que bate o ID)
            return oColPaises.RetornaLista().FirstOrDefault(p => p.Codigo == id);

            // Se der erro, use o DAO (que já sabemos que funciona):
            // return (Paises)oDaoPaises.CarregaObj(id);
        }

        // Você pode adicionar os outros métodos de busca aqui
        public Paises BuscarPorPais(string nome)
        {
            return oColPaises.BuscarPorPais(nome);
        }

        // --- MÉTODOS DE ESCRITA (Usam OS DOIS) ---

        public string Salvar(Paises oPais)
        {
            // 1. Salva no banco (garante que é permanente)
            string idSalvo = oDaoPaises.Salvar(oPais);

            // 2. Atualiza o objeto com o ID (caso seja um INSERT)
            oPais.Codigo = Convert.ToInt32(idSalvo);

            // 3. Atualiza o cache na memória
            // Precisamos ver se o item já existe na lista
            int index = -1;
            List<Paises> lista = oColPaises.RetornaLista();

            for (int i = 0; i < lista.Count; i++)
            {
                // Procura o item pelo Código
                if (lista[i].Codigo == oPais.Codigo)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                // Se achou (index é 0 ou maior), usa o seu método 'Atualizar'
                oColPaises.Atualizar(index, oPais);
            }
            else
            {
                // Se não achou (era -1), usa o seu método 'Inserir'
                oColPaises.Inserir(oPais);
            }

            return idSalvo; // Retorna o ID
        }

        public string Excluir(Paises oPais)
        {
            // 1. Exclui do banco (permanente)
            oDaoPaises.Excluir(oPais);

            // 2. Exclui do cache na memória
            // O seu método 'Remove(T item)' espera o objeto exato.
            // Vamos procurá-lo na lista primeiro.
            Paises itemParaRemover = null;
            foreach (Paises p in oColPaises.RetornaLista())
            {
                if (p.Codigo == oPais.Codigo)
                {
                    itemParaRemover = p; // Achamos o objeto que está na lista
                    break;
                }
            }

            if (itemParaRemover != null)
            {
                // Agora sim podemos chamar o seu método 'Remove'
                oColPaises.Remove(itemParaRemover);
            }

            return oPais.Codigo.ToString();
        }
    }
}
        
