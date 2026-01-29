using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoSimples.Service
{
    public interface IFileSystemService 
   {
        void LimparPastar(string caminhoDaPasta);
        List<string> ListarArquivos(string caminhoDaPasta);
        void DeletarPasta(string caminhoDaPasta);
        void AdicionarArquivo(string caminhoDaPasta, string arquivo);
    }
}
