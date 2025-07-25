# ♻️ EcoFinder - Sistema de Localização de Materiais Recicláveis

<blockquote>⚠️**Projeto em andamento** - O projeto ainda receberá melhorias e correções.
</blockquote>

## 📌 Sobre o projeto
O EcoFinder é um sistema desenvolvido em C# com MySQL, criado para facilitar o trabalho de coletores de materiais recicláveis, permitindo que encontrem pontos de coleta ativos de forma prática e eficiente. A plataforma conecta cidadãos e instituições que desejam descartar materiais recicláveis com coletores que podem visualizar e reservar chamados próximos. Isso reduz deslocamentos desnecessários, otimiza o processo de coleta e contribui para a sustentabilidade.

## 📄 Documentação

Caso deseje saber mais sobre o projeto, acesse a nossa documentação clicando [aqui](https://drive.google.com/drive/u/0/folders/1NLtgFpumCp1iiWZsDC-syk4n53k8khR0)

## 🚀 Tecnologias utilizadas

- C#
- MySQL 8
- Microsoft Visual Studio 2022
- Windows Forms
- GitHub
- Triggers
- Procedures
- [BrasilAPI](https://brasilapi.com.br/)

## ⚙️ Funcionalidades 

- 👥 Cadastro de coletores e de usuários que solicitam a coleta (Usuário Comum)
- 🏠 Cadastro de endereço dos usuários
- 📝 Atualização de dados dos usuários
- 🗣️ Solicitar coleta (Usuário comum)
- 👀 Ver chamados disponíveis (Coletor)
- 📍Calculo de distância entre o ponto de coleta e o endereço do coletor
- 📩Reservar coleta (Coletor)
- 📑 Ver os chamados realizados ou reservados pelo usuário
- ✅ Confirmar Coleta
- ➕ Ver quantidades de coletas já realizadas (Coletor)

## 🛠️ Como executar localmente

1. Clone o repositório:
    ```
    git clone https://github.com/matheuscostar77/EcoFinder_v2.git
    ```

2. Copie e execute o schema que esta dentro da pasta Schemas dentro do projeto

3. Altere a string de conexão com suas credenciais dentro da classe Pessoa, exemplo:
    ```
    private string stringConexao = "datasource=localhost;username=root;password=SuaSenha123;database=ecofinder";
    ```
4. Execute o programa com o Microsoft Visual Studio 2022

---




