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
                        Empresa empresa = new Empresa{
                            _idEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                            _nome = reader["Nome"].ToString(),
                            _cnpj = reader["Cnpj"].ToString(),
                            _setor = reader["Setor"].ToString(),
                            _email = reader["Email"].ToString(),
                            _telefone = reader["Telefone"].ToString(),
                            _endereco = reader["Endereco"].ToString(),

                        };

                        empresas.Add(empresa);
                    }

                    reader.Close();
                }

                catch(Exeption ex){
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