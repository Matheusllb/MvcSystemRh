using System.Reflection.Emit;
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
    public class EmpresaDAO
    {
        private DbConnectionManager _connectionManager;

        public EmpresaDAO(){
            _connectionManager = new DbConnectionManager();
        }

        public List<Empresa> GetAllEmpresas(){
            List<Empresa> empresas = new List<Empresa>();

            using (SqlConnection connection = _connectionManager.GetConnection()){
                string query = "SELECT IdEmpresa, Nome, Cnpj, Setor, Email, Telefone, Endereco FROM Empresa";
                SqlCommand command = new SqlCommand(query, connection);

                try{
                    _connectionManager.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read()){
                        Empresa empresa = new Empresa(
                            Convert.ToInt32(reader["IdEmpresa"]),
                            reader["Nome"].ToString(),
                            reader["Cnpj"].ToString(),
                            reader["Setor"].ToString(),
                            reader["Email"].ToString(),
                            reader["Telefone"].ToString(),
                            reader["Endereco"].ToString()
                        );

                        empresas.Add(empresa);
                    }

                    reader.Close();
                }

                catch(Exception ex){
                    Console.WriteLine("An error occured: " + ex.Message);
                }

                finally{
                    _connectionManager.CloseConnection();
                }
            }

            return empresas;
        }
    }
}