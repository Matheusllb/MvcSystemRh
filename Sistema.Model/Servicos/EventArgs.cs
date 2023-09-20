using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Interfaces.IDAO
{
    // Classe genérica EventArgs<T> que herda de EventArgs (para uso em eventos)
    public class EventArgs<T> : EventArgs
    {
        // Propriedade pública "Value" para armazenar o valor genérico T
        public T Value { get; private set; }

        // Construtor da classe que recebe um valor genérico T como argumento
        public EventArgs(T value)
        {
            // Inicializa a propriedade "Value" com o valor fornecido no construtor
            Value = value;
        }
    }
}