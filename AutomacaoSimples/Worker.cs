using AutomacaoSimples.Service;

namespace AutomacaoSimples
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TimeSpan _periodo = TimeSpan.FromHours(24);
        private readonly IFileSystemService _fileSystemService;
        private string caminhoDaPasta = "C:\\Windows\\Temp";
        public Worker(ILogger<Worker> logger, IFileSystemService fileSystemService)
        {
            _logger = logger;
            _fileSystemService = fileSystemService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(_periodo);
            while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Iniciando limpeza de arquivos...");
                    _fileSystemService.ListarArquivos(caminhoDaPasta);
                    _fileSystemService.LimparPastar(caminhoDaPasta);
                    _fileSystemService.ListarArquivos(caminhoDaPasta);


                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao limpar arquivos.");
                }
            }
        }
    }
}
