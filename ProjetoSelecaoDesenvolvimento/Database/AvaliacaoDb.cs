using Npgsql;
using ProjetoSelecaoDesenvolvimento.Models;
using System;

namespace ProjetoSelecaoDesenvolvimento.Database
{
    public class AvaliacaoDb
    {
        public bool Add(Avaliacao avaliacao)
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO avaliacoes" +
                                      @"(filme_id, usuario_id, avaliacao, comentario)" +
                                      @"VALUES " +
                                      @"(@filme_id, @usuario_id, @avaliacao, @comentario);";

                    cmd.Parameters.AddWithValue("@filme_id", avaliacao.filmeId);
                    cmd.Parameters.AddWithValue("@usuario_id", avaliacao.usuarioId);
                    cmd.Parameters.AddWithValue("@avaliacao", avaliacao.avaliacao);
                    cmd.Parameters.AddWithValue("@comentario", avaliacao.comentario);



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

        public Avaliacao Get(int id)
        {
            Avaliacao result = new Avaliacao();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM avaliacoes " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.id = Convert.ToInt32(reader["id"]);
                            result.filmeId = Convert.ToInt32(reader["filme_id"]);
                            result.usuarioId = Convert.ToInt32(reader["usuario_id"]);
                            result.avaliacao = Convert.ToInt32(reader["avaliacao"]);
                            result.comentario = reader["comentario"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Avaliacao> GetAll()
        {
            List<Avaliacao> result = new List<Avaliacao>();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM avaliacoes;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Avaliacao avaliacao = new Avaliacao();
                            avaliacao.id = Convert.ToInt32(reader["id"]);
                            avaliacao.filmeId = Convert.ToInt32(reader["filme_id"]);
                            avaliacao.usuarioId = Convert.ToInt32(reader["usuario_id"]);
                            avaliacao.avaliacao = Convert.ToInt32(reader["avaliacao"]);
                            avaliacao.comentario = reader["comentario"].ToString();
                            result.Add(avaliacao);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Update(Avaliacao avaliacao)
        {
            bool result = false;
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE avaliacoes " +
                                        @"SET filme_id = @filme_id, usuario_id = @usuario_id, avaliacao = @avaliacao, comentario = @comentario " +
                                        @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", avaliacao.id);
                    cmd.Parameters.AddWithValue("@filme_id", avaliacao.filmeId);
                    cmd.Parameters.AddWithValue("@usuario_id", avaliacao.usuarioId);
                    cmd.Parameters.AddWithValue("@avaliacao", avaliacao.avaliacao);
                    cmd.Parameters.AddWithValue("@comentario", avaliacao.comentario);


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
                    cmd.CommandText = @"DELETE FROM avaliacoes WHERE id = @id;";

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
