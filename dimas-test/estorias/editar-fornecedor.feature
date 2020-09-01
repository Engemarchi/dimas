#language: pt-BR

Funcionalidade: Editar Fornecedor

Viabiliza a edição dos dados de um fornecedor e seus centros de distribuição pelo usuário do sistema

Cenário: Cadastrar novo fornecedor
	Dado que o usuário solicitou a exibição da tela de edição de um fornecedor
	E não for informado um identificador para o fornecedor que deseja editar
	Então Carrega a tela de edição de fornecedor com todos os campos vazios

Cenário: Editar um fornecedor
	Dado que o usuário solicitou a exibição da tela de edição de um fornecedor
	E informou um identificador para o fornecedor que deseja editar
	Então Carrega a tela de edição de fornecedor com todos os campos preenchidos com os dados do fornecedor identificado
	
Cenário: Editar um fornecedor inexistente ou não válido
	Dado que o usuário solicitou a exibição da tela de edição de um fornecedor
	E informou um identificador inexistente ou não válido para o fornecedor que deseja editar
	Então Apresenta uma mensagem de erro e não permite a navegação para a tela de edição de fornecedor

Cenário: Armazenar dados de um fornecedor 
	Dado que o usuário clicou no botão Salvar
	Então Armazenamos os dados de um novo fornecedor no banco de dados
	E redirecionamos para a página de redirectTo com o header id-fornecedor contendo o identificador do fornecedor criado

Cenário: Armazenar dados de um fornecedor e redireciona para outra página
	Dado que o usuário clicou no botão Salvar
	E o sistema recebeu na requisição da página um queryString com o valor redirectTo
	Então Armazenamos os dados de um novo fornecedor no banco de dados
	E redirecionamos para a página de redirectTo com o header id-fornecedor contendo o identificador do fornecedor criado