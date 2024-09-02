using Npgsql;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Database
{
    public class UsuarioDb
    {
        public bool Add(Usuario usuario)
        {
            bool result = false;

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO usuarios" +
                                      @"(nome) " +
                                      @"VALUES " +
                                      @"(@nome);";

                    cmd.Parameters.AddWithValue("@nome", usuario.nome);



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

        public Usuario Get(int id)
        {
            Usuario result = new Usuario();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM usuarios " +
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

        public List<Usuario> GetAll()
        {
            List<Usuario> result = new List<Usuario>();
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM usuarios;";

                    using (cmd.Connection = db.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.id = Convert.ToInt32(reader["id"]);
                            usuario.nome = reader["nome"].ToString();
                            result.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Update(Usuario usuario)
        {
            bool result = false;
            AccessDb db = new AccessDb();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE usuarios " +
                                        @"SET nome = @nome " +
                                        @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", usuario.id);
                    cmd.Parameters.AddWithValue("@nome", usuario.nome);


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
                    cmd.CommandText = @"DELETE FROM usuarios WHERE id = @id;";

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
