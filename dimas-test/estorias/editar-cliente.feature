#language: pt-BR

Funcionalidade: Editar Cliente

Viabiliza a edição dos dados de um cliente e seus endereços de entrega pelo usuário do sistema

Cenário: Cadastrar novo cliente
	Dado que o usuário solicitou a exibição da tela de edição de um cliente
	E não for informado um identificador para o cliente que deseja editar
	Então Carrega a tela de edição de cliente com todos os campos vazios

Cenário: Editar um cliente
	Dado que o usuário solicitou a exibição da tela de edição de um cliente
	E informou um identificador para o cliente que deseja editar
	Então Carrega a tela de edição de cliente com todos os campos preenchidos com os dados do cliente identificado

Cenário: Exibir dados do Cliente
	Dado que o usuário está na tela de edição de um cliente
	Então todos os campos de edição do cliente devem ser apresentados
	
Cenário: Editar um cliente inexistente ou não válido
	Dado que o usuário solicitou a exibição da tela de edição de um cliente
	E informou um identificador inexistente ou não válido para o cliente que deseja editar
	Então Apresenta uma mensagem de erro e não permite a navegação para a tela de edição de cliente

Cenário: Armazenar dados de um cliente 
	Dado que o usuário clicou no botão Salvar
	E o sistema não recebeu na requisição da página um queryString com o valor redirectTo
	Então Armazenamos os dados de um novo cliente no banco de dados
	E redirecionamos para a página de redirectTo com o header id-cliente contendo o identificador do cliente criado

Cenário: Armazenar dados de um cliente e redireciona para outra página
	Dado que o usuário clicou no botão Salvar
	E o sistema recebeu na requisição da página um queryString com o valor redirectTo
	Então Armazenamos os dados de um novo cliente no banco de dados
	E redirecionamos para a página de redirectTo com o header id-cliente contendo o identificador do cliente criado