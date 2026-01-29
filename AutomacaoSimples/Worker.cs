using AutomacaoSimples.Model;
using AutomacaoSimples.Service;

namespace AutomacaoSimples
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TimeSpan _periodo;
        private readonly IFileSystemService _fileSystemService;
        private readonly IConfiguration _configuration; 
        private readonly ConfigurationDTO config;

        public Worker(ILogger<Worker> logger, IFileSystemService fileSystemService, IConfiguration configuration)
        {
            _logger = logger;
            _fileSystemService = fileSystemService;
            _configuration = configuration;

            config.CaminhoDaPasta = _configuration.GetValue<string>("ConfiguracoesDeLimpeza:CaminhoDaPasta");
            config.IntervaloEmHoras = _configuration.GetValue<string>("ConfiguracoesDeLimpeza:IntervaloEmHoras");

            _periodo = TimeSpan.FromHours(int.Parse(config.IntervaloEmHoras));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(_periodo);
            while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Iniciando limpeza de arquivos...");
                    _fileSystemService.ListarArquivos(config.CaminhoDaPasta);
                    _fileSystemService.LimparPastar(config.CaminhoDaPasta);
                    _fileSystemService.ListarArquivos(config.CaminhoDaPasta);


                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao limpar arquivos.");
                }
            }
        }

    }
}
