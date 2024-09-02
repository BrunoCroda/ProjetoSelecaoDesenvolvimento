using Npgsql;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Database
{
    public class FilmeStreamingDb
    {
        public bool Add(FilmeStreaming filmeStreaming)
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO filmes_streamings" +
                                      @"(filme_id, streaming_id )" +
                                      @"VALUES " +
                                      @"(@filme_id, @streaming_id);";

                    cmd.Parameters.AddWithValue("@filme_id", filmeStreaming.filmeId);
                    cmd.Parameters.AddWithValue("@streaming_id", filmeStreaming.streamingId);



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

        public FilmeStreaming Get(int id)
        {
            FilmeStreaming result = new FilmeStreaming();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM filmes_streamings " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.id = Convert.ToInt32(reader["id"]);
                            result.filmeId = Convert.ToInt32(reader["filme_id"]);
                            result.streamingId = Convert.ToInt32(reader["streaming_id"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<FilmeStreaming> GetAll()
        {
            List<FilmeStreaming> result = new List<FilmeStreaming>();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM filmes_streamings;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FilmeStreaming filmeStreaming = new FilmeStreaming();
                            filmeStreaming.id = Convert.ToInt32(reader["id"]);
                            filmeStreaming.filmeId = Convert.ToInt32(reader["filme_id"]);
                            filmeStreaming.streamingId = Convert.ToInt32(reader["streaming_id"]);
                            result.Add(filmeStreaming);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Update(FilmeStreaming filmeStreaming)
        {
            bool result = false;
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE filmes_streamings " +
                                        @"SET filme_id = @filme_id, streaming_id = @streaming_id " +
                                        @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", filmeStreaming.id);
                    cmd.Parameters.AddWithValue("@titulo", filmeStreaming.filmeId);
                    cmd.Parameters.AddWithValue("@mes_lancamento", filmeStreaming.streamingId);


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
                    cmd.CommandText = @"DELETE FROM filmes_streamings WHERE id = @id;";

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
