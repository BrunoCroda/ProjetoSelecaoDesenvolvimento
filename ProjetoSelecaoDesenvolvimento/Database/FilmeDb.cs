using Npgsql;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Database
{
    public class FilmeDb
    {
        public bool Add(Filme filme)
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO filmes" +
                                      @"(titulo, mes_lancamento, ano_lancamento, genero_id)" +
                                      @"VALUES " +
                                      @"(@titulo, @mes_lancamento, @ano_lancamento, @genero_id);";

                    cmd.Parameters.AddWithValue("@titulo", filme.titulo);
                    cmd.Parameters.AddWithValue("@mes_lancamento", filme.mesLancamento);
                    cmd.Parameters.AddWithValue("@ano_lancamento", filme.anoLancamento);
                    cmd.Parameters.AddWithValue("@genero_id", filme.generoId);



                    AccessDb db = new AccessDb();

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Filme Get(int id)
        {
            Filme result = new Filme();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM filmes " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.id = Convert.ToInt32(reader["id"]);
                            result.titulo = reader["titulo"].ToString();
                            result.mesLancamento = Convert.ToInt32(reader["mes_lancamento"]);
                            result.anoLancamento = Convert.ToInt32(reader["ano_lancamento"]);
                            result.generoId = Convert.ToInt32(reader["genero_id"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Filme> GetAll()
        {
            List<Filme> result = new List<Filme>();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM filmes;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Filme filme = new Filme();
                            filme.id = Convert.ToInt32(reader["id"]);
                            filme.titulo = reader["titulo"].ToString();
                            filme.mesLancamento = Convert.ToInt32(reader["mes_lancamento"]);
                            filme.anoLancamento = Convert.ToInt32(reader["ano_lancamento"]);
                            filme.generoId = Convert.ToInt32(reader["genero_id"]);
                            result.Add(filme);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Update(Filme filme)
        {
            bool result = false;
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE filmes " +
                                        @"SET titulo = @titulo, mes_lancamento = @mes_lancamento, ano_lancamento = @ano_lancamento, genero_id = @genero_id " +
                                        @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", filme.id);
                    cmd.Parameters.AddWithValue("@titulo", filme.titulo);
                    cmd.Parameters.AddWithValue("@mes_lancamento", filme.mesLancamento);
                    cmd.Parameters.AddWithValue("@ano_lancamento", filme.anoLancamento);
                    cmd.Parameters.AddWithValue("@genero_id", filme.generoId);


                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM filmes WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}