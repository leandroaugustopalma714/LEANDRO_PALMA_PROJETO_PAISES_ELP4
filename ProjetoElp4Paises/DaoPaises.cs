using ProjetoElp4Paises;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoELP4_Paisess
{
    internal class DaoPaises : DAO<Paises>
    {
        public override string Excluir(object obj)
        {
            return null;
        }
        public override string Salvar(object obj)
        {
            Paises oPais = (Paises)obj;
            string mSql = "", mOk = "";
            if (oPais.Codigo == 0)
            {
                // Query INSERT (tudo minúsculo)
                mSql = "insert into paises(pais, sigla, ddi, moeda, datcad, ultalt) " +
                       "values(@pais, @sigla, @ddi, @moeda, @datcad, @ultalt)";
            }
            else
            {
                // Query UPDATE (tudo minúsculo e sem o ')' extra)
                mSql = "update paises set pais = @pais, sigla = @sigla, ddi = @ddi, " +
                       "moeda = @moeda, datcad = @datcad, ultalt = @ultalt " +
                       "where id = @id"; // Corrigido
            }

            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                // Parâmetros todos minúsculos para consistência
                cmd.Parameters.AddWithValue("@pais", oPais.Pais);
                cmd.Parameters.AddWithValue("@sigla", oPais.Sigla);
                cmd.Parameters.AddWithValue("@ddi", oPais.Ddi);
                cmd.Parameters.AddWithValue("@moeda", oPais.Moeda);
                cmd.Parameters.AddWithValue("@datcad", oPais.DatCad);
                cmd.Parameters.AddWithValue("@ultalt", oPais.UltAlt);

                // CORREÇÃO: Adicionar o @id APENAS se for UPDATE
                if (oPais.Codigo != 0)
                {
                    cmd.Parameters.AddWithValue("@id", oPais.Codigo);
                }

                cmd.ExecuteNonQuery();

                // CORREÇÃO: Tratar o retorno do ID corretamente
                if (oPais.Codigo == 0) // Se era um INSERT
                {
                    cmd.CommandText = "Select @@IDENTITY";
                    mOk = cmd.ExecuteScalar().ToString();
                }
                else // Se era um UPDATE
                {
                    mOk = oPais.Codigo.ToString(); // Retorna o ID que já existia
                }
            }
            return mOk;
        }
        public override List<Paises> Listar()
        {
            // Ordenando por 'pais' (nome) é mais útil
            string mSql = "select * from paises order by id";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                List<Paises> lista = new List<Paises>();
                while (reader.Read())
                {
                    Paises oPais = new Paises(
                    // Usando nomes de coluna minúsculos (como no schema)
                        Convert.ToInt32(reader["id"]),
                        Convert.ToDateTime(reader["datcad"]),
                        Convert.ToDateTime(reader["ultalt"]),
                        reader["pais"].ToString(),
                        reader["sigla"].ToString(),
                        reader["ddi"].ToString(),
                        reader["moeda"].ToString()
                    );
                    lista.Add(oPais);
                }
               // lista.Add(oPais);
                reader.Close();
                return lista;
            }
        }
        public override Object CarregaObj(int chave)
        {
            // CORREÇÃO: SQL parametrizado
            string mSql = "select * from paises where id = @id";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                // CORREÇÃO: Adicionando o parâmetro
                cmd.Parameters.AddWithValue("@id", chave);

                SqlDataReader reader = cmd.ExecuteReader();
                Paises pais = new Paises();

                // CORREÇÃO: Usando IF em vez de WHILE
                if (reader.Read())
                {
                    // Usando nomes de coluna minúsculos
                    pais.Codigo = Convert.ToInt32(reader["id"]);
                    pais.DatCad = Convert.ToDateTime(reader["datcad"]);
                    pais.UltAlt = Convert.ToDateTime(reader["ultalt"]);
                    pais.Pais = reader["pais"].ToString();
                    pais.Sigla = reader["sigla"].ToString();
                    pais.Ddi = reader["ddi"].ToString();
                    pais.Moeda = reader["moeda"].ToString();
                }
                reader.Close();
                return pais;
            }
        }
        public override List<Paises> Pesquisar(string chave)
        {
            // Implementação de exemplo (pesquisa por nome do país)
            string mSql = "select * from paises where pais LIKE @chave order by pais";
            using (SqlCommand cmd = new SqlCommand(mSql, cnn))
            {
                cmd.Parameters.AddWithValue("@chave", "%" + chave + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                List<Paises> lista = new List<Paises>();

                while (reader.Read())
                {
                    Paises oPais = new Paises();
                    oPais.Codigo = Convert.ToInt32(reader["id"]);
                    oPais.DatCad = Convert.ToDateTime(reader["datcad"]);
                    oPais.UltAlt = Convert.ToDateTime(reader["ultalt"]);
                    oPais.Pais = reader["pais"].ToString();
                    oPais.Sigla = reader["sigla"].ToString();
                    oPais.Ddi = reader["ddi"].ToString();
                    oPais.Moeda = reader["moeda"].ToString();
                    lista.Add(oPais);
                }
                reader.Close();
                return lista;
            }
        }
    }
}
