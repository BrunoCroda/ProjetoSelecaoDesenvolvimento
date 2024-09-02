using Npgsql;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Database
{
    public class GeneroDb
    {
        public bool Add(Genero genero)
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO generos" +
                                      @"(nome)" +
                                      @"VALUES " +
                                      @"(@nome);";

                    cmd.Parameters.AddWithValue("@nome", genero.nome);



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

        public Genero Get(int id)
        {
            Genero result = new Genero();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM generos " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.id = Convert.ToInt32(reader["id"]);
                            result.nome = reader["nome"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Genero> GetAll()
        {
            List<Genero> result = new List<Genero>();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM generos;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Genero genero = new Genero();
                            genero.id = Convert.ToInt32(reader["id"]);
                            genero.nome = reader["nome"].ToString();
                            result.Add(genero);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Update(Genero genero)
        {
            bool result = false;
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE generos " +
                                      @"SET nome = @nome " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", genero.id);
                    cmd.Parameters.AddWithValue("@nome", genero.nome);


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
                    cmd.CommandText = @"DELETE FROM generos WHERE id = @id;";

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
