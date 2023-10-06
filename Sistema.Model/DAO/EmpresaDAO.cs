﻿using System.Reflection.Emit;
using System.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sistema.Model.Entidades;

namespace Sistema.Model.DAO
{
    using Sistema.Model.DAO;
    using Sistema.Model.Entidades;
    using Sistema.Model.Interfaces.IDAO;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class EmpresaDAO : DAO<Empresa>, IEmpresaDAO
    {
        public EmpresaDAO(DbConnectionManager connectionManager) : base(connectionManager, "Empresa")
        {
            Data = LoadDataFromDatabase(connectionManager, "Empresa"); // inicializa aqui os dados da empresa a partir do banco de dados
        }

        public List<Empresa> ProcuraEmpresaPorNome(string nome)
        {
            List<Empresa> empresasEncontradas = new List<Empresa>();

            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = "SELECT * FROM Empresa WHERE Nome LIKE @Nome;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", "%" + nome + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empresa empresa = MapData(reader);
                            empresasEncontradas.Add(empresa);
                        }
                    }
                }
            }

            return empresasEncontradas;
        }

        public List<Empresa> ProcuraEmpresaPorSetor(string setor)
        {
            List<Empresa> empresasEncontradas = new List<Empresa>();

            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = "SELECT * FROM Empresa WHERE Setor = @Setor;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Setor", setor);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empresa empresa = MapData(reader);
                            empresasEncontradas.Add(empresa);
                        }
                    }
                }
            }

            return empresasEncontradas;
        }

        public override List<Empresa> FilterData(string searchTerm)
        {
            List<Empresa> filteredData = new List<Empresa>();

            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = $"SELECT * FROM Empresa WHERE Nome LIKE @searchTerm OR Cnpj LIKE @searchTerm OR Setor LIKE @searchTerm OR Email LIKE @searchTerm OR Telefone LIKE @searchTerm OR Endereco LIKE @searchTerm";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empresa empresa = MapData(reader);
                            filteredData.Add(empresa);
                        }
                    }
                }
            }

            return filteredData;
        }

        public override object[] GetHeaders()
        {
            string[] headers = { "IdEmpresa", "Nome", "Cnpj", "Setor", "Email", "Telefone", "Endereco" };
            return headers;
        }

        public override void SetData(List<Empresa> data)
        {
            Data = data;
        }

        protected override Empresa MapData(SqlDataReader reader)
        {
            Empresa empresa = new Empresa
            {
                Id = (int)reader["IdEmpresa"],
            };
            empresa.SetNomeEmpresa(reader["Nome"].ToString());
            empresa.SetCnpjEmpresa(reader["Cnpj"].ToString());
            empresa.SetSetorEmpresa(reader["Setor"].ToString());
            empresa.SetEmailEmpresa(reader["Email"].ToString());
            empresa.SetTelefoneEmpresa(reader["Telefone"].ToString());
            empresa.SetEnderecoEmpresa(reader["Endereco"].ToString());

            return empresa;
        }
    }

}