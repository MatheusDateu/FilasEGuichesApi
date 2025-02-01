   # 🏛️ Filas & Guichês API

🚀 API para gerenciamento de **filas e guichês** em atendimento, permitindo a criação de tipos de guichês, guichês específicos e fichas numeradas automaticamente.

## 📌 Tecnologias Utilizadas

- **ASP.NET Core 7**
- **Entity Framework Core**
- **InMemory Database** (Pode ser trocado por SQL Server, MySQL, etc.)
- **Swagger/OpenAPI**
- **C#**
- **REST API**

---

## 📥 Como Rodar o Projeto

### 🔧 **Pré-requisitos**
Certifique-se de ter instalado:
- [.NET SDK 7.0+](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Git](https://git-scm.com/)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- Postman ou Curl (para testar a API)

### 🚀 **Passo a Passo**
1. **Clone o repositório**
   ```sh
   git clone https://github.com/seu-usuario/filas-e-guiches-api.git
   cd filas-e-guiches-api
   ```

2. **Restaure as dependências**
   ```sh
   dotnet restore
   ```

3. **Inicie a aplicação**
   ```sh
   dotnet run
   ```

4. **Acesse a API no navegador**
   - A API estará disponível em `http://localhost:5000` ou `https://localhost:7000`
   - A documentação Swagger estará em:  
     👉 `http://localhost:5000/swagger`  
     👉 `https://localhost:7000/swagger`

---

## 📌 Como Testar a API

### 1️⃣ **Criar um Tipo de Guichê**
```http
POST /api/gerencia/tiposguiche
```
📌 **Body (JSON)**:
```json
{
  "nome": "Atendimento",
  "prefixo": "A"
}
```

---

### 2️⃣ **Criar um Guichê**
```http
POST /api/gerencia/guiches
```
📌 **Body (JSON)**:
```json
{
  "tipoGuicheId": 1
}
```

---

### 3️⃣ **Criar uma Ficha**
```http
POST /api/gerencia/fichas/{guicheId}
```
📌 **Exemplo para Guichê ID 1**:
```http
POST /api/gerencia/fichas/1
```

---

## 📌 Como Contribuir

Este é um projeto **open-source**, e contribuições são bem-vindas! ❤️

### 🎯 **1. Verifique os Issues**
- Confira a aba **Issues** no GitHub para ver o que pode ser feito.
- Se não houver uma issue para sua ideia, crie uma **nova**.

### 🔀 **2. Crie uma Branch**
Siga o padrão do **GitFlow**:
```sh
git checkout -b feature/nome-da-feature
```
Exemplo:
```sh
git checkout -b feature/melhorar-documentacao
```

### 💻 **3. Faça suas Alterações e Commit**
1. Faça as modificações no código.
2. Teste tudo antes de continuar.
3. Faça um commit explicando a mudança:
   ```sh
   git commit -m "Adiciona funcionalidade X à API"
   ```

### 🚀 **4. Envie para o GitHub**
```sh
git push origin feature/nome-da-feature
```

### 🔁 **5. Crie um Pull Request (PR)**
- No GitHub, vá até o seu repositório e clique em **Compare & pull request**.
- **Selecione a branch `develop` como destino**.
- Adicione uma descrição clara e envie seu PR!

---

## 📜 Licença

Este projeto é licenciado sob a **MIT License** - consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 🌎 Contato & Suporte

Se tiver dúvidas, sugestões ou problemas:
- Abra um **Issue** no GitHub
- Me contate via **mdelmondes5@outlook.com**

---

🚀 **Vamos juntos melhorar esta API!** 🏛️💙
