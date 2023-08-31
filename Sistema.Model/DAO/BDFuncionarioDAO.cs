using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sistema.Model.DAO
{
    public class BDFuncionarioDAO
    {
        private DbConnectionManager _connectionManager;

        public BDFuncionarioDAO()
        {
            _connectionManager = new DbConnectionManager();
        }
    }
}