# Pasqualini's Library and  Rock-paper-scissors

Este aplicativo consiste em:

* Um cadastro de livros utilizando .NET Core e Angular / Bootstrap no frontend
* Uma rotina de execução de um torneio de  Pedra, Papel ou Tesoura

## Considerações
Este foi o primeiro aplicativo que constuí utilizando C#, .NET e demais tecnologias, portanto a organização dos projetos 
pode não ser a melhor.

Mantive tudo em um unico projeto e não inseri as classes em namespaces específicos pelo numero pequeno de arquivos no projeto.

O .gitignore foi o gerado por padrão no "scaffolding" do projeto.

Também os passos que descreverei a para execução do projeto podem não ser necessários, apenas repeoduzi o que tive que fazer
para deixar as coisas rodando.

### Pré condições para a execução
* Visual Studio 2019 community 
* .NET core 2.1
* Deve ter o SQLServer Express instalado
* Acredito que a migração da base acontecerá normalmente, caso não digite no command do NuGet: update-database

### Desafio do Torneio de pedra, papel ou tesoura

A lógica está implementada no proprio projeto PasqualiniLibrary, no folder games.
Os testes estão na classe RockPaperScissorsTest do projeto de testes XUnitTestProject
O framework de testes utilizado foi o XUnit


