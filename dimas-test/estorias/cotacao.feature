#language: pt-BR

Funcionalidade: Nova Cotação

Definição de funcionalidade de Criação de Cotação

Cenário: Criar um novo Cliente
	Dado que o usuário está na tela de cotação
	E clicou em "novo cliente"
	Então Gravamos a cotação no banco de dados 
	Então Redirecionamos para a rota de novo cliente com redirectTo contendo a rota da cotacao atual

Cenário: Criar um novo Fornecedor
	Dado que o usuário está na tela de cotação
	E clicou em "novo fornecedor"
	Então Gravamos a cotação no banco de dados
	Então Redirecionamos para a rota de novo fornecedor com redirectTo contendo a rota da cotacao atual

Cenário: Selecionar um Cliente para uma Cotação
	Dados que o usuário está na tela de cotação
	Quando selecionar um cliente
	Então Gravamos a cotação no banco de dados 
	Então Atribuimos o cliente para a cotação
	
Cenário: Selecionar um Fornecedor para uma Cotação
	Dados que o usuário está na tela de cotação
	Quando selecionar um fornecedor
	Então Gravamos a cotação no banco de dados 
	Então atribuimos o fornecedor para a cotação

Cenário: Inclusão de Produtos em uma Cotação
	Dado que o usuário está na tela de cotações
	E recebeu a atribuição de um cliente 
	E recebeu a atribuição de um fornecedor
	Quando realizar o [ctrl + v] de dados de uma cotação recebida
	Então Gravamos a cotação no banco de dados 
	Então Incluimos na cotação os produtos e as informações dos produtos coletados no [ctrl + v]

Cenário: Clonagem de Cotação
	Permite que alterações sejam realizadas em uma proposta que já foi enviada ao cliente
	Dado que o usuário está na tela de cotação 
	E que a cotação já foi enviada para o cliente (em status de proposta)
	Então O botão "Clonar Cotação" é habilitado