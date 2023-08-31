using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sistema.Model.DAO
{
    public class PessoaDAO
    {
        private DbConnectionManager connectionManager;

        public PessoaDAO()
        {
            connectionManager = new DbConnectionManager();
        }

        public List<Pessoa> GetAllPessoas() 
        {

        }

    }
}