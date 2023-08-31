using System.Reflection.Emit;
using Internal;
using System.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using Sistema.Model.Entidades;

namespace Sistema.Model.DAO
{
    public class EmpresaDAO
    {
        private DbConnectionManager connectionManager;

        public EmpresaDAO(){
            connectionManager = new DbConnectionManager();
        }

        public List<Empresa> GetAllEmpresas(){
            List<Empresa> empresas = new List<Empresa>();

            using (SqlConnection connection = connectionManager.GetConnection()){
                string query = "SELECT IdEmpresa, Nome, Cnpj, Setor, Email, Telefone, Endereco FROM Empresa";
                SqlCommand command = new SqlCommand(query, connection);

                try{
                    connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read()){
                        Empresa empresa = new Empresa{
                            IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                            Nome = reader["Nome"].ToString(),
                            Cnpj = reader["Cnpj"].ToString(),
                            Setor = reader["Setor"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefone = reader["Telefone"].ToString(),
                            Endereco = reader["Endereco"].ToString(),

                        };

                        empresas.Add(empresa);
                    }

                    reader.Close();
                }

                catch(Exeption ex){
                    Console.WriteLine("An error occured: " + ex.Message);
                }

                finally{
                    connectionManager.CloseConnection();
                }
            }

            return empresas;
        }
    }
}