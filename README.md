# Quick Order - Tech Challenge FIAP

Projeto do Tech Challenge da FIAP - Fase 3

**INTEGRANTES DO GRUPO 74**

* Moisés Barboza de Figueiredo Junior
moises.figueiredo@gmail.com

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

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/e6cbc4a3-87bf-450a-bc39-4b36182c7223)

## Instalação pelo Visual Studio 2022

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio 2022**
* Localizar o arquivo **docker-compose** no Solution Explorer:
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/748435a2-1257-4b95-8cc8-7b63fef4cbc9)


<br />

* Clicar nele com o botão direito e selecionar **Set as Startup Projetct**:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/7f4ffe64-ed50-4061-b699-d148e50a2c3c)


<br />

* Clicar na opção **Docker Compose** da barra de ferramentas padrão:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/b3e01c69-daa8-4e97-98b0-6a3d608f628d)


<br />

* O Visual Studio criará os containers e exibirá a tela do Swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/8854c72c-c280-450a-9b65-2b19f57a9ec9)


<br />

* Uma janela conforme abaixo abrirá:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/b489cf48-2bb9-445f-9817-c1caaf35648f)


<br />

* Na barra de endereços, digitar /swagger após o endereço para que fique desta forma "https://localhost:53699/swagger/" (**ao executar, a sua porta pode estar diferente**) e teclar enter. O resultado será conforme abaixo, exibindo o swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/671a5e6d-816c-4539-be41-bb32e40970ee)


<br />

## Instalação pelo Visual Studio Code

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio Code**
* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e navegar até a pasta **src** do Projeto:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/c0ac9833-55d6-4b44-8d0c-0c48220697b7)


<br />

* Executar o comando `docker-compose up -d`
* Os containeres são levantados conforme imagem abaixo e poderão ser listados através do comando `docker ps`

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/969a9138-7eb1-4ba6-a275-7c1f31ecd8a0)



<br />

* Abrir algum browser e informar o seguinte endereço http ou https:
  * HTTP: **http://localhost:8090/swagger/index.html**
  * HTTPS: **https://localhost:5046/swagger/index.html**

* O resultado deverá ser conforme abaixo:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/0ef4ec5a-2b44-484f-bdf4-b7fd3f5cbd44)


<br />

## Instalação pelo Kubernetes

<br />

**ARQUITETURA UTILIZADA**

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/51400a14-7ee7-4b62-a4e8-475b3ebb44fb)


<br />

Passo a passo:

* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e digitar o comando `kubectl config get-contexts`. O resultado deverá ser conforme abaixo, com o contexto do **docker-desktop** selecionado:
  
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/ce7f5145-2ae7-44a0-82d5-fecf3c593589)


* Caso o contexto do **docker-desktop** não esteja selecionado, selecionar o mesmo através do comando `kubectl config set-context docker-desktop`
* Executar o comando `kubectl get all` para garantir que o cluster esteja limpo e assim prevenir que ocorram conflitos de portas nos passos posteriores. O resultado deverá ser esse:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/01637947-6284-4dd3-a148-d1cc039603f4)


<br />

* Caso haja algum **pod, svc ou deployment** etc listado no passo anterior, limpar o cluster através do comando `kubectl delete all --all` e `kubectl delete pvc --all`
* Baixe o projeto QuickOrder-Infra-Kubernetes do repositório https://github.com/TechChallenge-4SOAT-G74/QuickOrder-Infra-Kubernetes.git
* Verifique os sprits do repositório digitando `ls` 

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/616de0f5-6919-4cd5-b24c-02221f520511)



<br />

* Aplicar os **scripts yml** dos **PersistentVolumeClaim** através do comando `kubectl apply -f .\01-pvc\`:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/22c32deb-51ca-4dc6-85c3-6a47ebfd2fbf)



<br />

* Aplicar os **scripts yml** dos **Deployments** através do comando `kubectl apply -f .\02-deployments\`:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/3226bd83-292f-44cb-a76f-23055fe51380)


<br />

* Aplicar os **scripts yml** dos **Services** através do comando `kubectl apply -f .\03-services\`:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/cbdf8d14-72e7-4869-a591-7f68edda991e)


<br />

* Executar comando `kubectl get all` para verificar a criação dos itens dos passos anteriores. O resultado deverá ser similar ao listado abaixo:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/eae9f6e1-5d0d-4104-bc7e-c712ed09835d)


<br />

* Abrir o browser e digitar o seguinte endereço **http://localhost:30000/swagger/index.html**. O swagger da Api deverá ser exibido, indicando que a subida da aplicação ocorreu com sucesso:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/f8116e81-39f2-4659-9fe4-b814b552ab51)


<br />

**Passo a passo em vídeo Kubernetes**

<br />

<div align="center">
      <a href="https://www.youtube.com/watch?v=GJAberOaVkc">
     <img src="https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/163fddfb-86f0-4f2b-9591-81d0e6f3715d"
      alt="Kubernetes" 
      style="width:560px;height:315px;">
      </a>
</div>

<br />

**Passo a passo WebHooks**

<br />
<div align="center">
      <a href="https://www.youtube.com/watch?v=qNlFbp0ErRk">
     <img src="https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/c7619a83-9f94-4cee-886e-bb7dc3f9023e" 
      alt="Api" 
      style="width:560px;height:315px;">
      </a>
</div>
