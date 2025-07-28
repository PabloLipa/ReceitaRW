# ReceitaRW
📊 Teste Técnico - Cadastro de Empresas com Consulta via CNPJ
🎯 Objetivo
Desenvolver uma aplicação fullstack que permita o cadastro e autenticação de usuários, bem como o registro de empresas a partir do CNPJ, consumindo dados da API pública ReceitaWS. O projeto tem como foco demonstrar domínio técnico, boas práticas de desenvolvimento e estruturação clara do código.

⚙️ Tecnologias Utilizadas
Frontend: Angular 20

Backend: Asp.NET/ .NET core / C#

Banco de Dados: SQLite

API Externa: ReceitaWS

Autenticação: JWT (JSON Web Token)

Estilização: Angular Material / TailwindCSS

🧪 Funcionalidades
1. Cadastro e Autenticação de Usuários
Campos: nome, e-mail, senha

Armazenamento seguro da senha com hash

Login com geração de token JWT

2. Cadastro de Empresas
Usuário autenticado cadastra empresa informando apenas o CNPJ

Dados da empresa são obtidos diretamente da ReceitaWS

Campos persistidos:

Nome empresarial

Nome fantasia

CNPJ

Situação

Data de abertura

Tipo, natureza jurídica

Atividade principal

Endereço completo (logradouro, número, complemento, bairro, município, UF, CEP)

3. Listagem de Empresas
Exibe apenas empresas cadastradas pelo usuário logado

🖥️ Comentários sobre o Front-end com Angular 20
O front foi desenvolvido utilizando Angular versão 20, explorando ao máximo os novos recursos e melhorias de performance do framework:

✅ Standalone Components: melhor modularização e menor acoplamento entre módulos

✅ Signals API: gerenciamento reativo de estado com performance otimizada

✅ Angular CLI 20: configuração simplificada e melhorias na build

✅ Lazy Loading e Guards: navegação protegida e carregamento dinâmico de módulos

✅ Formulários com ReactiveForms: validação robusta de dados e melhor controle dos inputs

✅ UX Responsiva: layout adaptável para dispositivos móveis com Angular Material

💡 A interface foi desenhada com foco na experiência do usuário, com feedback visual claro para erros de formulário, autenticação e resultados de busca de CNPJ.

✅ Critérios de Avaliação Atendidos
Código limpo e modular

Boas práticas de autenticação e segurança

Uso correto da API da ReceitaWS com tratamento de erros (timeout, dados inválidos)

Validação de entrada e feedback ao usuário

Organização clara entre front-end e back-end


# Backend
cd backend
npm install
npm run start

# Frontend
cd frontend
npm install
ng serve
Acesse http://localhost:4200 no navegador.
