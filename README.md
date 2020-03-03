# UDSAcaiApi

Manual de montagem de ambiente de desenvolvimento.

## Conte�do

-[Pr�-requisitos](#pr�-requisitos)
- [Configura��o](#configura��o)
- [Execu��o](#execu��o)
- [LaunchSettings](#launchSettings)
- [Environment Variables](#environment)
- [Connection Strings](#connection-strings)

**Aten��o**

> Todos os passos desta documenta��o s�o obrigat�rios, sendo imprescind�vel que voc� obtenha sucesso na realiza��o de cada passo.

> Nesta documenta��o considero que voc� est� utilizando o SO Windows 10. Caso esteja utilizando outro sistema operacional, fa�a as devidas adapta��es.

## Pr�-requisitos

� necess�rio que voc� tenha instalado em sua m�quina:

- [.Net Core](https://dotnet.microsoft.com/download) (_2.2_)
  _A instala��o deve anteceder os pr�ximos passos ou pode ser feita atrav�s do visual studio installer caso opte por usar a IDE, adicionando o pacote .Net Core._

- Recomendo a IDE [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) (_2017 ou superior_) ou o editor de texto [Visual Studio Code](https://code.visualstudio.com/download)

- A instala��o do banco de dados [Sql Server](https://docs.microsoft.com/pt-br/sql/getting-started/quick-start-installation-of-sql-server-2014?view=sql-server-2014) (_2014 ou superior_)

> No  projeto UDSAcaiApi.Data existe a pasta Script que cont�m os scripts de cria��o de database, schema e tabelas.
  > Apos concluir a instala��o do Sql Server � necess�rio executar esses scripts na seguinte ordem:
  1. script_cria��o_data_base.sql
  2. script_cria��o_esquemaa.sql
  3. script_cria��o_banco.sql

## Configura��o

### Ambiente

- Enquanto o projeto estiver em ambiente de desenvolvimento os valores abaixo dever�o permanecer como foram previamente configurados

- **Caso esteja utilizando o Visual Studio**

  > Clicando com o bot�o direito no projeto UDSAcaiApi e selecionando a op��o propriedades, ser� aberto o menu de propriedades do projeto em quest�o, selecionando a op��o depurar � poss�vel encontrar as vari�veis do ambiente.
  > Enquanto a vari�vel `ASPNETCORE_ENVIRONMENT` estiver com o valor `Development`, o projeto ir� iniciar com as configura��es de desenvolvimento, caso o valor seja alterado as configura��es de inicializa��o tamb�m sofrer�o altera��es. Valores poss�veis para a vari�vel s�o: `Development e Production`
  

## Execu��o

O projeto UDSAcaiApi est� dividido em m�dulos, o m�dulo UDSAcaiApi � o ponto de entrada da aplica��o, os m�dulos UDSAcaiApi.Core e UDSAcaiApi.Data s�o bibliotecas de classe e o UDSAcaiApi.Test � o projeto que cont�m os testes.

**Aten��o**

- **Caso esteja utilizando o Visual Studio**

> Neste momento o seu Visual Studio j� deve estar configurado com o .NET Core.


1. Abra o arquivo UDSAcaiApi.sln_ com o Visual Studio.

3. Execute a aplica��o a partir do projeto UDSAcaiApi, utilizando o menu que se encontra no topo da tela clicando no bot�o play.

> No navegador padr�o da m�quina ser� aberto uma p�gina no endere�o `https://localhost:44335/swagger/index.html`, o endpoint apresentar� uma p�gina com a documenta��o da Api. 

## LaunchSettings

No projeto UDSAcaiApi, � necess�rio a cria��o de um arquivo `launchSettings.json` na pasta `Properties` para que o projeto seja executado corretamente e tenha todas as vari�veis de ambiente. Para isso basta criar a pasta Properties no projeto UDSAcaiApi, adicionar o arquivo launchSettings.json na pasta e colar o json abaixo.

```json
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:53555",
      "sslPort": 44328
    }
  },
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "DATABASE_CONNECTION_STRING": "Data Source=SLT-002622;Initial Catalog=UDSAcai;Integrated Security=True"
      }
    },
    "UDSAcaiApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "DATABASE_CONNECTION_STRING": "Data Source=SLT-002622;Initial Catalog=UDSAcai;Integrated Security=True"
      }
    }
  }
}
```

## Environment

Aqui est� uma tabela com todas as vari�veis de ambiente existentes no projeto at� o momento e que tamb�m aparecerem no `launchSettings.json` mostrado acima.

| Nome                                  | Descri��o                                            | Valor de exemplo                                             |
| ------------------------------------- | ---------------------------------------------------- | ------------------------------------------------------------ |
| **ASPNETCORE_ENVIRONMENT**            | Valores poss�veis `Development e Production`		   | Development                                                  |
| **DATABASE_CONNECTION_STRING**        |                                                      | "Data Source=Servidor;Initial Catalog=UDSAcai;Integrated Security=True"; |

## Connection Strings

- Por padr�o as connection strings que est�o no projeto s�o para acesso ao banco de dados local da minha m�quina, para testar a api utilizando o banco de dados interno
  ser� necess�rio alterar essas vari�veis que se encontram no arquivo `launchSettings.json` no projeto UDSAcaiApi.
