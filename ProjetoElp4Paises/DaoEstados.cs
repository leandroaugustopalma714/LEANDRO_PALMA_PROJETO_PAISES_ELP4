using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElp4Paises
{
    internal class DaoEstados : DAO<Estados>
    {
        /*public DaoEstados()
        {

        }*/
        public override string Excluir(object obj)
        {
            return null;

        }
        public override string Salvar(object obj)
        {
            Estados oEstado = (Estados)obj;
            string mSql = "", mOk = "";

            if (oEstado.Codigo == 0)
            {
                // Query INSERT (atenção aos nomes das colunas, ex: id_pais)
                mSql = "insert into estados (Estado, UF, datCad, ultAlt, idpais) values (@estado, @uf, @datcad, @ultalt, @idPais)";
            }
            else
            {
                // Query UPDATE (atenção aos nomes das colunas, ex: id_pais e id)
                mSql = "update estados set estado = @estado, uf = @uf, datcad = @datcad, ultalt = @ultalt, id_pais = @idPais where id = @codigo";
            }

            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                cmd.Parameters.AddWithValue("@estado", oEstado.Estado);
                cmd.Parameters.AddWithValue("@uf", oEstado.UF);
                cmd.Parameters.AddWithValue("@datcad", oEstado.DatCad);
                cmd.Parameters.AddWithValue("@ultalt", oEstado.UltAlt);
                cmd.Parameters.AddWithValue("@idPais", oEstado.OPais.Codigo);

                // --- CORREÇÃO 1 ---
                // Adicionar o @codigo SOMENTE se for um UPDATE
                if (oEstado.Codigo != 0)
                {
                    cmd.Parameters.AddWithValue("@codigo", oEstado.Codigo);
                }

                cmd.ExecuteNonQuery();

                // --- CORREÇÃO 2 ---
                // Usar a lógica correta para retornar o ID
                if (oEstado.Codigo == 0) // Se era INSERT
                {
                    cmd.CommandText = "SELECT @@IDENTITY";
                    mOk = cmd.ExecuteScalar().ToString();
                }
                else // Se era UPDATE
                {
                    mOk = oEstado.Codigo.ToString(); // Retorna o ID que já existia
                }
            }
            return mOk;
        }
        public override List<Estados> Listar()
        {
            string mSql = "select * from estados order by id";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Estados> lista = new List<Estados>();

                while (reader.Read())
                {
                    Estados oEstado = new Estados();
                    oEstado.Codigo = Convert.ToInt32(reader["id"]);
                    oEstado.Estado = reader["estado"].ToString();
                    oEstado.UF = reader["uf"].ToString();

                    Paises oPais = new Paises();
                    oPais.Codigo = Convert.ToInt32(reader["idpais"]);
                    oEstado.OPais = oPais;

                    lista.Add(oEstado);
                }

                reader.Close();
                return lista;
            }
        }
    
    public override Object CarregaObj(int chave)
        {
            string mSql = "select * from estados where id = 'chave'";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                Estados estados = new Estados();

                while (reader.Read())
                {
                    //Estados oEstado = new Estados();
                    estados.Codigo = Convert.ToInt32(reader["id"]);
                    estados.Estado = reader["estado"].ToString();
                    estados.UF = reader["uf"].ToString();

                    Paises pais = new Paises();
                    pais.Codigo = Convert.ToInt32(reader["idpais"]);
                    estados.OPais = pais;

                    //lista.Add(oEstado);
                }

                reader.Close();
                return estados;
            }
        }

        public override List<Estados> Pesquisar(string chave)
        {
            return null;
        }
    }
}

