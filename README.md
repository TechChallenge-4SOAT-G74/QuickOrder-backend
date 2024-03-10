# Quick Order - Tech Challenge FIAP

Projeto do Tech Challenge da FIAP - Fase 2

**INTEGRANTES DO GRUPO 36**

* Matheus Augusto Silva dos Santos
matheus.santos8192@outlook.com

* Moisés Barboza de Figueiredo Junior
moises.figueiredo@gmail.com

* Keilla Cristina Martins Conforto
kcrismartins@gmail.com

* Gabriela da Silva Lopes
gabrieladslopes@gmail.com

* Francisco Tadeu da Silva e Souza
fsouza.thadeu@gmail.com

<br />

## Conteúdos

- [Pré-Requisitos](#pré-requisitos)
- [Instalação pelo Visual Studio 2022](#instalação-pelo-visual-studio-2022)
- [Instalação pelo Visual Studio Code](#instalação-pelo-visual-studio-code)
- [Instalação pelo Kubernetes](#instalação-pelo-kubernetes)

<br />

## Pré-Requisitos

Antes de executar este projeto, os seguintes itens deverão estar instalados no computador:

* Docker
* Kubernetes
* Visual Studio 2022 ou Visual Studio Code
* Verificar e caso necessário, ajustar o arquivo appSettings.json para que os valores das connectionStrings fiquem conforme abaixo:
<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/cd812ee5-f856-4368-96f2-743650a13866)


## Instalação pelo Visual Studio 2022

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio 2022**
* Localizar o arquivo **docker-compose** no Solution Explorer:
<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/a4f481ce-4f13-4980-913d-f6751aec050a)

<br />

* Clicar nele com o botão direito e selecionar **Set as Startup Projetct**:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/f16770a5-ed9e-47df-ad84-b8363ca79832)

<br />

* Clicar na opção **Docker Compose** da barra de ferramentas padrão:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/495ec4ef-9b0f-4037-8f0b-7390c485a616)

<br />

* O Visual Studio criará os containers e exibirá a tela do Swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/c6b1d930-5ea2-459d-a116-a9f960c72c7e)

<br />

* Uma janela conforme abaixo abrirá:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/3d2881da-c561-4a48-88fa-34f53bd1e889)

<br />

* Na barra de endereços, digitar /swagger após o endereço para que fique desta forma "https://localhost:53699/swagger/" (**ao executar, a sua porta pode estar diferente**) e teclar enter. O resultado será conforme abaixo, exibindo o swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/4bac9341-7130-4445-b675-88adfa3ccb53)

<br />

## Instalação pelo Visual Studio Code

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio Code**
* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e navegar até a pasta **src** do Projeto:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/d1ab97a6-9c8f-407f-bc98-e0cdb08f860d)

<br />

* Executar o comando `docker-compose up -d`
* Os containeres são levantados conforme imagem abaixo e poderão ser listados através do comando `docker ps`

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/046561e8-9527-4e97-9882-1da1b04a9041)



<br />

* Abrir algum browser e informar o seguinte endereço http ou https:
  * HTTP: **http://localhost:8090/swagger/index.html**
  * HTTPS: **https://localhost:5046/swagger/index.html**

* O resultado deverá ser conforme abaixo:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/c1150eb1-a25a-4ee2-aeb8-c0c03ede965f)

<br />

## Instalação pelo Kubernetes

<br />

**ARQUITETURA UTILIZADA**

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/a65095b1-08a6-4538-9b0c-4a781ebf979b)

<br />

Passo a passo:

* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e digitar o comando `kubectl config get-contexts`. O resultado deverá ser conforme abaixo, com o contexto do **docker-desktop** selecionado:
  
<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/953c1eeb-8bca-4ee4-bc1d-1299e6068b4f)

* Caso o contexto do **docker-desktop** não esteja selecionado, selecionar o mesmo através do comando `kubectl config set-context docker-desktop`
* Executar o comando `kubectl get all` para garantir que o cluster esteja limpo e assim prevenir que ocorram conflitos de portas nos passos posteriores. O resultado deverá ser esse:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/2a0b22e7-bb53-4f0f-a902-ad1db0071f68)

<br />

* Caso haja algum **pod, svc ou deployment** etc listado no passo anterior, limpar o cluster através do comando `kubectl delete all --all` e `kubectl delete pvc --all`
* Navegar até a pasta **Kubernetes** do Projeto:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/4c7a6310-6c38-48d3-90d9-e9c40f2fb69c)

<br />

* Aplicar os **scripts yml** dos **PersistentVolumeClaim** através do comando `kubectl apply -f .\01-pvc\`:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/9b0f694f-3d8c-4cce-81b1-82b398cfd329)

<br />

* Aplicar os **scripts yml** dos **Deployments** através do comando `kubectl apply -f .\02-deployments\`:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/302526e7-95c5-4ca7-83bb-9d6b1ee1b5a0)

<br />

* Aplicar os **scripts yml** dos **Services** através do comando `kubectl apply -f .\03-services\`:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/f225f071-a3d8-4d3f-a806-6e6dd678115d)

<br />

* Executar comando `kubectl get all` para verificar a criação dos itens dos passos anteriores. O resultado deverá ser similar ao listado abaixo:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/82f403f5-9396-4bde-8752-d981e97810fb)

<br />

* Abrir o browser e digitar o seguinte endereço **http://localhost:30000/swagger/index.html**. O swagger da Api deverá ser exibido, indicando que a subida da aplicação ocorreu com sucesso:

<br />

![image](https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/8eda4804-7b3a-48a9-beee-1d562693b280)

<br />

**Passo a passo em vídeo Kubernetes**

<br />

<div align="center">
      <a href="https://www.youtube.com/watch?v=GJAberOaVkc">
     <img src="https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/028deb6c-4929-4fbb-9fa9-294108219dd3" 
      alt="Kubernetes" 
      style="width:560px;height:315px;">
      </a>
</div>

<br />

**Passo a passo WebHooks**

<br />
<div align="center">
      <a href="https://www.youtube.com/watch?v=qNlFbp0ErRk">
     <img src="https://github.com/TechChallenge-4SOAT-G36/QuickOrder/assets/19378661/2c30080d-9288-4da2-b85d-32069c274695" 
      alt="Api" 
      style="width:560px;height:315px;">
      </a>
</div>
