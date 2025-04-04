# GameUp (API)
Esse projeto foi gerado para criar um cadastro de games e praticar alguns conceitos

## Pré-requisitos
Antes de rodar a aplicação, você precisará de algumas ferramentas instaladas:

- Visual Studio 2022 (recomendado)
- .NET 8 SDK
- SQL Server ou uma instância compatível de banco de dados (a aplicação usa SQL Server com a string de conexão definida abaixo)

## Passo a passo
### Clonar repositório
Primeiro, faça o clone do repositório para a sua máquina local. Abra o terminal ou o Git Bash e execute:

`git clone https://github.com/Glrodrigo/GameUpApp.git`

### Configuração do Banco de Dados
A aplicação originalmente usaria o SQL Server para armazenar os dados, mas como se trata de apenas uma demonstração, os dados serão armazenados em memória temporariamente, não havendo a necessidade de uma string de conexão com o banco de dados.

### Restaurar Pacotes NuGet
Depois de clonar o repositório, abra o arquivo da solução HairCutApp.sln no Visual Studio.

Na barra de menu do Visual Studio, vá para Ferramentas > Gerenciador de Pacotes NuGet > Restaurar Pacotes para garantir que todas as dependências sejam baixadas.

### Definindo o Projeto de Inicialização
- Selecione o projeto `GamesUpApp` como o projeto de inicialização.
- Escolha a opção "ISS Express" como executor e, se solicitado, aceite o certificado para rodar a aplicação localmente.

### Rodar a Aplicação
Para rodar a aplicação, clique em Iniciar ou pressione F5. O Visual Studio irá construir e iniciar o servidor local.

### Rodar os Testes
- No Visual Studio, localize o projeto de testes `GamesUpApp.Tests` no "Solution Explorer".
- Clique com o botão direito sobre o projeto de testes e selecione Executar Testes para rodar todos os testes.
