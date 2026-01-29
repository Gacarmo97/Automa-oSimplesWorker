using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoSimples.Service
{
    public class FileSystemService : IFileSystemService
    {
        public void AdicionarArquivo(string caminhoDaPasta, string arquivo)
        {
            throw new NotImplementedException();
        }

        public void DeletarPasta(string caminhoDaPasta)
        {
            try
            {
                if (Directory.Exists(caminhoDaPasta))
                {
                    Directory.Delete(caminhoDaPasta, true);
                    Console.WriteLine("Pasta e conteúdo deletados com sucesso.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
            }
        }
        public void LimparPastar(string caminhoDaPasta)
        {
            try
            {
                // 1. Verifica se o diretório existe para evitar erros
                if (Directory.Exists(caminhoDaPasta))
                {
                    // 2. Obtém a lista de todos os arquivos no diretório
                    string[] arquivos = Directory.GetFiles(caminhoDaPasta);

                    foreach (string arquivo in arquivos)
                    {
                        // 3. Deleta o arquivo
                        File.Delete(arquivo);
                        Console.WriteLine($"Deletado: {arquivo}");
                    }

                    Console.WriteLine("Limpeza de arquivos concluída.");
                }
                else
                {
                    Console.WriteLine("O diretório não foi encontrado.");
                }
            }
            catch (IOException e)
            {
                // Captura erros como "Arquivo em uso por outro processo"
                Console.WriteLine($"Erro de I/O: {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                // Captura erros de permissão (ex: pasta do sistema ou somente leitura)
                Console.WriteLine($"Erro de Permissão: {e.Message}");
            }
        }

        public List<string> ListarArquivos(string caminhoDaPasta)
        {
            try
            {
                if (Directory.Exists(caminhoDaPasta))
                {
                    var listaArquivos = Directory.GetFiles(caminhoDaPasta).ToList();
                    Console.WriteLine($"A pasta contém {listaArquivos.Count} arquivos.");
                    return listaArquivos;
                }

                Console.WriteLine("Pasta não encontrada.");
                return new List<string>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return new List<string>();
            }
        }
    }
}
