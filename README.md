# Collectio
### Projeto de conclusão de curso de ciência da computação 2021
Este projeto inclui um software de repositório, pesquisador e padronizador de arquivos com foco em auxilio de projetos escritos.
Para seu devido manuseio separaremos em topicos.

## Como rodar o programa em sua maquina

### Inicialmente  
- Utilize a branch de desenvolvimento "develop";
- Não esqueça de atualizar os node modules;
- Instale as bibliotecas python necessárias contidas no codigo da API Luhn

### API Controller
Para rodar o projeto é necessário alterar a string de conexão com o banco de dados na appsettings.json
caso necessário criar o banco de dados manualmente com o nome "ApiControllerDb" e usar o comando "update-database" no package manager console do projeto 04-Data

### API LUHN
para rodar a api basta iniciar pycharm, adicionar o interpretador nas configurações de execução e rodar a API.

### Front
Para rodar o front basta abrir o projeto no editor de sua preferencia, usar o comando "npm install / yarn install" para adicionar as dependencias faltantes e depois ng serve para rodar

### API Crawler
Quando for utilizar a pagina do sugestionador primeiro insira o link que deseja para treinar a inteligencia artificial e clicar no botão de busca. Após o pressionamento do botão, aguarde o "Scrapper".

### Scrapper
Dentro do projeto web Crawler o Scrapper deve ser selecionado para a build e assim aguardar que ele insira no banco de dados as informações que serão retornadas. Após isso retorne ao front e aplique a palavra chave para busca.


## Metodos de uso
Ao iniciar a utilização do programa o usuário se deparará com a tela de login, ao adentrar com seus dados pré cadastrados ele receberá o acesso as demais funcionalidades do programa. 

Na tela principal após o login o usuário terá alguns botões em um menu superior a sua disponibilidade, sendo eles: Home, sumarizador, recomendador, formatador, sobre nós e botão de sair.

Todas as abas possuem cartões de instrução de uso para sua respectiva função. 

### Login
- Universidade cria a conta.
- Há a necessidade de solicitação de pedido de troca de senha caso tenha esquecido.

### Home
- Nesta aba o usuário poderá ver os elementos pré-textuais de seu projeto.

### Sumarizador
- Há duas telas onde na primeira se inserirá o texto a ser resumido. Em baixo da primeira tela há a opção de proporção de linhas que seu texto vai ser resumido. Ao lado um botão em azul escrito "Enviar resumo" que ativará a função que será transcrita para a segunda tela.

### Recomendador
- Na primeira opção há uma caixa escrita "Link de busca" onde se colocará o link de sua pesquisa no google para treinar a inteligencia artificial a entender suas necessidades de busca. Ao lado o botão para realizar a ação.
- Ao lado clique em Analisar para a Inteligencia artificial começar a busca de seus dados.
- As informações aparecerão abaixo e caso queira filtrar as opções para buscas mais detalhadas ao lado de "Analisar" há a caixa de "Filtro" com o respectivo botão de confirmação da ação após o inserimento da palavra-chave.


### Upload de documentos

- Desenvolvida com o intuito de seu acesso ser restrito a professores e secretaria, é através desta interface que o usuário pode subir os documentos no banco.

### Sobre nós
- Uma aba para entendimento da empresa, termo e condições de uso, dados e motivos de uso bem como outras informações de relevância.

### Sair
- Neste botão o usuário se retirará de sua conta do software e seguirá de volta para a tela de login.


## OBS:
Caso alguma funcionalidade não seja realizada de acordo por conta de um erro do tipo CRS, deve-se ir até a pasta do executavel do navegador e executar o comando de liberação. Exemplos: 

- "C:\Program Files\Google\Chrome\Application\chrome.exe" --disable-web-security --disable-gpu --user-data-dir=~/chromeTemp
- "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --disable-web-security --disable-gpu --user-data-dir=~/chromeTemp.


