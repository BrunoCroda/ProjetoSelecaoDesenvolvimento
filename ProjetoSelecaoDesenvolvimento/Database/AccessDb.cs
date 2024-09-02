﻿using Npgsql;
using ProjetoSelecaoDesenvolvimento.Global;

namespace ProjetoSelecaoDesenvolvimento.Database
{
    public class AccessDb
    {
        public NpgsqlConnection OpenConnection()
        {
            string connectionString = String.Format(
                "Server = {0}; User Id = {1}; Database = {2}; Port = {3}; Password = {4};",
                Config.dbHost, Config.dbUser, Config.dbName, Config.dbPort, Config.dbPass);

            NpgsqlConnection con = new NpgsqlConnection(connectionString);

            con.Open();

            return con;
        }
    }
}
