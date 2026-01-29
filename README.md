🧹 File Cleanup Worker Service

Um serviço de background resiliente construído com .NET para automação de limpeza de arquivos temporários.

📋 Sobre o Projeto

Este projeto é uma implementação de referência de um Worker Service em .NET. O objetivo é fornecer uma solução automatizada para monitorar diretórios específicos e remover arquivos que excedem um tempo de vida configurado (TTL).

Foi desenvolvido como um estudo de caso para explorar o ciclo de vida de aplicações daemon no ecossistema .NET, focando em execução periódica eficiente e gerenciamento de recursos.

🚀 Funcionalidades

Execução Periódica Precisa: Utiliza PeriodicTimer para garantir ciclos de execução consistentes sem o "drift" comum de Task.Delay.

Limpeza Configurável: O diretório alvo e o tempo de retenção dos arquivos são definidos via appsettings.json.

Logging Estruturado: Monitoramento completo das operações (arquivos deletados, erros de permissão, espaço liberado) usando ILogger.

Graceful Shutdown: Implementação correta do CancellationToken para garantir que o serviço pare de forma segura sem corromper operações em andamento.

🛠️ Tecnologias e Conceitos Aplicados
Core: .NET 8 / C#

Background Tasks: BackgroundService e IHostedService

Gerenciamento de Tempo: System.Threading.PeriodicTimer (Non-blocking timer)

Manipulação de Arquivos: System.IO

Configuração: Padrão IOptions<T> para injeção de configurações tipadas.

⚙️ Configuração

O comportamento do serviço é controlado pelo arquivo appsettings.json.

JSON

{

  "Logging": {
    "LogLevel": {    
      "Default": "Information",      
      "Microsoft.Hosting.Lifetime": "Information"
    }
    
  },
  
  // Adicione esta parte:
  
  "ConfiguracoesDeLimpeza": {  
    "CaminhoDaPasta": "C:\\Windows\\Temp",    
    "IntervaloEmHoras ": 60    
  }
  
}

📦 Como Rodar

Pré-requisitos
.NET SDK 8.0+

Passos
Clone o repositório:

Bash
git clone https://github.com/Gacarmo97/AutomacaoSimplesWorker.git

Navegue até a pasta e restaure as dependências:

Bash
cd FileCleanupWorker
dotnet restore
Execute o serviço:

Bash
dotnet run


📚 O que aprendi com este projeto

Este projeto serviu para consolidar conhecimentos sobre como o .NET gerencia processos de longa duração fora do contexto HTTP (ASP.NET). Os principais aprendizados foram:

A diferença entre rodar um Timer clássico e o novo PeriodicTimer assíncrono.

Como estruturar logs para facilitar o debug em ambientes de produção (onde não há console visível).

A importância de passar o CancellationToken para todas as chamadas assíncronas de I/O.
